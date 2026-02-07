using Microsoft.Extensions.DependencyInjection;
using SecureDataProtectionTool.Core;
using SecureDataProtectionTool.Logging;
using SecureDataProtectionTool.Models;
using SecureDataProtectionTool.Utils;

namespace SecureDataProtectionTool.UI;

public partial class FileDecryptionForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly FileEncryptionService _fileEncryptionService;
    private readonly LogService _logger;
    private readonly SettingsManager _settingsManager;
    private readonly Settings _settings;
    
    private CancellationTokenSource? _cancellationTokenSource;
    private bool _isProcessing;
    private long _totalBytes;
    private long _processedBytes;
    private DateTime _startTime;
    
    public FileDecryptionForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _fileEncryptionService = serviceProvider.GetRequiredService<FileEncryptionService>();
        _logger = serviceProvider.GetRequiredService<LogService>();
        _settingsManager = serviceProvider.GetRequiredService<SettingsManager>();
        _settings = _settingsManager.CurrentSettings;
        
        InitializeComponent();
        InitializeForm();
    }
    
    private void InitializeForm()
    {
        Text = "فك تشفير الملفات";
        lblTitle.Text = "فك تشفير الملفات";
        
        txtPassword.UseSystemPasswordChar = true;
        
        chkUseUsername.Checked = _settings.UseUsername;
        chkUseAdditionalKey.Checked = _settings.UseAdditionalKey;
        chkAutoGeneratePath.Checked = true;
        
        // تعيين تلميحات الأدوات
        toolTip.SetToolTip(btnDecrypt, "فك تشفير الملف المشفر");
        toolTip.SetToolTip(btnCancel, "إلغاء العملية الجارية");
        toolTip.SetToolTip(btnClear, "مسح جميع الحقول");
        toolTip.SetToolTip(btnAnalyzeFile, "تحليل معلومات الملف");
        toolTip.SetToolTip(btnOpenInput, "فتح الملف المدخل");
        toolTip.SetToolTip(btnOpenOutput, "فتح الملف الناتج");
        toolTip.SetToolTip(chkShowPassword, "إظهار/إخفاء كلمة المرور");
        toolTip.SetToolTip(chkAutoGeneratePath, "توليد مسار الإخراج تلقائياً بناءً على العملية");
        
        UpdateFieldsState();
        
        _logger.LogInfo("FileDecryptionForm", "تم تهيئة نموذج فك تشفير الملفات");
    }
    
    private void ChkShowPassword_CheckedChanged(object? sender, EventArgs e)
    {
        txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
    }
    
    private void ChkUseUsername_CheckedChanged(object? sender, EventArgs e)
    {
        txtUsername.Enabled = chkUseUsername.Checked;
    }
    
    private void ChkUseAdditionalKey_CheckedChanged(object? sender, EventArgs e)
    {
        txtAdditionalKey.Enabled = chkUseAdditionalKey.Checked;
    }
    
    private void ChkAutoGeneratePath_CheckedChanged(object? sender, EventArgs e)
    {
        txtOutputPath.Enabled = !chkAutoGeneratePath.Checked;
        btnBrowseOutput.Enabled = !chkAutoGeneratePath.Checked;
    }
    
    private async void BtnBrowseInput_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Title = "اختر ملفاً مشفراً",
            Filter = "ملفات مشفرة (*.encrypted)|*.encrypted|جميع الملفات (*.*)|*.*",
            Multiselect = false
        };
        
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            txtInputPath.Text = dialog.FileName;
            
            SetLoadingState(true, "جاري تحليل الملف...");
            
            try
            {
                await Task.Run(async () =>
                {
                    await Task.Delay(100);
                    
                    Invoke((MethodInvoker)(() =>
                    {
                        if (chkAutoGeneratePath.Checked)
                        {
                            AutoGenerateOutputPath(dialog.FileName, false);
                        }
                    }));
                    
                    await LoadFileMetadataAsync(dialog.FileName);
                });
            }
            finally
            {
                SetLoadingState(false, "");
            }
        }
    }
    
    private void BtnBrowseOutput_Click(object? sender, EventArgs e)
    {
        using var dialog = new SaveFileDialog
        {
            Title = "حدد موقع حفظ الملف المفكوك",
            Filter = "جميع الملفات (*.*)|*.*",
            DefaultExt = ""
        };
        
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            txtOutputPath.Text = dialog.FileName;
        }
    }
    
    private void AutoGenerateOutputPath(string inputPath, bool encrypt)
    {
        if (string.IsNullOrEmpty(inputPath) || !chkAutoGeneratePath.Checked)
            return;
        
        string outputPath;
        
        if (encrypt)
        {
            outputPath = Path.Combine(
                Path.GetDirectoryName(inputPath)!,
                Path.GetFileNameWithoutExtension(inputPath) + "_encrypted" + ".encrypted");
        }
        else
        {
            if (inputPath.EndsWith(".encrypted", StringComparison.OrdinalIgnoreCase))
            {
                string baseName = Path.GetFileNameWithoutExtension(inputPath);
                if (baseName.EndsWith("_encrypted"))
                {
                    string originalName = baseName.Substring(0, baseName.Length - "_encrypted".Length);
                    outputPath = Path.Combine(
                        Path.GetDirectoryName(inputPath)!,
                        originalName);
                }
                else
                {
                    outputPath = Path.Combine(
                        Path.GetDirectoryName(inputPath)!,
                        baseName + "_decrypted");
                }
            }
            else
            {
                outputPath = Path.Combine(
                    Path.GetDirectoryName(inputPath)!,
                    Path.GetFileNameWithoutExtension(inputPath) + "_decrypted" + Path.GetExtension(inputPath));
            }
        }
        
        outputPath = FileUtils.SanitizeFilePath(outputPath);
        
        int counter = 1;
        string originalOutputPath = outputPath;
        while (File.Exists(outputPath) && outputPath != inputPath)
        {
            string ext = Path.GetExtension(originalOutputPath);
            string name = Path.GetFileNameWithoutExtension(originalOutputPath);
            outputPath = Path.Combine(
                Path.GetDirectoryName(originalOutputPath)!,
                $"{name}_{counter}{ext}");
            outputPath = FileUtils.SanitizeFilePath(outputPath);
            counter++;
            
            if (counter > 1000)
                break;
        }
        
        txtOutputPath.Text = outputPath;
    }
    
    private async void BtnDecrypt_Click(object? sender, EventArgs e)
    {
        if (!ValidateInputs())
            return;
        
        await ProcessFileAsync();
    }
    
    private async Task ProcessFileAsync()
    {
        try
        {
            SetProcessingState(true);
            
            string inputPath = txtInputPath.Text;
            string outputPath = txtOutputPath.Text;
            string password = txtPassword.Text;
            string? username = chkUseUsername.Checked ? txtUsername.Text : null;
            string? additionalKey = chkUseAdditionalKey.Checked ? txtAdditionalKey.Text : null;
            
            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;
            
            var progress = new Progress<double>(value =>
            {
                progressBar.Value = (int)value;
                lblProgress.Text = $"{value:F1}%";
                
                if (_totalBytes > 0 && _processedBytes > 0)
                {
                    double speed = _processedBytes / 1024.0 / 1024.0 / (DateTime.Now - _startTime).TotalSeconds;
                    lblSpeed.Text = $"{speed:F2} ميجابايت/ثانية";
                }
            });
            
            _startTime = DateTime.Now;
            
            if (File.Exists(inputPath))
            {
                var fileInfo = new FileInfo(inputPath);
                _totalBytes = fileInfo.Length;
                _processedBytes = 0;
                lblFileSize.Text = $"حجم الملف: {FileUtils.FormatBytes(fileInfo.Length)}";
            }
            else
            {
                _totalBytes = 0;
                _processedBytes = 0;
            }
            
            lblFileInfo.Text = "جاري فك تشفير الملف...";
            
            OperationResult result = await _fileEncryptionService.DecryptFileAsync(
                inputPath, outputPath, password, username, additionalKey, 
                progress, cancellationToken);
            
            if (result.Success)
            {
                lblFileInfo.Text = "تم فك تشفير الملف بنجاح!";
                
                MessageBox.Show(result.Message, "تم بنجاح", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                _logger.LogInfo("FileDecryptionForm", 
                    $"تم فك تشفير الملف بنجاح: {inputPath}");
                
                AddToProcessedFiles(inputPath, outputPath, false, result);
                
                if (File.Exists(outputPath))
                {
                    await LoadFileMetadataAsync(outputPath);
                }
            }
            else
            {
                MessageBox.Show(result.Message + "\n\n" + result.Details, "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                _logger.LogError("FileDecryptionForm", 
                    $"فشل في فك تشفير الملف: {inputPath}", 
                    new Exception(result.Details));
            }
        }
        catch (OperationCanceledException)
        {
            MessageBox.Show("تم إلغاء العملية", "ملغي", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            _logger.LogWarning("FileDecryptionForm", "تم إلغاء عملية فك التشفير");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            _logger.LogError("FileDecryptionForm", "خطأ غير متوقع في معالجة الملف", ex);
        }
        finally
        {
            SetProcessingState(false);
        }
    }
    
    private void SetProcessingState(bool processing)
    {
        _isProcessing = processing;
        
        btnDecrypt.Enabled = !processing;
        btnCancel.Enabled = processing;
        btnClear.Enabled = !processing;
        btnBrowseInput.Enabled = !processing;
        btnBrowseOutput.Enabled = !processing && !chkAutoGeneratePath.Checked;
        btnOpenInput.Enabled = !processing;
        btnOpenOutput.Enabled = !processing;
        btnAnalyzeFile.Enabled = !processing;
        
        txtInputPath.Enabled = !processing;
        txtOutputPath.Enabled = !processing && !chkAutoGeneratePath.Checked;
        txtPassword.Enabled = !processing;
        txtUsername.Enabled = !processing && chkUseUsername.Checked;
        txtAdditionalKey.Enabled = !processing && chkUseAdditionalKey.Checked;
        
        chkUseUsername.Enabled = !processing;
        chkUseAdditionalKey.Enabled = !processing;
        chkShowPassword.Enabled = !processing;
        chkAutoGeneratePath.Enabled = !processing;
        
        if (processing)
        {
            progressBar.Style = ProgressBarStyle.Marquee;
            lblProgress.Text = "جاري المعالجة...";
            lblSpeed.Text = "0.00 ميجابايت/ثانية";
        }
        else
        {
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Value = 0;
            lblProgress.Text = "0%";
            lblSpeed.Text = string.Empty;
            lblFileInfo.Text = string.Empty;
            lblFileSize.Text = string.Empty;
            
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }
    }
    
    private void SetLoadingState(bool loading, string message)
    {
        if (loading)
        {
            progressBar.Style = ProgressBarStyle.Marquee;
            lblFileInfo.Text = message;
        }
        else
        {
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Value = 0;
            lblFileInfo.Text = string.Empty;
        }
    }
    
    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        _cancellationTokenSource?.Cancel();
        SetProcessingState(false);
    }
    
    private void BtnClear_Click(object? sender, EventArgs e)
    {
        if (_isProcessing)
            return;
        
        var result = MessageBox.Show("هل تريد مسح جميع الحقول؟", "تأكيد المسح", 
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        
        if (result == DialogResult.Yes)
        {
            txtInputPath.Clear();
            txtOutputPath.Clear();
            txtPassword.Clear();
            txtUsername.Clear();
            txtAdditionalKey.Clear();
            
            ClearMetadata();
            lstProcessedFiles.Items.Clear();
            
            _logger.LogInfo("FileDecryptionForm", "تم مسح جميع الحقول");
        }
    }
    
    private void BtnAnalyzeFile_Click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtInputPath.Text) && File.Exists(txtInputPath.Text))
        {
            LoadFileMetadata(txtInputPath.Text);
            
            string filePath = txtInputPath.Text;
            var fileInfo = new FileInfo(filePath);
            
            string analysis = $"تحليل الملف:\n" +
                            $"الاسم: {fileInfo.Name}\n" +
                            $"المسار: {fileInfo.DirectoryName}\n" +
                            $"الحجم: {FileUtils.FormatBytes(fileInfo.Length)}\n" +
                            $"الإنشاء: {fileInfo.CreationTime:yyyy-MM-dd HH:mm:ss}\n" +
                            $"التعديل: {fileInfo.LastWriteTime:yyyy-MM-dd HH:mm:ss}\n" +
                            $"الوصول: {fileInfo.LastAccessTime:yyyy-MM-dd HH:mm:ss}\n" +
                            $"السمات: {fileInfo.Attributes}\n" +
                            $"مشفر: {(_fileEncryptionService.IsEncryptedFile(filePath) ? "نعم" : "لا")}";
            
            MessageBox.Show(analysis, "تحليل الملف", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    
    private void BtnOpenInput_Click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtInputPath.Text) && File.Exists(txtInputPath.Text))
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = txtInputPath.Text,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("FileDecryptionForm", "فشل في فتح الملف", ex);
                MessageBox.Show("تعذر فتح الملف", "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
    private void BtnOpenOutput_Click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtOutputPath.Text) && File.Exists(txtOutputPath.Text))
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = txtOutputPath.Text,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("FileDecryptionForm", "فشل في فتح الملف", ex);
                MessageBox.Show("تعذر فتح الملف", "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
    private bool ValidateInputs()
    {
        if (string.IsNullOrWhiteSpace(txtInputPath.Text))
        {
            MessageBox.Show("يجب تحديد ملف مشفر للإدخال", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtInputPath.Focus();
            return false;
        }
        
        if (!File.Exists(txtInputPath.Text))
        {
            MessageBox.Show("ملف الإدخال غير موجود", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtInputPath.Focus();
            return false;
        }
        
        if (string.IsNullOrWhiteSpace(txtOutputPath.Text))
        {
            MessageBox.Show("يجب تحديد مسار للإخراج", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtOutputPath.Focus();
            return false;
        }
        
        if (string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            MessageBox.Show("يجب إدخال كلمة المرور", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtPassword.Focus();
            return false;
        }
        
        if (File.Exists(txtOutputPath.Text))
        {
            var result = MessageBox.Show("ملف الإخراج موجود بالفعل، هل تريد استبداله؟", 
                "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (result != DialogResult.Yes)
                return false;
        }
        
        if (Path.GetFullPath(txtInputPath.Text) == Path.GetFullPath(txtOutputPath.Text))
        {
            MessageBox.Show("مسار الإدخال والإخراج يجب أن يكونا مختلفين", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        
        try
        {
            var inputFileInfo = new FileInfo(txtInputPath.Text);
            var driveInfo = new DriveInfo(Path.GetPathRoot(txtOutputPath.Text)!);
            
            if (driveInfo.AvailableFreeSpace < inputFileInfo.Length)
            {
                MessageBox.Show("لا توجد مساحة كافية على القرص الوجهة", "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        catch
        {
            // تجاهل خطأ القراءة إذا فشلت
        }
        
        return true;
    }
    
    private async Task LoadFileMetadataAsync(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                return;
            
            Invoke((MethodInvoker)(() =>
            {
                ClearMetadata();
                
                var fileInfo = new FileInfo(filePath);
                lblFileName.Text = $"الاسم: {fileInfo.Name}";
                lblFileSizeInfo.Text = $"الحجم: {FileUtils.FormatBytes(fileInfo.Length)}";
                lblFileDate.Text = $"التاريخ: {fileInfo.LastWriteTime:yyyy-MM-dd HH:mm:ss}";
            }));
            
            await Task.Run(async () =>
            {
                try
                {
                    var metadata = await _fileEncryptionService.GetFileMetadataAsync(filePath);
                    
                    Invoke((MethodInvoker)(() =>
                    {
                        if (metadata != null)
                        {
                            lblAlgorithm.Text = $"الخوارزمية: {metadata.Algorithm}";
                            lblKeySize.Text = $"حجم المفتاح: {metadata.KeySize} بت";
                            lblEncryptionTime.Text = $"وقت التشفير: {metadata.EncryptionTime:yyyy-MM-dd HH:mm:ss}";
                            lblVersion.Text = $"الإصدار: {metadata.Version}";
                            
                            pnlMetadata.BackColor = Color.FromArgb(220, 240, 255);
                            lblFileName.ForeColor = Color.Blue;
                            lblFileSizeInfo.ForeColor = Color.Blue;
                            lblFileDate.ForeColor = Color.Blue;
                        }
                        else
                        {
                            lblAlgorithm.Text = "الخوارزمية: -";
                            lblKeySize.Text = "حجم المفتاح: -";
                            lblEncryptionTime.Text = "وقت التشفير: -";
                            lblVersion.Text = "الإصدار: -";
                            
                            pnlMetadata.BackColor = Color.FromArgb(240, 240, 240);
                            lblFileName.ForeColor = Color.Black;
                            lblFileSizeInfo.ForeColor = Color.Black;
                            lblFileDate.ForeColor = Color.Black;
                        }
                    }));
                }
                catch (Exception ex)
                {
                    _logger.LogError("FileDecryptionForm", "فشل في تحليل بيانات الملف", ex);
                }
            });
        }
        catch (Exception ex)
        {
            _logger.LogError("FileDecryptionForm", "فشل في تحليل بيانات الملف", ex);
        }
    }
    
    private void LoadFileMetadata(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                return;
            
            ClearMetadata();
            
            var fileInfo = new FileInfo(filePath);
            lblFileName.Text = $"الاسم: {fileInfo.Name}";
            lblFileSizeInfo.Text = $"الحجم: {FileUtils.FormatBytes(fileInfo.Length)}";
            lblFileDate.Text = $"التاريخ: {fileInfo.LastWriteTime:yyyy-MM-dd HH:mm:ss}";
            
            Task.Run(() =>
            {
                try
                {
                    var metadata = _fileEncryptionService.GetFileMetadata(filePath);
                    
                    Invoke((MethodInvoker)(() =>
                    {
                        if (metadata != null)
                        {
                            lblAlgorithm.Text = $"الخوارزمية: {metadata.Algorithm}";
                            lblKeySize.Text = $"حجم المفتاح: {metadata.KeySize} بت";
                            lblEncryptionTime.Text = $"وقت التشفير: {metadata.EncryptionTime:yyyy-MM-dd HH:mm:ss}";
                            lblVersion.Text = $"الإصدار: {metadata.Version}";
                            
                            pnlMetadata.BackColor = Color.FromArgb(220, 240, 255);
                            lblFileName.ForeColor = Color.Blue;
                            lblFileSizeInfo.ForeColor = Color.Blue;
                            lblFileDate.ForeColor = Color.Blue;
                        }
                    }));
                }
                catch (Exception ex)
                {
                    _logger.LogError("FileDecryptionForm", "فشل في تحليل بيانات الملف", ex);
                }
            });
        }
        catch (Exception ex)
        {
            _logger.LogError("FileDecryptionForm", "فشل في تحليل بيانات الملف", ex);
        }
    }
    
    private void ClearMetadata()
    {
        lblFileName.Text = "الاسم: -";
        lblFileSizeInfo.Text = "الحجم: -";
        lblFileDate.Text = "التاريخ: -";
        lblAlgorithm.Text = "الخوارزمية: -";
        lblKeySize.Text = "حجم المفتاح: -";
        lblEncryptionTime.Text = "وقت التشفير: -";
        lblVersion.Text = "الإصدار: -";
        
        pnlMetadata.BackColor = Color.FromArgb(240, 240, 240);
        lblFileName.ForeColor = Color.Black;
        lblFileSizeInfo.ForeColor = Color.Black;
        lblFileDate.ForeColor = Color.Black;
    }
    
    private void AddToProcessedFiles(string inputPath, string outputPath, bool encrypt, OperationResult result)
    {
        string fileName = Path.GetFileName(inputPath);
        string status = result.Success ? "✓" : "✗";
        string operation = encrypt ? "تشفير" : "فك تشفير";
        string size = FileUtils.FormatBytes(result.FileSize);
        
        string itemText = $"{status} {operation}: {fileName} ({size})";
        
        var item = new ListViewItem(itemText);
        item.SubItems.Add(inputPath);
        item.SubItems.Add(outputPath);
        item.SubItems.Add(result.Duration.ToString(@"hh\:mm\:ss"));
        item.SubItems.Add(result.Success ? "ناجح" : "فشل");
        
        item.ForeColor = result.Success ? Color.Green : Color.Red;
        
        lstProcessedFiles.Items.Insert(0, item);
        
        if (lstProcessedFiles.Items.Count > 50)
        {
            lstProcessedFiles.Items.RemoveAt(lstProcessedFiles.Items.Count - 1);
        }
    }
    
    private void UpdateFieldsState()
    {
        txtUsername.Enabled = chkUseUsername.Checked;
        txtAdditionalKey.Enabled = chkUseAdditionalKey.Checked;
        txtOutputPath.Enabled = !chkAutoGeneratePath.Checked;
        btnBrowseOutput.Enabled = !chkAutoGeneratePath.Checked;
        
        bool hasInput = !string.IsNullOrWhiteSpace(txtInputPath.Text);
        bool hasPassword = !string.IsNullOrWhiteSpace(txtPassword.Text);
        
        btnDecrypt.Enabled = hasInput && hasPassword && !_isProcessing;
        btnOpenInput.Enabled = hasInput && File.Exists(txtInputPath.Text);
        btnOpenOutput.Enabled = !string.IsNullOrWhiteSpace(txtOutputPath.Text) && File.Exists(txtOutputPath.Text);
        btnAnalyzeFile.Enabled = hasInput && File.Exists(txtInputPath.Text);
    }
    
    private async void txtInputPath_TextChanged(object sender, EventArgs e)
    {
        UpdateFieldsState();
        
        if (!string.IsNullOrWhiteSpace(txtInputPath.Text) && File.Exists(txtInputPath.Text))
        {
            await LoadFileMetadataAsync(txtInputPath.Text);
            
            bool isEncrypted = await Task.Run(() => _fileEncryptionService.IsEncryptedFile(txtInputPath.Text));
            
            Invoke((MethodInvoker)(() =>
            {
                if (chkAutoGeneratePath.Checked)
                {
                    AutoGenerateOutputPath(txtInputPath.Text, !isEncrypted);
                }
            }));
        }
        else
        {
            ClearMetadata();
        }
    }
    
    private void txtOutputPath_TextChanged(object sender, EventArgs e)
    {
        UpdateFieldsState();
    }
    
    private void txtPassword_TextChanged(object sender, EventArgs e)
    {
        UpdateFieldsState();
    }
    
    private void lstProcessedFiles_DoubleClick(object sender, EventArgs e)
    {
        if (lstProcessedFiles.SelectedItems.Count > 0)
        {
            var item = lstProcessedFiles.SelectedItems[0];
            string inputPath = item.SubItems[1].Text;
            string outputPath = item.SubItems[2].Text;
            string duration = item.SubItems[3].Text;
            string status = item.SubItems[4].Text;
            string operation = item.Text.Split(':')[0].Trim();
            
            string details = $"العملية: {operation}\n" +
                           $"مسار الإدخال: {inputPath}\n" +
                           $"مسار الإخراج: {outputPath}\n" +
                           $"المدة: {duration}\n" +
                           $"الحالة: {status}\n" +
                           $"اسم الملف: {Path.GetFileName(inputPath)}";
            
            MessageBox.Show(details, "تفاصيل العملية", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}