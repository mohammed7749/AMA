using Microsoft.Extensions.DependencyInjection;
using SecureDataProtectionTool.Core;
using SecureDataProtectionTool.Logging;
using SecureDataProtectionTool.Models;
using SecureDataProtectionTool.Utils;

namespace SecureDataProtectionTool.UI;

public partial class PasswordGeneratorForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly PasswordGenerator _passwordGenerator;
    private readonly LogService _logger;
    private readonly SettingsManager _settingsManager;
    private readonly Settings _settings;
    
    private System.Timers.Timer? _clipboardTimer;
    
    public PasswordGeneratorForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _passwordGenerator = serviceProvider.GetRequiredService<PasswordGenerator>();
        _logger = serviceProvider.GetRequiredService<LogService>();
        _settingsManager = serviceProvider.GetRequiredService<SettingsManager>();
        _settings = _settingsManager.CurrentSettings;
        
        InitializeComponent();
        InitializeForm();
    }
    
    private void InitializeForm()
    {
        Text = "توليد كلمات مرور آمنة";
        
        // تمكين التحكم الكامل بحجم النافذة
        this.FormBorderStyle = FormBorderStyle.Sizable;
        this.MaximizeBox = true;
        this.MinimizeBox = true;
        this.MinimumSize = new Size(1024, 700);
        
        // تعيين النصوص
        lblTitle.Text = "توليد كلمات مرور آمنة";
        grpPassword.Text = "خيارات كلمة المرور";
        grpPassphrase.Text = "خيارات عبارة المرور";
        grpGenerated.Text = "كلمة المرور المولدة";
        
        lblLength.Text = "الطول:";
        lblPasswordCount.Text = "عدد كلمات المرور:";
        lblWordCount.Text = "عدد الكلمات:";
        lblSeparator.Text = "الفاصل:";
        lblLanguage.Text = "اللغة:";
        
        chkUppercase.Text = "أحرف كبيرة";
        chkLowercase.Text = "أحرف صغيرة";
        chkNumbers.Text = "أرقام";
        chkSymbols.Text = "رموز";
        chkExcludeAmbiguous.Text = "استبعاد الأحرف المربكة";
        chkExcludeSimilar.Text = "استبعاد الأحرف المتشابهة";
        chkUseArabic.Text = "استخدام الأحرف العربية";
        
        chkCapitalize.Text = "حروف كبيرة";
        chkIncludeNumber.Text = "إضافة رقم";
        chkIncludeSymbol.Text = "إضافة رمز";
        
        btnGeneratePassword.Text = "توليد كلمة مرور";
        btnGeneratePassphrase.Text = "توليد عبارة مرور";
        btnGenerateMultiple.Text = "توليد متعدد";
        btnGeneratePIN.Text = "توليد PIN";
        btnCopyPassword.Text = "نسخ";
        btnClear.Text = "مسح";
        btnClose.Text = "إغلاق";
        btnEvaluate.Text = "تقييم القوة";
        
        radPassword.Text = "كلمة مرور";
        radPassphrase.Text = "عبارة مرور";
        radPIN.Text = "PIN";
        
        // تعيين القيم الافتراضية
        numLength.Value = 16;
        numPasswordCount.Value = 5;
        numWordCount.Value = 4;
        
        cmbLanguage.Items.AddRange(new object[] { "الإنجليزية", "العربية" });
        cmbLanguage.SelectedIndex = 0;
        
        // تطبيق الإعدادات
        ApplySettings();
        
        // تعيين الأحداث
        btnGeneratePassword.Click += BtnGeneratePassword_Click;
        btnGeneratePassphrase.Click += BtnGeneratePassphrase_Click;
        btnGenerateMultiple.Click += BtnGenerateMultiple_Click;
        btnGeneratePIN.Click += BtnGeneratePIN_Click;
        btnCopyPassword.Click += BtnCopyPassword_Click;
        btnClear.Click += BtnClear_Click;
        btnClose.Click += BtnClose_Click;
        btnEvaluate.Click += BtnEvaluate_Click;
        
        radPassword.CheckedChanged += RadType_CheckedChanged;
        radPassphrase.CheckedChanged += RadType_CheckedChanged;
        radPIN.CheckedChanged += RadType_CheckedChanged;
        
        txtGeneratedPassword.TextChanged += TxtGeneratedPassword_TextChanged;
        
        UpdateTypeVisibility();
        
        _logger.LogInfo("PasswordGeneratorForm", "تم تهيئة نموذج توليد كلمات المرور");
    }
    
    private void ApplySettings()
    {
        numLength.Minimum = _settings.MinPasswordLength;
        numLength.Maximum = _settings.MaxPasswordLength;
        numLength.Value = Math.Max(_settings.MinPasswordLength, Math.Min(_settings.MaxPasswordLength, 16));
        
        chkUppercase.Checked = _settings.IncludeUppercase;
        chkLowercase.Checked = _settings.IncludeLowercase;
        chkNumbers.Checked = _settings.IncludeNumbers;
        chkSymbols.Checked = _settings.IncludeSymbols;
        chkExcludeAmbiguous.Checked = _settings.ExcludeAmbiguous;
        chkExcludeSimilar.Checked = _settings.ExcludeSimilar;
    }
    
    private void UpdateTypeVisibility()
    {
        bool isPassword = radPassword.Checked;
        bool isPassphrase = radPassphrase.Checked;
        bool isPIN = radPIN.Checked;
        
        // إظهار/إخفاء المجموعات
        grpPassword.Visible = isPassword;
        grpPassphrase.Visible = isPassphrase;
        
        // إظهار/إخفاء الأزرار
        btnGeneratePassword.Visible = isPassword;
        btnGeneratePassphrase.Visible = isPassphrase;
        btnGeneratePIN.Visible = isPIN;
        btnGenerateMultiple.Visible = isPassword;
        
        // تحديث تسميات
        if (isPIN)
        {
            lblLength.Text = "الطول (4-8):";
            numLength.Minimum = 4;
            numLength.Maximum = 8;
            numLength.Value = 4;
        }
        else if (isPassword)
        {
            lblLength.Text = "الطول:";
            numLength.Minimum = _settings.MinPasswordLength;
            numLength.Maximum = _settings.MaxPasswordLength;
        }
    }
    
    private void RadType_CheckedChanged(object? sender, EventArgs e)
    {
        UpdateTypeVisibility();
    }
    
    private void BtnGeneratePassword_Click(object? sender, EventArgs e)
    {
        try
        {
            var options = new PasswordOptions
            {
                Length = (int)numLength.Value,
                IncludeUppercase = chkUppercase.Checked,
                IncludeLowercase = chkLowercase.Checked,
                IncludeNumbers = chkNumbers.Checked,
                IncludeSymbols = chkSymbols.Checked,
                ExcludeAmbiguous = chkExcludeAmbiguous.Checked,
                ExcludeSimilar = chkExcludeSimilar.Checked,
                UseArabic = chkUseArabic.Checked
            };
            
            string password = _passwordGenerator.GeneratePassword(options);
            txtGeneratedPassword.Text = password;
            
            EvaluateAndDisplayStrength(password);
            
            _logger.LogInfo("PasswordGeneratorForm", 
                $"تم توليد كلمة مرور بطول {options.Length} حرف");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"فشل في توليد كلمة المرور: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogError("PasswordGeneratorForm", "فشل في توليد كلمة المرور", ex);
        }
    }
    
    private void BtnGeneratePassphrase_Click(object? sender, EventArgs e)
    {
        try
        {
            var options = new PassphraseOptions
            {
                WordCount = (int)numWordCount.Value,
                Separator = txtSeparator.Text,
                Capitalize = chkCapitalize.Checked,
                IncludeNumber = chkIncludeNumber.Checked,
                IncludeSymbol = chkIncludeSymbol.Checked,
                Language = cmbLanguage.SelectedIndex == 1 ? "ar" : "en"
            };
            
            string passphrase = _passwordGenerator.GeneratePassphrase(options);
            txtGeneratedPassword.Text = passphrase;
            
            EvaluateAndDisplayStrength(passphrase);
            
            _logger.LogInfo("PasswordGeneratorForm", 
                $"تم توليد عبارة مرور من {options.WordCount} كلمة");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"فشل في توليد عبارة المرور: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogError("PasswordGeneratorForm", "فشل في توليد عبارة المرور", ex);
        }
    }
    
    private void BtnGenerateMultiple_Click(object? sender, EventArgs e)
    {
        try
        {
            int count = (int)numPasswordCount.Value;
            if (count < 1 || count > 50)
            {
                MessageBox.Show("عدد كلمات المرور يجب أن يكون بين 1 و 50", "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            var options = new PasswordOptions
            {
                Length = (int)numLength.Value,
                IncludeUppercase = chkUppercase.Checked,
                IncludeLowercase = chkLowercase.Checked,
                IncludeNumbers = chkNumbers.Checked,
                IncludeSymbols = chkSymbols.Checked,
                ExcludeAmbiguous = chkExcludeAmbiguous.Checked,
                ExcludeSimilar = chkExcludeSimilar.Checked,
                UseArabic = chkUseArabic.Checked
            };
            
            var passwords = _passwordGenerator.GenerateMultiple(options, count);
            
            // عرض كلمات المرور
            txtGeneratedPassword.Text = string.Join(Environment.NewLine, passwords);
            
            _logger.LogInfo("PasswordGeneratorForm", 
                $"تم توليد {count} كلمة مرور");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"فشل في توليد كلمات المرور المتعددة: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogError("PasswordGeneratorForm", "فشل في توليد كلمات مرور متعددة", ex);
        }
    }
    
    private void BtnGeneratePIN_Click(object? sender, EventArgs e)
    {
        try
        {
            int length = (int)numLength.Value;
            string pin = _passwordGenerator.GeneratePIN(length);
            txtGeneratedPassword.Text = pin;
            
            // تقييم قوة PIN
            var strength = length switch
            {
                4 => PasswordStrength.Weak,
                5 or 6 => PasswordStrength.Moderate,
                7 or 8 => PasswordStrength.Strong,
                _ => PasswordStrength.VeryWeak
            };
            
            DisplayStrength(strength);
            
            _logger.LogInfo("PasswordGeneratorForm", 
                $"تم توليد PIN بطول {length} أرقام");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"فشل في توليد PIN: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogError("PasswordGeneratorForm", "فشل في توليد PIN", ex);
        }
    }
    
    private void EvaluateAndDisplayStrength(string password)
    {
        var strength = _passwordGenerator.EvaluateStrength(password);
        DisplayStrength(strength);
    }
    
    private void DisplayStrength(PasswordStrength strength)
    {
        lblStrength.Text = $"القوة: {_passwordGenerator.GetStrengthDescription(strength)}";
        
        // تحديث شريط التقدم واللون
        progressStrength.Value = strength switch
        {
            PasswordStrength.VeryWeak => 20,
            PasswordStrength.Weak => 40,
            PasswordStrength.Moderate => 60,
            PasswordStrength.Strong => 80,
            PasswordStrength.VeryStrong => 100,
            _ => 0
        };
        
        progressStrength.ForeColor = strength switch
        {
            PasswordStrength.VeryWeak => Color.Red,
            PasswordStrength.Weak => Color.Orange,
            PasswordStrength.Moderate => Color.Yellow,
            PasswordStrength.Strong => Color.LightGreen,
            PasswordStrength.VeryStrong => Color.Green,
            _ => Color.Gray
        };
    }
    
    private void BtnCopyPassword_Click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtGeneratedPassword.Text))
        {
            Clipboard.SetText(txtGeneratedPassword.Text);
            
            MessageBox.Show("تم نسخ كلمة المرور إلى الحافظة", "تم", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            StartClipboardTimer();
            
            _logger.LogInfo("PasswordGeneratorForm", "تم نسخ كلمة المرور إلى الحافظة");
        }
    }
    
    private void BtnClear_Click(object? sender, EventArgs e)
    {
        txtGeneratedPassword.Clear();
        lblStrength.Text = "القوة: -";
        progressStrength.Value = 0;
    }
    
    private void BtnClose_Click(object? sender, EventArgs e)
    {
        Close();
    }
    
    private void BtnEvaluate_Click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtGeneratedPassword.Text))
        {
            EvaluateAndDisplayStrength(txtGeneratedPassword.Text);
        }
        else
        {
            MessageBox.Show("أدخل كلمة مرور أولاً", "تحذير", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    
    private void StartClipboardTimer()
    {
        if (_settings.ClipboardTimeout <= 0)
            return;
        
        _clipboardTimer?.Stop();
        _clipboardTimer?.Dispose();
        
        _clipboardTimer = new System.Timers.Timer(_settings.ClipboardTimeout * 1000);
        _clipboardTimer.Elapsed += (sender, e) =>
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                Clipboard.Clear();
                _clipboardTimer?.Stop();
                _clipboardTimer?.Dispose();
                _clipboardTimer = null;
                
                _logger.LogInfo("PasswordGeneratorForm", 
                    $"تم مسح الحافظة تلقائياً بعد {_settings.ClipboardTimeout} ثانية");
            }));
        };
        _clipboardTimer.AutoReset = false;
        _clipboardTimer.Start();
    }
    
    private void TxtGeneratedPassword_TextChanged(object sender, EventArgs e)
    {
        btnCopyPassword.Enabled = !string.IsNullOrWhiteSpace(txtGeneratedPassword.Text);
        btnEvaluate.Enabled = !string.IsNullOrWhiteSpace(txtGeneratedPassword.Text);
    }
}