using Microsoft.Extensions.DependencyInjection;
using SecureDataProtectionTool.Core;
using SecureDataProtectionTool.Logging;
using SecureDataProtectionTool.Utils;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;

namespace SecureDataProtectionTool.UI;

[SupportedOSPlatform("windows")]
public partial class PasswordCrackerForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly PasswordCracker _passwordCracker;
    private readonly LogService _logger;
    private readonly SettingsManager _settingsManager;
    
    private CancellationTokenSource? _cancellationTokenSource;
    private bool _isRunning;
    private DateTime _startTime;
    private DateTime _lastUpdateTime;
    private int _lastReportedProgress = -1;
    
    public PasswordCrackerForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _passwordCracker = serviceProvider.GetRequiredService<PasswordCracker>();
        _logger = serviceProvider.GetRequiredService<LogService>();
        _settingsManager = serviceProvider.GetRequiredService<SettingsManager>();
        
        InitializeComponent();
        InitializeForm();
    }
    
    private void InitializeForm()
    {
        Text = "اختبار قوة كلمات المرور";
        
        lblTitle.Text = "اختبار قوة كلمات المرور";
        grpAttackType.Text = "نوع الهجوم";
        grpTarget.Text = "الهدف";
        grpOptions.Text = "خيارات الهجوم";
        grpWordlist.Text = "قائمة الكلمات";
        grpProgress.Text = "التقدم";
        grpResults.Text = "النتائج";
        
        lblTargetHash.Text = "التجزئة المستهدفة:";
        lblAlgorithm.Text = "خوارزمية التجزئة:";
        lblMinLength.Text = "الحد الأدنى للطول:";
        lblMaxLength.Text = "الحد الأقصى للطول:";
        lblCharset.Text = "مجموعة الأحرف:";
        lblWordlistFile.Text = "ملف قائمة الكلمات:";
        
        radDictionary.Text = "هجوم القاموس";
        radBruteForce.Text = "هجوم القوة الغاشمة";
        radHash.Text = "تجزئة";
        
        btnLoadWordlist.Text = "تحميل القائمة";
        btnBrowse.Text = "استعراض...";
        btnGenerateCommon.Text = "توليد كلمات شائعة";
        btnClearWordlist.Text = "مسح القائمة";
        btnStart.Text = "▶ بدء الهجوم";
        btnStop.Text = "⏹ إيقاف";
        btnClear.Text = "مسح النتائج";
        btnClose.Text = "إغلاق";
        
        cmbAlgorithm.Items.AddRange(new object[] {
            "MD5",
            "SHA1",
            "SHA256",
            "SHA384",
            "SHA512"
        });
        cmbAlgorithm.SelectedIndex = 2;
        
        cmbCharset.Items.AddRange(new object[] {
            "أرقام فقط (0-9)",
            "أحرف صغيرة (a-z)",
            "أحرف كبيرة وصغيرة (a-zA-Z)",
            "أحرف وأرقام (a-zA-Z0-9)",
            "كل الأحرف (a-zA-Z0-9!@#$%^&*)"
        });
        cmbCharset.SelectedIndex = 3;
        
        numMinLength.Value = 1;
        numMaxLength.Value = 6;
        
        btnLoadWordlist.Click += BtnLoadWordlist_Click;
        btnBrowse.Click += BtnBrowse_Click;
        btnGenerateCommon.Click += BtnGenerateCommon_Click;
        btnClearWordlist.Click += BtnClearWordlist_Click;
        btnStart.Click += BtnStart_Click;
        btnStop.Click += BtnStop_Click;
        btnClear.Click += BtnClear_Click;
        btnClose.Click += BtnClose_Click;
        
        radDictionary.CheckedChanged += RadAttackType_CheckedChanged;
        radBruteForce.CheckedChanged += RadAttackType_CheckedChanged;
        radHash.CheckedChanged += RadAttackType_CheckedChanged;
        
        txtTargetHash.TextChanged += TxtTargetHash_TextChanged;
        
        Load += PasswordCrackerForm_Load;
        
        _passwordCracker.PasswordFound += PasswordCracker_PasswordFound;
        _passwordCracker.ProgressChanged += PasswordCracker_ProgressChanged;
        _passwordCracker.StatusChanged += PasswordCracker_StatusChanged;
        
        UpdateAttackTypeVisibility();
        UpdateButtonsState();
        
        _logger.LogInfo("PasswordCrackerForm", "تم تهيئة نموذج اختبار قوة كلمات المرور");
    }
    
    private void PasswordCrackerForm_Load(object? sender, EventArgs e)
    {
        UpdateAttackTypePlaceholder();
        UpdateButtonsState();
        _logger.LogInfo("PasswordCrackerForm", "تم تحميل النموذج");
    }
    
    private void UpdateAttackTypeVisibility()
    {
        bool isDictionary = radDictionary.Checked;
        bool isBruteForce = radBruteForce.Checked;
        bool isHash = radHash.Checked;
        
        grpWordlist.Visible = isDictionary;
        grpOptions.Visible = isBruteForce || isHash;
        
        lblCharset.Visible = isBruteForce;
        cmbCharset.Visible = isBruteForce;
        lblMinLength.Visible = isBruteForce;
        numMinLength.Visible = isBruteForce;
        lblMaxLength.Visible = isBruteForce;
        numMaxLength.Visible = isBruteForce;
        
        UpdateAttackTypePlaceholder();
    }
    
    private void UpdateAttackTypePlaceholder()
    {
        if (radHash.Checked)
        {
            lblTargetHash.Text = "كلمة المرور:";
            txtTargetHash.PlaceholderText = "أدخل كلمة المرور للتجزئة...";
        }
        else
        {
            lblTargetHash.Text = "التجزئة المستهدفة:";
            txtTargetHash.PlaceholderText = "أدخل التجزئة المستهدفة...";
        }
    }
    
    private void RadAttackType_CheckedChanged(object? sender, EventArgs e)
    {
        UpdateAttackTypeVisibility();
        UpdateButtonsState();
    }
    
    private void TxtTargetHash_TextChanged(object? sender, EventArgs e)
    {
        UpdateButtonsState();
    }
    
    private void UpdateButtonsState()
    {
        bool hasTarget = !string.IsNullOrWhiteSpace(txtTargetHash.Text);
        bool isRunning = _isRunning;
        
        btnStart.Enabled = hasTarget && !isRunning;
        btnStop.Enabled = isRunning;
        btnClear.Enabled = !isRunning;
        btnLoadWordlist.Enabled = !isRunning && radDictionary.Checked;
        btnBrowse.Enabled = !isRunning && radDictionary.Checked;
        btnGenerateCommon.Enabled = !isRunning && radDictionary.Checked;
        btnClearWordlist.Enabled = !isRunning && radDictionary.Checked;
        
        radDictionary.Enabled = !isRunning;
        radBruteForce.Enabled = !isRunning;
        radHash.Enabled = !isRunning;
        cmbAlgorithm.Enabled = !isRunning;
        cmbCharset.Enabled = !isRunning && radBruteForce.Checked;
        numMinLength.Enabled = !isRunning && radBruteForce.Checked;
        numMaxLength.Enabled = !isRunning && radBruteForce.Checked;
        
        btnStart.BackColor = hasTarget && !isRunning ? 
            Color.FromArgb(40, 167, 69) : Color.FromArgb(108, 117, 125);
    }
    
    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtTargetHash.Text))
        {
            ShowErrorMessage("يجب إدخال التجزئة المستهدفة");
            return false;
        }
        
        if (radDictionary.Checked && _passwordCracker.WordlistCount == 0)
        {
            ShowErrorMessage("يجب تحميل قائمة كلمات أولاً");
            return false;
        }
        
        if (radBruteForce.Checked)
        {
            int minLength = (int)numMinLength.Value;
            int maxLength = (int)numMaxLength.Value;
            
            if (minLength > maxLength)
            {
                ShowErrorMessage("الحد الأدنى يجب أن يكون أقل من الحد الأقصى");
                return false;
            }
            
            if (minLength < 1 || maxLength < 1)
            {
                ShowErrorMessage("الطول يجب أن يكون على الأقل 1");
                return false;
            }
        }
        
        return true;
    }
    
    private void ShowErrorMessage(string message)
    {
        MessageBox.Show(message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    
    private void StartAttack()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _isRunning = true;
        _startTime = DateTime.UtcNow;
        _lastUpdateTime = _startTime;
        
        UpdateButtonsState();
        ClearResults();
    }
    
    private async void BtnStart_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput())
            return;
        
        StartAttack();
        
        try
        {
            string targetInput = txtTargetHash.Text.Trim();
            
            if (radDictionary.Checked)
            {
                await ExecuteDictionaryAttack(targetInput);
            }
            else if (radBruteForce.Checked)
            {
                await ExecuteBruteForceAttack(targetInput);
            }
            else if (radHash.Checked)
            {
                ExecuteHashOperation(targetInput);
            }
        }
        catch (OperationCanceledException)
        {
            HandleCancellation();
        }
        catch (Exception ex)
        {
            HandleError(ex);
        }
        finally
        {
            FinalizeOperation();
        }
    }
    
    private async Task ExecuteDictionaryAttack(string targetInput)
    {
        AppendHeader("🔍 بدأ هجوم القاموس");
        AppendInfo($"عدد الكلمات في القائمة: {_passwordCracker.WordlistCount:N0}");
        AppendInfo($"الخوارزمية: {cmbAlgorithm.Text}");
        AppendInfo($"التجزئة المستهدفة: {targetInput}");
        AppendSeparator();
        
        HashAlgorithmName algorithm = _passwordCracker.GetHashAlgorithmName(cmbAlgorithm.Text);
        await _passwordCracker.DictionaryAttackAsync(targetInput, algorithm, _cancellationTokenSource!.Token);
    }
    
    private async Task ExecuteBruteForceAttack(string targetInput)
    {
        string charset = GetCharset();
        int minLength = (int)numMinLength.Value;
        int maxLength = (int)numMaxLength.Value;
        
        AppendHeader("🔍 بدأ هجوم القوة الغاشمة");
        AppendInfo($"الطول: {minLength}-{maxLength}");
        AppendInfo($"مجموعة الأحرف: {cmbCharset.Text}");
        AppendInfo($"الخوارزمية: {cmbAlgorithm.Text}");
        AppendInfo($"التجزئة المستهدفة: {targetInput}");
        AppendSeparator();
        
        HashAlgorithmName algorithm = _passwordCracker.GetHashAlgorithmName(cmbAlgorithm.Text);
        await _passwordCracker.BruteForceAttackAsync(targetInput, algorithm, minLength, maxLength, charset, _cancellationTokenSource!.Token);
    }
    
    private void ExecuteHashOperation(string targetInput)
    {
        HashAlgorithmName algorithm = _passwordCracker.GetHashAlgorithmName(cmbAlgorithm.Text);
        string computedHash = _passwordCracker.ComputeHash(targetInput, algorithm);
        
        AppendHeader("🔑 نتائج التجزئة");
        AppendInfo($"📝 النص المدخل: {targetInput}");
        AppendInfo($"✅ التجزئة ({algorithm.Name}): {computedHash}");
        AppendInfo($"📏 طول التجزئة: {computedHash.Length} حرف");
        AppendInfo($"🔢 الخوارزمية: {cmbAlgorithm.Text}");
        
        CopyToClipboard(computedHash, "📋 تم نسخ التجزئة إلى الحافظة");
        AppendSeparator();
    }
    
    private void AppendHeader(string header)
    {
        txtResults.AppendText("══════════════════════════════════════════" + Environment.NewLine);
        txtResults.AppendText(header + Environment.NewLine);
        txtResults.AppendText("══════════════════════════════════════════" + Environment.NewLine);
    }
    
    private void AppendInfo(string info)
    {
        txtResults.AppendText(info + Environment.NewLine);
    }
    
    private void AppendSeparator()
    {
        txtResults.AppendText(Environment.NewLine);
    }
    
    private void CopyToClipboard(string text, string successMessage)
    {
        try
        {
            Clipboard.SetText(text);
            txtResults.AppendText(successMessage + Environment.NewLine);
        }
        catch (Exception ex)
        {
            _logger.LogError("PasswordCrackerForm", "فشل في نسخ النص إلى الحافظة", ex);
        }
    }
    
    private void HandleCancellation()
    {
        txtResults.AppendText("⏹ تم إلغاء الهجوم" + Environment.NewLine);
        _logger.LogInfo("PasswordCrackerForm", "تم إلغاء الهجوم");
    }
    
    private void HandleError(Exception ex)
    {
        ShowErrorMessage($"فشل في تنفيذ الهجوم: {ex.Message}");
        txtResults.AppendText($"خطأ: {ex.Message}" + Environment.NewLine);
        _logger.LogError("PasswordCrackerForm", "فشل في تنفيذ الهجوم", ex);
    }
    
    private void FinalizeOperation()
    {
        _isRunning = false;
        UpdateButtonsState();
        _cancellationTokenSource?.Dispose();
        _cancellationTokenSource = null;
        
        if (!radHash.Checked)
        {
            ShowFinalStats();
        }
    }
    
    private void ShowFinalStats()
    {
        var elapsedTime = DateTime.UtcNow - _startTime;
        var stats = _passwordCracker.GetStats();
        double speed = elapsedTime.TotalSeconds > 0 ? stats.Attempts / elapsedTime.TotalSeconds : 0;
        
        txtResults.AppendText(Environment.NewLine);
        txtResults.AppendText($"📊 الإحصائيات النهائية:" + Environment.NewLine);
        txtResults.AppendText($"   • عدد المحاولات: {stats.Attempts:N0}" + Environment.NewLine);
        txtResults.AppendText($"   • الوقت المستغرق: {elapsedTime:hh\\:mm\\:ss}" + Environment.NewLine);
        txtResults.AppendText($"   • متوسط السرعة: {speed:N0} محاولة/ثانية" + Environment.NewLine);
        txtResults.AppendText(Environment.NewLine);
    }
    
    private void BtnStop_Click(object? sender, EventArgs e)
    {
        if (_cancellationTokenSource != null)
        {
            _cancellationTokenSource.Cancel();
            btnStop.Enabled = false;
            txtResults.AppendText("⏹ تم طلب إيقاف الهجوم..." + Environment.NewLine);
            _logger.LogInfo("PasswordCrackerForm", "تم طلب إيقاف الهجوم من المستخدم");
        }
    }
    
    private void BtnClear_Click(object? sender, EventArgs e)
    {
        ClearResults();
    }
    
    private void BtnClose_Click(object? sender, EventArgs e)
    {
        if (_isRunning)
        {
            var result = MessageBox.Show("الهجوم لا يزال قيد التشغيل. هل تريد الإغلاق؟", 
                "تأكيد الإغلاق", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (result == DialogResult.No)
                return;
        }
        
        _cancellationTokenSource?.Cancel();
        Close();
    }
    
    private void BtnLoadWordlist_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtWordlistFile.Text))
        {
            ShowErrorMessage("حدد ملف قائمة الكلمات أولاً");
            return;
        }
        
        try
        {
            Cursor = Cursors.WaitCursor;
            _passwordCracker.LoadWordlistFromFile(txtWordlistFile.Text);
            Cursor = Cursors.Default;
            
            UpdateWordlistCount();
            txtResults.AppendText($"📁 تم تحميل {_passwordCracker.WordlistCount:N0} كلمة من: {txtWordlistFile.Text}" + Environment.NewLine);
            _logger.LogInfo("PasswordCrackerForm", $"تم تحميل قائمة كلمات من: {txtWordlistFile.Text}");
        }
        catch (Exception ex)
        {
            Cursor = Cursors.Default;
            ShowErrorMessage($"فشل في تحميل قائمة الكلمات: {ex.Message}");
            _logger.LogError("PasswordCrackerForm", "فشل في تحميل قائمة الكلمات", ex);
        }
    }
    
    private void BtnBrowse_Click(object? sender, EventArgs e)
    {
        using var openDialog = new OpenFileDialog
        {
            Title = "اختر ملف قائمة الكلمات",
            Filter = "ملفات نصية (*.txt)|*.txt|جميع الملفات (*.*)|*.*",
            Multiselect = false
        };
        
        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            txtWordlistFile.Text = openDialog.FileName;
        }
    }
    
    private void BtnGenerateCommon_Click(object? sender, EventArgs e)
    {
        try
        {
            var commonPasswords = _passwordCracker.GetCommonPasswords().ToList();
            _passwordCracker.LoadWordlist(commonPasswords);
            
            UpdateWordlistCount();
            txtResults.AppendText($"✅ تم إضافة {commonPasswords.Count} كلمة شائعة إلى القائمة" + Environment.NewLine);
            txtResults.AppendText("   الكلمات: " + string.Join(", ", commonPasswords.Take(5)) + "..." + Environment.NewLine);
            _logger.LogInfo("PasswordCrackerForm", $"تم إضافة {commonPasswords.Count} كلمة شائعة إلى القائمة");
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"فشل في توليد الكلمات الشائعة: {ex.Message}");
            _logger.LogError("PasswordCrackerForm", "فشل في توليد الكلمات الشائعة", ex);
        }
    }
    
    private void BtnClearWordlist_Click(object? sender, EventArgs e)
    {
        var result = MessageBox.Show("هل أنت متأكد من مسح قائمة الكلمات؟", 
            "تأكيد المسح", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        
        if (result == DialogResult.Yes)
        {
            _passwordCracker.ClearWordlist();
            UpdateWordlistCount();
            txtResults.AppendText("🗑️ تم مسح قائمة الكلمات" + Environment.NewLine);
            _logger.LogInfo("PasswordCrackerForm", "تم مسح قائمة الكلمات");
        }
    }
    
    private void UpdateWordlistCount()
    {
        lblWordlistCount.Text = $"عدد الكلمات: {_passwordCracker.WordlistCount:N0}";
    }
    
    private void ClearResults()
    {
        txtResults.Clear();
        progressBar.Value = 0;
        lblAttempts.Text = "المحاولات: 0";
        lblSpeed.Text = "السرعة: 0/ثانية";
        lblElapsed.Text = "الوقت: 00:00";
        lblStatus.Text = "الحالة: جاهز";
        _lastReportedProgress = -1;
    }
    
    private string GetCharset()
    {
        return cmbCharset.SelectedIndex switch
        {
            0 => "0123456789",
            1 => "abcdefghijklmnopqrstuvwxyz",
            2 => "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ",
            3 => "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789",
            4 => "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*",
            _ => "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        };
    }
    
    private void PasswordCracker_PasswordFound(object? sender, string password)
    {
        if (IsDisposed) return;
        
        BeginInvoke((MethodInvoker)(() =>
        {
            if (IsDisposed || Disposing) return;
            
            AppendSeparator();
            AppendHeader("🎉🎉🎉 تم العثور على كلمة المرور! 🎉🎉🎉");
            AppendInfo($"🔑 كلمة المرور: {password}");
            
            var elapsed = DateTime.UtcNow - _startTime;
            AppendInfo($"🕐 الوقت المستغرق: {elapsed:hh\\:mm\\:ss}");
            
            long attempts = _passwordCracker.Attempts;
            AppendInfo($"🔢 عدد المحاولات: {attempts:N0}");
            
            double speed = elapsed.TotalSeconds > 0 ? attempts / elapsed.TotalSeconds : 0;
            AppendInfo($"⚡ متوسط السرعة: {speed:N0} محاولة/ثانية");
            AppendSeparator();
            
            CopyToClipboard(password, "📋 تم نسخ كلمة المرور إلى الحافظة");
            
            _cancellationTokenSource?.Cancel();
            _isRunning = false;
            UpdateButtonsState();
            
            progressBar.Value = 100;
            lblAttempts.Text = $"المحاولات: {attempts:N0}";
            lblSpeed.Text = $"السرعة: {speed:N0}/ثانية";
            lblElapsed.Text = $"الوقت: {elapsed:mm\\:ss}";
            lblStatus.Text = "الحالة: تم العثور على كلمة المرور";
        }));
    }
    
    private void PasswordCracker_ProgressChanged(object? sender, (int Progress, long Attempts, TimeSpan Elapsed) e)
    {
        if (IsDisposed) return;
        
        BeginInvoke((MethodInvoker)(() =>
        {
            if (IsDisposed || Disposing) return;
            
            if (e.Progress >= 0 && e.Progress <= 100)
            {
                progressBar.Value = e.Progress;
            }
            
            lblAttempts.Text = $"المحاولات: {e.Attempts:N0}";
            
            if (e.Elapsed.TotalSeconds > 0)
            {
                double speed = e.Attempts / e.Elapsed.TotalSeconds;
                lblSpeed.Text = $"السرعة: {speed:N0}/ثانية";
                lblElapsed.Text = $"الوقت: {e.Elapsed:mm\\:ss}";
            }
            
            if (e.Progress % 5 == 0 && e.Progress != _lastReportedProgress)
            {
                if (e.Progress < 100)
                {
                    txtResults.AppendText($"[{DateTime.Now:HH:mm:ss}] التقدم: {e.Progress}% - المحاولات: {e.Attempts:N0}" + Environment.NewLine);
                    _lastReportedProgress = e.Progress;
                }
            }
        }));
    }
    
    private void PasswordCracker_StatusChanged(object? sender, string status)
    {
        if (IsDisposed) return;
        
        BeginInvoke((MethodInvoker)(() =>
        {
            if (IsDisposed || Disposing) return;
            
            lblStatus.Text = $"الحالة: {status}";
            
            if (!status.Contains("تم تحديث") && !status.Contains("التقدم") && !status.Contains("الطول"))
            {
                txtResults.AppendText($"[{DateTime.Now:HH:mm:ss}] {status}" + Environment.NewLine);
            }
        }));
    }
    
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (_isRunning)
        {
            var result = MessageBox.Show("الهجوم لا يزال قيد التشغيل. هل تريد الإغلاق؟", 
                "تأكيد الإغلاق", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }
        
        base.OnFormClosing(e);
        _cancellationTokenSource?.Cancel();
        _passwordCracker.Dispose();
        _logger.LogInfo("PasswordCrackerForm", "تم إغلاق نموذج اختبار قوة كلمات المرور");
    }

    private void cmbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
    {
        // يمكنك إضافة منطق إضافي هنا إذا لزم الأمر
    }
}