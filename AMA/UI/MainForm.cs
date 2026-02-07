using Microsoft.Extensions.DependencyInjection;
using SecureDataProtectionTool.Core;
using SecureDataProtectionTool.Logging;
using SecureDataProtectionTool.Models;
using SecureDataProtectionTool.Utils;
using System.Runtime.Versioning;

namespace SecureDataProtectionTool.UI;

[SupportedOSPlatform("windows")]
public partial class MainForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly LogService _logger;
    private readonly SettingsManager _settingsManager;
    
    public MainForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _logger = serviceProvider.GetRequiredService<LogService>();
        _settingsManager = serviceProvider.GetRequiredService<SettingsManager>();
        
        InitializeComponent();
        InitializeForm();
    }
    
    private void InitializeForm()
    {
        Text = "أداة حماية الملفات والبيانات الآمنة";
        lblTitle.Text = "أداة حماية الملفات والبيانات الآمنة";
        lblVersion.Text = "الإصدار: 1.0.0 | .NET 8.0";
        
        // دعم وضع ملء الشاشة
        this.WindowState = FormWindowState.Maximized;
        
        // تحديث معلومات النظام
        UpdateSystemInfo();
        
        // تعيين تلميحات الأدوات
        toolTip.SetToolTip(btnFileEncryption, "تشفير الملفات والمجلدات");
        toolTip.SetToolTip(btnFileDecryption, "فك تشفير الملفات والمجلدات");
        toolTip.SetToolTip(btnTextEncryption, "تشفير النصوص");
        toolTip.SetToolTip(btnTextDecryption, "فك تشفير النصوص");
        toolTip.SetToolTip(btnLogs, "عرض سجلات النظام والعمليات");
        toolTip.SetToolTip(btnSettings, "تعديل إعدادات التطبيق");
        toolTip.SetToolTip(btnPasswordGenerator, "توليد كلمات مرور آمنة");
        toolTip.SetToolTip(btnPasswordCracker, "اختبار قوة كلمات المرور");
        toolTip.SetToolTip(btnExit, "إغلاق التطبيق");
        
        // بدء الموقت
        timerUpdate.Start();
        
        _logger.LogInfo("MainForm", "تم تهيئة النموذج الرئيسي");
    }
    
    private void UpdateSystemInfo()
    {
        try
        {
            // معلومات النظام
            string os = Environment.OSVersion.VersionString;
            long memory = GC.GetTotalMemory(false) / 1024 / 1024; // بالميغابايت
            
            lblSystemInfo.Text = $"النظام: {os} | الذاكرة: {memory} MB";
            
            // تحديث الإحصائيات
            UpdateStats();
            
            // تحديث شريط القفل
            UpdateLockStatus();
        }
        catch (Exception ex)
        {
            _logger.LogError("MainForm", "فشل في تحديث معلومات النظام", ex);
        }
    }
    
    private void UpdateStats()
    {
        try
        {
            // هنا يمكن جلب الإحصائيات من قاعدة البيانات أو الملفات
            int successCount = 0;
            int failCount = 0;
            
            lblStats.Text = $"آخر 7 أيام: {successCount} ✓ | {failCount} ✗";
        }
        catch
        {
            lblStats.Text = "آخر 7 أيام: -";
        }
    }
    
    private void UpdateLockStatus()
    {
        try
        {
            var settings = _settingsManager.CurrentSettings;
            
            if (settings.AutoLockEnabled && settings.AutoLockMinutes > 0)
            {
                // حساب الوقت المتبقي للقفل التلقائي
                int remainingSeconds = 300; // قيمة افتراضية
                
                lblLockStatus.Text = $"سيتم القفل بعد: {remainingSeconds} ثانية";
                progressBarLock.Value = (int)((double)remainingSeconds / 300 * 100);
                
                lblLockStatus.Visible = true;
                progressBarLock.Visible = true;
            }
            else
            {
                lblLockStatus.Visible = false;
                progressBarLock.Visible = false;
            }
        }
        catch
        {
            lblLockStatus.Visible = false;
            progressBarLock.Visible = false;
        }
    }
    
    private void btnFileEncryption_Click(object? sender, EventArgs e)
    {
        try
        {
            var form = new FileEncryptionForm(_serviceProvider);
            form.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"فشل في فتح نافذة تشفير الملفات: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogError("MainForm", "فشل في فتح نافذة تشفير الملفات", ex);
        }
    }
    
    private void btnFileDecryption_Click(object? sender, EventArgs e)
    {
        try
        {
            var form = new FileDecryptionForm(_serviceProvider);
            form.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"فشل في فتح نافذة فك تشفير الملفات: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogError("MainForm", "فشل في فتح نافذة فك تشفير الملفات", ex);
        }
    }
    
    private void btnTextEncryption_Click(object? sender, EventArgs e)
    {
        try
        {
            var form = new TextEncryptionForm(_serviceProvider);
            form.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"فشل في فتح نافذة تشفير النصوص: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogError("MainForm", "فشل في فتح نافذة تشفير النصوص", ex);
        }
    }
    
    private void btnTextDecryption_Click(object? sender, EventArgs e)
    {
        try
        {
            var form = new TextDecryptionForm(_serviceProvider);
            form.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"فشل في فتح نافذة فك تشفير النصوص: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogError("MainForm", "فشل في فتح نافذة فك تشفير النصوص", ex);
        }
    }
    
    private void btnLogs_Click(object? sender, EventArgs e)
    {
        try
        {
            var form = new LogsForm(_serviceProvider);
            form.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"فشل في فتح نافذة السجلات: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogError("MainForm", "فشل في فتح نافذة السجلات", ex);
        }
    }
    
    private void btnSettings_Click(object? sender, EventArgs e)
    {
        try
        {
            var form = new SettingsForm(_serviceProvider);
            if (form.ShowDialog() == DialogResult.OK)
            {
                // تحديث الإعدادات إذا تم حفظها
                UpdateSystemInfo();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"فشل في فتح نافذة الإعدادات: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogError("MainForm", "فشل في فتح نافذة الإعدادات", ex);
        }
    }
    
    private void btnPasswordGenerator_Click(object? sender, EventArgs e)
    {
        try
        {
            var form = new PasswordGeneratorForm(_serviceProvider);
            form.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"فشل في فتح نافذة توليد كلمات المرور: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogError("MainForm", "فشل في فتح نافذة توليد كلمات المرور", ex);
        }
    }
    
    private void btnPasswordCracker_Click(object? sender, EventArgs e)
    {
        try
        {
            var form = new PasswordCrackerForm(_serviceProvider);
            form.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"فشل في فتح نافذة اختبار قوة كلمات المرور: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogError("MainForm", "فشل في فتح نافذة اختبار قوة كلمات المرور", ex);
        }
    }
    
    private void btnExit_Click(object? sender, EventArgs e)
    {
        Close();
    }
    
    private void btnAbout_Click(object? sender, EventArgs e)
    {
        MessageBox.Show(
            "أداة حماية الملفات والبيانات الآمنة\n" +
            "الإصدار: 1.0.0\n" +
            "تم التطوير باستخدام: .NET 8.0\n\n" +
            "ميزات التطبيق:\n" +
            "• تشفير وفك تشفير الملفات والمجلدات\n" +
            "• تشفير وفك تشفير النصوص\n" +
            "• توليد كلمات مرور آمنة\n" +
            "• اختبار قوة كلمات المرور\n" +
            "• إدارة السجلات والإعدادات\n\n" +
            "© 2024 جميع الحقوق محفوظة",
            "حول التطبيق",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }
    
    private void linkLabelHelp_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        try
        {
            // افتح موقع المساعدة أو ملف التعليمات
            string helpUrl = "https://example.com/help";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = helpUrl,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show($"تعذر فتح صفحة المساعدة: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogError("MainForm", "فشل في فتح صفحة المساعدة", ex);
        }
    }
    
    private void timerUpdate_Tick(object? sender, EventArgs e)
    {
        UpdateSystemInfo();
    }
    
    private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        try
        {
            // تأكيد الخروج
            if (_settingsManager.CurrentSettings.ConfirmExit)
            {
                var result = MessageBox.Show("هل تريد حقاً إغلاق التطبيق؟", "تأكيد الخروج", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }
            
            // تسجيل الخروج
            _logger.LogInfo("MainForm", "تم إغلاق التطبيق");
            
            // تنظيف الموارد
            timerUpdate.Stop();
        }
        catch (Exception ex)
        {
            _logger.LogError("MainForm", "خطأ أثناء إغلاق التطبيق", ex);
        }
    }
}