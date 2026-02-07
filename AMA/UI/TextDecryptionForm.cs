using Microsoft.Extensions.DependencyInjection;
using SecureDataProtectionTool.Core;
using SecureDataProtectionTool.Logging;
using SecureDataProtectionTool.Models;
using SecureDataProtectionTool.Utils;

namespace SecureDataProtectionTool.UI;

public partial class TextDecryptionForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly TextEncryptionService _textEncryptionService;
    private readonly LogService _logger;
    private readonly SettingsManager _settingsManager;
    private readonly Settings _settings;
    private System.Timers.Timer? _clipboardTimer;
    
    public TextDecryptionForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _textEncryptionService = serviceProvider.GetRequiredService<TextEncryptionService>();
        _logger = serviceProvider.GetRequiredService<LogService>();
        _settingsManager = serviceProvider.GetRequiredService<SettingsManager>();
        _settings = _settingsManager.CurrentSettings;
        
        InitializeComponent();
        InitializeForm();
    }
    
    private void InitializeForm()
    {
        Text = "فك تشفير النصوص";
        lblTitle.Text = "فك تشفير النصوص";
        
        txtInputText.PlaceholderText = "أدخل النص المشفر هنا...";
        txtOutputText.PlaceholderText = "سيظهر النص المفكوك هنا...";
        txtPassword.PlaceholderText = "أدخل كلمة المرور";
        txtUsername.PlaceholderText = "اسم المستخدم (اختياري)";
        txtAdditionalKey.PlaceholderText = "مفتاح إضافي (اختياري)";
        
        txtPassword.UseSystemPasswordChar = true;
        
        lblClipboardTimeout.Text = $"{_settings.ClipboardTimeout} ثانية";
        
        chkUseUsername.Checked = _settings.UseUsername;
        chkUseAdditionalKey.Checked = _settings.UseAdditionalKey;
        chkAutoClearClipboard.Checked = _settings.ClearClipboardAfterUse;
        
        // تعيين تلميحات الأدوات
        toolTip.SetToolTip(btnDecrypt, "فك تشفير النص المدخل");
        toolTip.SetToolTip(btnCopyInput, "نسخ النص المشفر إلى الحافظة");
        toolTip.SetToolTip(btnCopyOutput, "نسخ النص المفكوك إلى الحافظة");
        toolTip.SetToolTip(btnPasteInput, "لصق النص من الحافظة");
        toolTip.SetToolTip(btnClear, "مسح جميع الحقول");
        toolTip.SetToolTip(chkAutoClearClipboard, "مسح الحافظة تلقائياً بعد فترة من الوقت");
        
        UpdateFieldsState();
        
        _logger.LogInfo("TextDecryptionForm", "تم تهيئة نموذج فك تشفير النصوص");
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
    
    private void ChkAutoClearClipboard_CheckedChanged(object? sender, EventArgs e)
    {
        lblClipboardTimeout.Enabled = chkAutoClearClipboard.Checked;
    }
    
    private async void BtnDecrypt_Click(object? sender, EventArgs e)
    {
        if (!ValidateInputs())
            return;
        
        await ProcessTextAsync();
    }
    
    private async Task ProcessTextAsync()
    {
        try
        {
            SetProcessingState(true);
            
            string inputText = txtInputText.Text;
            string password = txtPassword.Text;
            string? username = chkUseUsername.Checked ? txtUsername.Text : null;
            string? additionalKey = chkUseAdditionalKey.Checked ? txtAdditionalKey.Text : null;
            
            OperationResult result = await _textEncryptionService.DecryptTextAsync(
                inputText, password, username, additionalKey);
            
            if (result.Success)
            {
                if (!string.IsNullOrEmpty(result.ResultData))
                {
                    txtOutputText.Text = result.ResultData;
                }
                else
                {
                    txtOutputText.Text = "تم فك تشفير النص بنجاح!";
                }
                
                MessageBox.Show(result.Message, "تم بنجاح", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                _logger.LogInfo("TextDecryptionForm", 
                    $"تم فك تشفير النص بنجاح، الطول: {inputText.Length}");
                
                AddToHistory(inputText, txtOutputText.Text, false, result);
            }
            else
            {
                MessageBox.Show(result.Message + "\n\n" + result.Details, "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                _logger.LogError("TextDecryptionForm", 
                    $"فشل في فك تشفير النص", 
                    new Exception(result.Details));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            _logger.LogError("TextDecryptionForm", "خطأ غير متوقع في معالجة النص", ex);
        }
        finally
        {
            SetProcessingState(false);
        }
    }
    
    private void SetProcessingState(bool processing)
    {
        btnDecrypt.Enabled = !processing;
        btnClear.Enabled = !processing;
        btnCopyInput.Enabled = !processing;
        btnCopyOutput.Enabled = !processing;
        btnPasteInput.Enabled = !processing;
        btnAnalyzeText.Enabled = !processing;
        
        txtInputText.Enabled = !processing;
        txtPassword.Enabled = !processing;
        txtUsername.Enabled = !processing && chkUseUsername.Checked;
        txtAdditionalKey.Enabled = !processing && chkUseAdditionalKey.Checked;
        
        chkUseUsername.Enabled = !processing;
        chkUseAdditionalKey.Enabled = !processing;
        chkShowPassword.Enabled = !processing;
        chkAutoClearClipboard.Enabled = !processing;
        
        if (processing)
        {
            progressBar.Style = ProgressBarStyle.Marquee;
            lblProgress.Text = "جاري المعالجة...";
        }
        else
        {
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Value = 0;
            lblProgress.Text = "جاهز";
        }
    }
    
    private void BtnCopyInput_Click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtInputText.Text))
        {
            _textEncryptionService.CopyToClipboard(txtInputText.Text);
            
            MessageBox.Show("تم نسخ النص المشفر إلى الحافظة", "تم", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            StartClipboardTimer();
            
            _logger.LogInfo("TextDecryptionForm", "تم نسخ النص المشفر إلى الحافظة");
        }
    }
    
    private void BtnCopyOutput_Click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtOutputText.Text))
        {
            _textEncryptionService.CopyToClipboard(txtOutputText.Text);
            
            MessageBox.Show("تم نسخ النص المفكوك إلى الحافظة", "تم", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            StartClipboardTimer();
            
            _logger.LogInfo("TextDecryptionForm", "تم نسخ النص المفكوك إلى الحافظة");
        }
    }
    
    private void BtnPasteInput_Click(object? sender, EventArgs e)
    {
        try
        {
            string? clipboardText = _textEncryptionService.GetFromClipboard();
            if (!string.IsNullOrWhiteSpace(clipboardText))
            {
                txtInputText.Text = clipboardText;
                txtInputText.Focus();
                txtInputText.SelectAll();
                
                _logger.LogInfo("TextDecryptionForm", "تم لصق النص من الحافظة");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("TextDecryptionForm", "فشل في لصق النص من الحافظة", ex);
            MessageBox.Show("تعذر لصق النص من الحافظة", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void BtnClear_Click(object? sender, EventArgs e)
    {
        var result = MessageBox.Show("هل تريد مسح جميع الحقول؟", "تأكيد المسح", 
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        
        if (result == DialogResult.Yes)
        {
            txtInputText.Clear();
            txtOutputText.Clear();
            txtPassword.Clear();
            txtUsername.Clear();
            txtAdditionalKey.Clear();
            
            lstHistory.Items.Clear();
            
            _logger.LogInfo("TextDecryptionForm", "تم مسح جميع الحقول");
        }
    }
    
    private bool ValidateInputs()
    {
        if (string.IsNullOrWhiteSpace(txtInputText.Text))
        {
            MessageBox.Show("يجب إدخال نص مشفر للمعالجة", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtInputText.Focus();
            return false;
        }
        
        try
        {
            byte[] data = Convert.FromBase64String(txtInputText.Text);
        }
        catch (FormatException)
        {
            MessageBox.Show("النص المدخل ليس بتنسيق Base64 صالح", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtInputText.Focus();
            return false;
        }
        
        if (string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            MessageBox.Show("يجب إدخال كلمة المرور", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtPassword.Focus();
            return false;
        }
        
        return true;
    }
    
    private void AddToHistory(string inputText, string outputText, bool encrypt, OperationResult result)
    {
        string operation = encrypt ? "تشفير" : "فك تشفير";
        string status = result.Success ? "✓" : "✗";
        string time = DateTime.Now.ToString("HH:mm:ss");
        string inputPreview = inputText.Length > 50 ? inputText[..50] + "..." : inputText;
        string outputPreview = outputText.Length > 50 ? outputText[..50] + "..." : outputText;
        
        string itemText = $"{time} - {status} {operation}: {inputPreview}";
        
        var item = new ListViewItem(itemText);
        item.SubItems.Add(operation);
        item.SubItems.Add(inputPreview);
        item.SubItems.Add(outputPreview);
        item.SubItems.Add(result.Duration.ToString(@"hh\:mm\:ss\.fff"));
        item.SubItems.Add(result.Success ? "ناجح" : "فشل");
        
        item.ForeColor = result.Success ? Color.Green : Color.Red;
        
        lstHistory.Items.Insert(0, item);
        
        if (lstHistory.Items.Count > 100)
        {
            lstHistory.Items.RemoveAt(lstHistory.Items.Count - 1);
        }
    }
    
    private void UpdateFieldsState()
    {
        txtUsername.Enabled = chkUseUsername.Checked;
        txtAdditionalKey.Enabled = chkUseAdditionalKey.Checked;
        lblClipboardTimeout.Enabled = chkAutoClearClipboard.Checked;
        
        bool hasInput = !string.IsNullOrWhiteSpace(txtInputText.Text);
        bool hasPassword = !string.IsNullOrWhiteSpace(txtPassword.Text);
        
        btnDecrypt.Enabled = hasInput && hasPassword;
        btnCopyInput.Enabled = hasInput;
        btnCopyOutput.Enabled = !string.IsNullOrWhiteSpace(txtOutputText.Text);
        btnAnalyzeText.Enabled = hasInput;
    }
    
    private void StartClipboardTimer()
    {
        if (!chkAutoClearClipboard.Checked || _settings.ClipboardTimeout <= 0)
            return;
        
        _clipboardTimer?.Stop();
        _clipboardTimer?.Dispose();
        
        _clipboardTimer = new System.Timers.Timer(_settings.ClipboardTimeout * 1000);
        _clipboardTimer.Elapsed += (sender, e) =>
        {
            Invoke((MethodInvoker)(() =>
            {
                _textEncryptionService.ClearClipboard();
                _clipboardTimer?.Stop();
                _clipboardTimer?.Dispose();
                _clipboardTimer = null;
                
                _logger.LogInfo("TextDecryptionForm", 
                    $"تم مسح الحافظة تلقائياً بعد {_settings.ClipboardTimeout} ثانية");
            }));
        };
        _clipboardTimer.AutoReset = false;
        _clipboardTimer.Start();
        
        _logger.LogInfo("TextDecryptionForm", 
            $"بدأ مؤقت مسح الحافظة ({_settings.ClipboardTimeout} ثانية)");
    }
    
    private void txtInputText_TextChanged(object sender, EventArgs e)
    {
        UpdateFieldsState();
        
        int length = txtInputText.Text.Length;
        lblInputLength.Text = $"{length} حرف";
        
        if (length > 10000)
        {
            lblInputLength.ForeColor = Color.Red;
        }
        else if (length > 5000)
        {
            lblInputLength.ForeColor = Color.Orange;
        }
        else
        {
            lblInputLength.ForeColor = Color.Green;
        }
    }
    
    private void txtOutputText_TextChanged(object sender, EventArgs e)
    {
        UpdateFieldsState();
        
        int length = txtOutputText.Text.Length;
        lblOutputLength.Text = $"{length} حرف";
        
        if (length > 10000)
        {
            lblOutputLength.ForeColor = Color.Red;
        }
        else if (length > 5000)
        {
            lblOutputLength.ForeColor = Color.Orange;
        }
        else
        {
            lblOutputLength.ForeColor = Color.Green;
        }
    }
    
    private void txtPassword_TextChanged(object sender, EventArgs e)
    {
        UpdateFieldsState();
    }
    
    private void lstHistory_DoubleClick(object sender, EventArgs e)
    {
        if (lstHistory.SelectedItems.Count > 0)
        {
            var item = lstHistory.SelectedItems[0];
            string operation = item.SubItems[1].Text;
            string inputText = item.SubItems[2].Text;
            string outputText = item.SubItems[3].Text;
            string duration = item.SubItems[4].Text;
            string status = item.SubItems[5].Text;
            
            string details = $"العملية: {operation}\n" +
                           $"النص المدخل: {inputText}\n" +
                           $"النص الناتج: {outputText}\n" +
                           $"المدة: {duration}\n" +
                           $"الحالة: {status}\n" +
                           $"الوقت: {item.Text}";
            
            MessageBox.Show(details, "تفاصيل العملية", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    
    private void btnAnalyzeText_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtInputText.Text))
        {
            string text = txtInputText.Text;
            int length = text.Length;
            
            string analysis = $"تحليل النص المشفر:\n" +
                            $"طول النص: {length} حرف\n" +
                            $"تنسيق: Base64\n" +
                            $"ملاحظة: النص مشفر ولا يمكن تحليل محتواه";
            
            MessageBox.Show(analysis, "تحليل النص المشفر", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}