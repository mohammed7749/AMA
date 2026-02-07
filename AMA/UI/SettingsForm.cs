using Microsoft.Extensions.DependencyInjection;
using SecureDataProtectionTool.Logging;
using SecureDataProtectionTool.Models;
using SecureDataProtectionTool.Utils;

namespace SecureDataProtectionTool.UI;

public partial class SettingsForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly SettingsManager _settingsManager;
    private readonly LogService _logger;
    private Settings _currentSettings;
    private bool _isModified;
    
    public SettingsForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _settingsManager = serviceProvider.GetRequiredService<SettingsManager>();
        _logger = serviceProvider.GetRequiredService<LogService>();
        _currentSettings = _settingsManager.CurrentSettings.Clone();
        
        InitializeComponent();
        InitializeForm();
    }
    
    private void InitializeForm()
    {
        Text = "إعدادات التطبيق";
        
        // تعيين النصوص
        lblTitle.Text = "إعدادات التطبيق";
        tabEncryption.Text = "إعدادات التشفير";
        tabSecurity.Text = "الأمان";
        tabPasswords.Text = "كلمات المرور";
        tabCustomCrypto.Text = "التشفير المخصص";
        tabUI.Text = "واجهة المستخدم";
        tabLogging.Text = "السجلات";
        
        // مجموعة التشفير
        lblPbkdf2Iterations.Text = "تكرارات PBKDF2:";
        lblSaltLength.Text = "طول الملح (بايت):";
        lblKeySize.Text = "حجم المفتاح (بت):";
        chkUseAdditionalKey.Text = "استخدام مفتاح إضافي";
        chkUseUsername.Text = "استخدام اسم المستخدم";
        
        // مجموعة الأمان
        lblAutoLockTimeout.Text = "مهلة القفل التلقائي (ثانية):";
        lblClipboardTimeout.Text = "مهلة مسح الحافظة (ثانية):";
        chkClearClipboard.Text = "مسح الحافظة بعد الاستخدام";
        chkWipeMemory.Text = "مسح الذاكرة بعد الاستخدام";
        chkAutoDelete.Text = "حذف الملف الأصلي بعد التشفير";
        lblWipePasses.Text = "عدد مرات الكتابة فوق الملف:";
        
        // مجموعة كلمات المرور
        lblMinPasswordLength.Text = "الحد الأدنى لطول كلمة المرور:";
        lblMaxPasswordLength.Text = "الحد الأقصى لطول كلمة المرور:";
        chkIncludeUppercase.Text = "تضمين أحرف كبيرة";
        chkIncludeLowercase.Text = "تضمين أحرف صغيرة";
        chkIncludeNumbers.Text = "تضمين أرقام";
        chkIncludeSymbols.Text = "تضمين رموز";
        chkExcludeSimilar.Text = "استبعاد الأحرف المتشابهة";
        chkExcludeAmbiguous.Text = "استبعاد الأحرف المربكة";
        
        // مجموعة التشفير المخصص
        chkEnableCustomCrypto.Text = "تمكين التشفير المخصص";
        lblSelectedAlgorithm.Text = "الخوارزمية المختارة:";
        chkEnableMD5.Text = "تمكين MD5";
        chkEnableDES.Text = "تمكين DES";
        
        // مجموعة واجهة المستخدم
        lblTheme.Text = "السمة:";
        lblLanguage.Text = "اللغة:";
        chkShowToolTips.Text = "إظهار تلميحات الأدوات";
        chkConfirmBeforeExit.Text = "طلب تأكيد قبل الخروج";
        
        // مجموعة السجلات
        chkEnableLogging.Text = "تمكين التسجيل";
        lblLogRetentionDays.Text = "فترة الاحتفاظ بالسجلات (أيام):";
        chkLogToFile.Text = "التسجيل في ملف";
        chkLogToDatabase.Text = "التسجيل في قاعدة بيانات";
        
        // مجموعة معلومات المستخدم
        lblUsername.Text = "اسم المستخدم الافتراضي:";
        lblAdditionalKey.Text = "المفتاح الإضافي الافتراضي:";
        
        // الأزرار
        btnSave.Text = "💾 حفظ";
        btnCancel.Text = "إلغاء";
        btnReset.Text = "🔄 إعادة تعيين";
        btnApply.Text = "تطبيق";
        
        // تحميل القيم الحالية
        LoadCurrentSettings();
        
        // تعيين الأحداث
        btnSave.Click += BtnSave_Click;
        btnCancel.Click += BtnCancel_Click;
        btnReset.Click += BtnReset_Click;
        btnApply.Click += BtnApply_Click;
        
        // تتبع التغييرات
        WireUpChangeEvents();
        
        _isModified = false;
        UpdateButtonsState();
        
        _logger.LogInfo("SettingsForm", "تم تهيئة نموذج الإعدادات");
    }
    
    private void LoadCurrentSettings()
    {
        // إعدادات التشفير
        numPbkdf2Iterations.Value = _currentSettings.Pbkdf2Iterations;
        numSaltLength.Value = _currentSettings.SaltLength;
        numKeySize.Value = _currentSettings.KeySize;
        chkUseAdditionalKey.Checked = _currentSettings.UseAdditionalKey;
        chkUseUsername.Checked = _currentSettings.UseUsername;
        
        // إعدادات الأمان
        numAutoLockTimeout.Value = _currentSettings.AutoLockTimeout;
        numClipboardTimeout.Value = _currentSettings.ClipboardTimeout;
        chkClearClipboard.Checked = _currentSettings.ClearClipboardAfterUse;
        chkWipeMemory.Checked = _currentSettings.WipeMemoryAfterUse;
        chkAutoDelete.Checked = _currentSettings.AutoDeleteOriginal;
        numWipePasses.Value = _currentSettings.WipePasses;
        
        // إعدادات كلمات المرور
        numMinPasswordLength.Value = _currentSettings.MinPasswordLength;
        numMaxPasswordLength.Value = _currentSettings.MaxPasswordLength;
        chkIncludeUppercase.Checked = _currentSettings.IncludeUppercase;
        chkIncludeLowercase.Checked = _currentSettings.IncludeLowercase;
        chkIncludeNumbers.Checked = _currentSettings.IncludeNumbers;
        chkIncludeSymbols.Checked = _currentSettings.IncludeSymbols;
        chkExcludeSimilar.Checked = _currentSettings.ExcludeSimilar;
        chkExcludeAmbiguous.Checked = _currentSettings.ExcludeAmbiguous;
        
        // إعدادات التشفير المخصص
        chkEnableCustomCrypto.Checked = _currentSettings.EnableCustomCrypto;
        cmbSelectedAlgorithm.Text = _currentSettings.SelectedAlgorithm;
        chkEnableMD5.Checked = _currentSettings.EnableMD5;
        chkEnableDES.Checked = _currentSettings.EnableDES;
        
        // إعدادات واجهة المستخدم
        cmbTheme.Text = _currentSettings.Theme;
        cmbLanguage.Text = _currentSettings.Language;
        chkShowToolTips.Checked = _currentSettings.ShowToolTips;
        chkConfirmBeforeExit.Checked = _currentSettings.ConfirmBeforeExit;
        
        // إعدادات السجلات
        chkEnableLogging.Checked = _currentSettings.EnableLogging;
        numLogRetentionDays.Value = _currentSettings.LogRetentionDays;
        chkLogToFile.Checked = _currentSettings.LogToFile;
        chkLogToDatabase.Checked = _currentSettings.LogToDatabase;
        
        // معلومات المستخدم
        txtUsername.Text = _currentSettings.Username;
        txtAdditionalKey.Text = _currentSettings.AdditionalKey;
        
        // تحديث حالة الحقول المعتمدة
        UpdateDependentFields();
    }
    
    private void WireUpChangeEvents()
    {
        // تتبع التغييرات في جميع عناصر التحكم
        foreach (Control control in GetAllControls(this))
        {
            if (control is NumericUpDown numeric)
            {
                numeric.ValueChanged += (s, e) => MarkAsModified();
            }
            else if (control is TextBox textBox)
            {
                textBox.TextChanged += (s, e) => MarkAsModified();
            }
            else if (control is CheckBox checkBox)
            {
                checkBox.CheckedChanged += (s, e) => MarkAsModified();
            }
            else if (control is ComboBox comboBox)
            {
                comboBox.SelectedIndexChanged += (s, e) => MarkAsModified();
            }
        }
    }
    
    private IEnumerable<Control> GetAllControls(Control control)
    {
        var controls = new List<Control>();
        
        foreach (Control child in control.Controls)
        {
            controls.Add(child);
            controls.AddRange(GetAllControls(child));
        }
        
        return controls;
    }
    
    private void MarkAsModified()
    {
        _isModified = true;
        UpdateButtonsState();
    }
    
    private void UpdateButtonsState()
    {
        btnApply.Enabled = _isModified;
        btnSave.Enabled = _isModified;
    }
    
    private void UpdateDependentFields()
    {
        // تحديث حالة الحقول المعتمدة على خيارات أخرى
        bool customCryptoEnabled = chkEnableCustomCrypto.Checked;
        cmbSelectedAlgorithm.Enabled = customCryptoEnabled;
        chkEnableMD5.Enabled = customCryptoEnabled;
        chkEnableDES.Enabled = customCryptoEnabled;
        
        bool loggingEnabled = chkEnableLogging.Checked;
        numLogRetentionDays.Enabled = loggingEnabled;
        chkLogToFile.Enabled = loggingEnabled;
        chkLogToDatabase.Enabled = loggingEnabled;
    }
    
    private void BtnSave_Click(object? sender, EventArgs e)
    {
        if (SaveSettings())
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
    
    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        if (_isModified)
        {
            var result = MessageBox.Show(
                "هناك تغييرات غير محفوظة. هل تريد تجاهلها والمغادرة؟",
                "تأكيد الإلغاء",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            
            if (result != DialogResult.Yes)
                return;
        }
        
        DialogResult = DialogResult.Cancel;
        Close();
    }
    
    private void BtnReset_Click(object? sender, EventArgs e)
    {
        var result = MessageBox.Show(
            "هل تريد إعادة تعيين جميع الإعدادات إلى القيم الافتراضية؟\n\n" +
            "⚠️ تحذير: هذا الإجراء لا يمكن التراجع عنه!",
            "تأكيد إعادة التعيين",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);
        
        if (result == DialogResult.Yes)
        {
            _currentSettings = new Settings();
            LoadCurrentSettings();
            _isModified = true;
            UpdateButtonsState();
            
            _logger.LogInfo("SettingsForm", "تم إعادة تعيين الإعدادات إلى القيم الافتراضية");
        }
    }
    
    private void BtnApply_Click(object? sender, EventArgs e)
    {
        SaveSettings();
    }
    
    private bool SaveSettings()
    {
        try
        {
            // التحقق من صحة القيم
            if (!ValidateSettings())
                return false;
            
            // تحديث الإعدادات الحالية
            UpdateCurrentSettings();
            
            // حفظ الإعدادات
            _settingsManager.SaveSettings(_currentSettings);
            
            _isModified = false;
            UpdateButtonsState();
            
            MessageBox.Show("تم حفظ الإعدادات بنجاح", "تم", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            _logger.LogInfo("SettingsForm", "تم حفظ الإعدادات بنجاح");
            
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("SettingsForm", "فشل في حفظ الإعدادات", ex);
            MessageBox.Show($"فشل في حفظ الإعدادات: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            return false;
        }
    }
    
    private bool ValidateSettings()
    {
        // التحقق من تكرارات PBKDF2
        if (numPbkdf2Iterations.Value < 10000)
        {
            MessageBox.Show("يجب أن تكون تكرارات PBKDF2 10000 على الأقل", "خطأ في التحقق", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            numPbkdf2Iterations.Focus();
            return false;
        }
        
        // التحقق من طول الملح
        if (numSaltLength.Value < 16)
        {
            MessageBox.Show("يجب أن يكون طول الملح 16 بايت على الأقل", "خطأ في التحقق", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            numSaltLength.Focus();
            return false;
        }
        
        // التحقق من أطوال كلمات المرور
        if (numMinPasswordLength.Value > numMaxPasswordLength.Value)
        {
            MessageBox.Show("الحد الأدنى لطول كلمة المرور يجب أن يكون أقل من أو يساوي الحد الأقصى", 
                "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
            numMinPasswordLength.Focus();
            return false;
        }
        
        if (numMinPasswordLength.Value < 8)
        {
            MessageBox.Show("يجب أن يكون الحد الأدنى لطول كلمة المرور 8 أحرف على الأقل", 
                "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
            numMinPasswordLength.Focus();
            return false;
        }
        
        // التحقق من مهلات الوقت
        if (numAutoLockTimeout.Value < 0)
        {
            MessageBox.Show("مهلة القفل التلقائي يجب أن تكون أكبر من أو تساوي صفر", 
                "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
            numAutoLockTimeout.Focus();
            return false;
        }
        
        if (numClipboardTimeout.Value < 0)
        {
            MessageBox.Show("مهلة مسح الحافظة يجب أن تكون أكبر من أو تساوي صفر", 
                "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
            numClipboardTimeout.Focus();
            return false;
        }
        
        return true;
    }
    
    private void UpdateCurrentSettings()
    {
        // إعدادات التشفير
        _currentSettings.Pbkdf2Iterations = (int)numPbkdf2Iterations.Value;
        _currentSettings.SaltLength = (int)numSaltLength.Value;
        _currentSettings.KeySize = (int)numKeySize.Value;
        _currentSettings.UseAdditionalKey = chkUseAdditionalKey.Checked;
        _currentSettings.UseUsername = chkUseUsername.Checked;
        
        // إعدادات الأمان
        _currentSettings.AutoLockTimeout = (int)numAutoLockTimeout.Value;
        _currentSettings.ClipboardTimeout = (int)numClipboardTimeout.Value;
        _currentSettings.ClearClipboardAfterUse = chkClearClipboard.Checked;
        _currentSettings.WipeMemoryAfterUse = chkWipeMemory.Checked;
        _currentSettings.AutoDeleteOriginal = chkAutoDelete.Checked;
        _currentSettings.WipePasses = (int)numWipePasses.Value;
        
        // إعدادات كلمات المرور
        _currentSettings.MinPasswordLength = (int)numMinPasswordLength.Value;
        _currentSettings.MaxPasswordLength = (int)numMaxPasswordLength.Value;
        _currentSettings.IncludeUppercase = chkIncludeUppercase.Checked;
        _currentSettings.IncludeLowercase = chkIncludeLowercase.Checked;
        _currentSettings.IncludeNumbers = chkIncludeNumbers.Checked;
        _currentSettings.IncludeSymbols = chkIncludeSymbols.Checked;
        _currentSettings.ExcludeSimilar = chkExcludeSimilar.Checked;
        _currentSettings.ExcludeAmbiguous = chkExcludeAmbiguous.Checked;
        
        // إعدادات التشفير المخصص
        _currentSettings.EnableCustomCrypto = chkEnableCustomCrypto.Checked;
        _currentSettings.SelectedAlgorithm = cmbSelectedAlgorithm.Text;
        _currentSettings.EnableMD5 = chkEnableMD5.Checked;
        _currentSettings.EnableDES = chkEnableDES.Checked;
        
        // إعدادات واجهة المستخدم
        _currentSettings.Theme = cmbTheme.Text;
        _currentSettings.Language = cmbLanguage.Text;
        _currentSettings.ShowToolTips = chkShowToolTips.Checked;
        _currentSettings.ConfirmBeforeExit = chkConfirmBeforeExit.Checked;
        
        // إعدادات السجلات
        _currentSettings.EnableLogging = chkEnableLogging.Checked;
        _currentSettings.LogRetentionDays = (int)numLogRetentionDays.Value;
        _currentSettings.LogToFile = chkLogToFile.Checked;
        _currentSettings.LogToDatabase = chkLogToDatabase.Checked;
        
        // معلومات المستخدم
        _currentSettings.Username = txtUsername.Text;
        _currentSettings.AdditionalKey = txtAdditionalKey.Text;
        
        // التحقق من الصحة
        _currentSettings.Validate();
    }
    
    private void chkEnableCustomCrypto_CheckedChanged(object sender, EventArgs e)
    {
        UpdateDependentFields();
        MarkAsModified();
    }
    
    private void chkEnableLogging_CheckedChanged(object sender, EventArgs e)
    {
        UpdateDependentFields();
        MarkAsModified();
    }
    
    private void btnTestSettings_Click(object sender, EventArgs e)
    {
        try
        {
            // اختبار الإعدادات الحالية
            var testSettings = new Settings();
            UpdateCurrentSettings();
            
            string validationResult = ValidateSettingsForTest(_currentSettings);
            
            MessageBox.Show($"نتيجة اختبار الإعدادات:\n\n{validationResult}", 
                "اختبار الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            _logger.LogInfo("SettingsForm", "تم اختبار الإعدادات بنجاح");
        }
        catch (Exception ex)
        {
            _logger.LogError("SettingsForm", "فشل في اختبار الإعدادات", ex);
            MessageBox.Show($"فشل في اختبار الإعدادات: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private string ValidateSettingsForTest(Settings settings)
    {
        var results = new List<string>();
        
        // التحقق من إعدادات التشفير
        if (settings.Pbkdf2Iterations < 10000)
            results.Add("❌ تكرارات PBKDF2 أقل من الحد الأدنى الموصى به (10000)");
        else if (settings.Pbkdf2Iterations < 100000)
            results.Add("⚠️ تكرارات PBKDF2 أقل من القيمة الموصى بها (100000)");
        else
            results.Add("✓ تكرارات PBKDF2 جيدة");
        
        if (settings.SaltLength < 16)
            results.Add("❌ طول الملح أقل من الحد الأدنى (16 بايت)");
        else
            results.Add("✓ طول الملح جيد");
        
        if (settings.KeySize != 256)
            results.Add("⚠️ حجم المفتاح مختلف عن القياسي (256 بت)");
        else
            results.Add("✓ حجم المفتاح قياسي");
        
        // التحقق من إعدادات الأمان
        if (settings.AutoLockTimeout == 0)
            results.Add("⚠️ القفل التلقائي معطل");
        else if (settings.AutoLockTimeout < 60)
            results.Add("⚠️ مهلة القفل قصيرة جداً");
        else
            results.Add("✓ إعدادات القفل التلقائي جيدة");
        
        if (settings.ClipboardTimeout == 0)
            results.Add("⚠️ مسح الحافظة معطل");
        else if (settings.ClipboardTimeout < 10)
            results.Add("⚠️ مهلة مسح الحافظة قصيرة جداً");
        else
            results.Add("✓ إعدادات مسح الحافظة جيدة");
        
        // التحقق من إعدادات كلمات المرور
        if (settings.MinPasswordLength < 12)
            results.Add("❌ الحد الأدنى لطول كلمة المرور ضعيف (يجب أن يكون 12 على الأقل)");
        else
            results.Add("✓ الحد الأدنى لطول كلمة المرور جيد");
        
        if (!settings.IncludeUppercase || !settings.IncludeLowercase || 
            !settings.IncludeNumbers || !settings.IncludeSymbols)
            results.Add("⚠️ بعض خيارات تعقيد كلمة المرور معطلة");
        else
            results.Add("✓ تعقيد كلمة المرور ممتاز");
        
        // التحقق من إعدادات التشفير المخصص
        if (settings.EnableDES)
            results.Add("❌ DES مفعلة (غير آمنة للاستخدام الحديث)");
        
        if (settings.EnableMD5)
            results.Add("⚠️ MD5 مفعلة (يجب استخدامها للتجزئة فقط)");
        
        // ملخص
        int warnings = results.Count(r => r.StartsWith("⚠️"));
        int errors = results.Count(r => r.StartsWith("❌"));
        int successes = results.Count(r => r.StartsWith("✓"));
        
        results.Insert(0, $"الملخص: {successes} ✓ | {warnings} ⚠️ | {errors} ❌\n");
        
        return string.Join("\n", results);
    }
    
    private void btnImport_Click(object sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Title = "استيراد الإعدادات",
            Filter = "ملف إعدادات JSON (*.json)|*.json|جميع الملفات (*.*)|*.*",
            DefaultExt = "json"
        };
        
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                string json = File.ReadAllText(dialog.FileName, System.Text.Encoding.UTF8);
                _settingsManager.ImportSettings(json);
                
                // إعادة تحميل الإعدادات
                _currentSettings = _settingsManager.CurrentSettings.Clone();
                LoadCurrentSettings();
                _isModified = false;
                UpdateButtonsState();
                
                MessageBox.Show("تم استيراد الإعدادات بنجاح", "تم", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                _logger.LogInfo("SettingsForm", $"تم استيراد الإعدادات من: {dialog.FileName}");
            }
            catch (Exception ex)
            {
                _logger.LogError("SettingsForm", "فشل في استيراد الإعدادات", ex);
                MessageBox.Show($"فشل في استيراد الإعدادات: {ex.Message}", "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
    private void btnExport_Click(object sender, EventArgs e)
    {
        using var dialog = new SaveFileDialog
        {
            Title = "تصدير الإعدادات",
            Filter = "ملف إعدادات JSON (*.json)|*.json",
            DefaultExt = "json",
            FileName = $"settings_{DateTime.Now:yyyyMMdd_HHmmss}.json"
        };
        
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                string json = _settingsManager.ExportSettings();
                File.WriteAllText(dialog.FileName, json, System.Text.Encoding.UTF8);
                
                MessageBox.Show("تم تصدير الإعدادات بنجاح", "تم", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                _logger.LogInfo("SettingsForm", $"تم تصدير الإعدادات إلى: {dialog.FileName}");
            }
            catch (Exception ex)
            {
                _logger.LogError("SettingsForm", "فشل في تصدير الإعدادات", ex);
                MessageBox.Show($"فشل في تصدير الإعدادات: {ex.Message}", "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}