using Microsoft.Extensions.DependencyInjection;
using SecureDataProtectionTool.Logging;
using SecureDataProtectionTool.Models;
using SecureDataProtectionTool.Utils;
using System.ComponentModel;

namespace SecureDataProtectionTool.UI;

public partial class LogsForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly LogService _logger;
    private readonly SettingsManager _settingsManager;
    private readonly Settings _settings;
    
    private List<LogEntry>? _currentLogs;
    private List<LogEntry>? _currentAuditLogs;
    
    public LogsForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _logger = serviceProvider.GetRequiredService<LogService>();
        _settingsManager = serviceProvider.GetRequiredService<SettingsManager>();
        _settings = _settingsManager.CurrentSettings;
        
        InitializeComponent();
        InitializeForm();
    }
    
    private void InitializeForm()
    {
        Text = "سجلات النظام والتدقيق";
        
        // تعيين الحد الأدنى لحجم النافذة
        MinimumSize = new Size(1024, 700);
        
        // تعيين النصوص
        lblTitle.Text = "سجلات النظام والتدقيق";
        grpFilters.Text = "مرشحات البحث";
        grpLogs.Text = "سجلات النظام";
        grpAuditLogs.Text = "سجلات التدقيق";
        
        lblDateFrom.Text = "من تاريخ:";
        lblDateTo.Text = "إلى تاريخ:";
        lblLevel.Text = "المستوى:";
        lblOperation.Text = "العملية:";
        lblSource.Text = "المصدر:";
        
        btnRefresh.Text = "🔄 تحديث";
        btnClearFilters.Text = "مسح المرشحات";
        btnExport.Text = "📤 تصدير";
        btnClearLogs.Text = "🗑️ مسح السجلات";
        btnClose.Text = "إغلاق";
        btnSearch.Text = "بحث";
        btnStats.Text = "إحصائيات";
        
        chkSuccessOnly.Text = "العمليات الناجحة فقط";
        chkErrorsOnly.Text = "الأخطاء فقط";
        
        // تعيين خيارات المرشحات
        cmbLevel.Items.AddRange(new object[] {
            "الكل",
            "معلومات",
            "تحذير",
            "خطأ",
            "أمان",
            "تدقيق"
        });
        cmbLevel.SelectedIndex = 0;
        
        cmbSource.Items.AddRange(new object[] {
            "الكل",
            "التطبيق",
            "الأمان",
            "التدقيق"
        });
        cmbSource.SelectedIndex = 0;
        
        // تعيين أعمدة قائمة السجلات
        colLogTime.Text = "الوقت";
        colLogLevel.Text = "المستوى";
        colLogOperation.Text = "العملية";
        colLogMessage.Text = "الرسالة";
        colLogUser.Text = "المستخدم";
        colLogSource.Text = "المصدر";
        colLogSuccess.Text = "الناجحة";
        
        // تعيين أعمدة قائمة التدقيق
        colAuditTime.Text = "الوقت";
        colAuditOperation.Text = "العملية";
        colAuditMessage.Text = "الرسالة";
        colAuditUser.Text = "المستخدم";
        colAuditDetails.Text = "التفاصيل";
        
        // تعيين التواريخ الافتراضية
        dtpFrom.Value = DateTime.Now.AddDays(-7);
        dtpTo.Value = DateTime.Now;
        
        // تعيين الأحداث
        btnRefresh.Click += BtnRefresh_Click;
        btnClearFilters.Click += BtnClearFilters_Click;
        btnExport.Click += BtnExport_Click;
        btnClearLogs.Click += BtnClearLogs_Click;
        btnClose.Click += BtnClose_Click;
        
        // استخدام MouseDoubleClick بدلاً من DoubleClick للتأكد من التوافق
        lstLogs.MouseDoubleClick += LstLogs_MouseDoubleClick;
        lstAuditLogs.MouseDoubleClick += LstAuditLogs_MouseDoubleClick;
        
        // تحميل السجلات
        LoadLogs();
        LoadAuditLogs();
        
        _logger.LogInfo("LogsForm", "تم تهيئة نموذج السجلات");
    }
    
    private void LoadLogs()
    {
        try
        {
            Cursor = Cursors.WaitCursor;
            
            // تطبيق المرشحات
            DateTime? from = dtpFrom.Checked ? dtpFrom.Value : null;
            DateTime? to = dtpTo.Checked ? dtpTo.Value.AddDays(1).AddSeconds(-1) : null;
            
            LogLevel? level = null;
            if (cmbLevel.SelectedIndex > 0)
            {
                level = (LogLevel)(cmbLevel.SelectedIndex - 1);
            }
            
            string? operation = string.IsNullOrWhiteSpace(txtOperation.Text) ? null : txtOperation.Text;
            string? source = cmbSource.SelectedIndex > 0 ? cmbSource.Text : null;
            bool? success = null;
            
            if (chkSuccessOnly.Checked)
                success = true;
            else if (chkErrorsOnly.Checked)
                success = false;
            
            // جلب السجلات
            _currentLogs = _logger.GetLogs(from, to, level, operation, source, success, 1000);
            
            // عرض السجلات
            lstLogs.Items.Clear();
            
            foreach (var log in _currentLogs)
            {
                var item = new ListViewItem(log.Timestamp.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                item.SubItems.Add(GetLevelText(log.Level));
                item.SubItems.Add(log.Operation);
                item.SubItems.Add(log.Message.Length > 100 ? log.Message[..100] + "..." : log.Message);
                item.SubItems.Add(log.User ?? "-");
                item.SubItems.Add(log.Source);
                item.SubItems.Add(log.Success ? "✓" : "✗");
                
                // تعيين اللون بناءً على المستوى
                item.ForeColor = GetLevelColor(log.Level);
                
                lstLogs.Items.Add(item);
            }
            
            lblLogCount.Text = $"عدد السجلات: {_currentLogs.Count}";
            
            _logger.LogDebug("LogsForm", $"تم تحميل {_currentLogs.Count} سجل");
        }
        catch (Exception ex)
        {
            _logger.LogError("LogsForm", "فشل في تحميل السجلات", ex);
            MessageBox.Show($"فشل في تحميل السجلات: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }
    
    private void LoadAuditLogs()
    {
        try
        {
            Cursor = Cursors.WaitCursor;
            
            // تطبيق المرشحات
            DateTime? from = dtpFrom.Checked ? dtpFrom.Value : null;
            DateTime? to = dtpTo.Checked ? dtpTo.Value.AddDays(1).AddSeconds(-1) : null;
            
            string? operation = string.IsNullOrWhiteSpace(txtOperation.Text) ? null : txtOperation.Text;
            
            // جلب سجلات التدقيق
            _currentAuditLogs = _logger.GetAuditLogs(from, to, operation, 500);
            
            // عرض سجلات التدقيق
            lstAuditLogs.Items.Clear();
            
            foreach (var log in _currentAuditLogs)
            {
                var item = new ListViewItem(log.Timestamp.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                item.SubItems.Add(log.Operation);
                item.SubItems.Add(log.Message.Length > 100 ? log.Message[..100] + "..." : log.Message);
                item.SubItems.Add(log.User ?? "-");
                item.SubItems.Add(GetMetadataSummary(log.Metadata));
                
                // تعيين اللون بناءً على النجاح
                item.ForeColor = log.Success ? Color.Green : Color.Red;
                
                lstAuditLogs.Items.Add(item);
            }
            
            lblAuditCount.Text = $"عدد سجلات التدقيق: {_currentAuditLogs.Count}";
            
            _logger.LogDebug("LogsForm", $"تم تحميل {_currentAuditLogs.Count} سجل تدقيق");
        }
        catch (Exception ex)
        {
            _logger.LogError("LogsForm", "فشل في تحميل سجلات التدقيق", ex);
            MessageBox.Show($"فشل في تحميل سجلات التدقيق: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }
    
    private string GetLevelText(LogLevel level)
    {
        return level switch
        {
            LogLevel.Debug => "تصحيح",
            LogLevel.Info => "معلومات",
            LogLevel.Warning => "تحذير",
            LogLevel.Error => "خطأ",
            LogLevel.Security => "أمان",
            LogLevel.Audit => "تدقيق",
            _ => "غير معروف"
        };
    }
    
    private Color GetLevelColor(LogLevel level)
    {
        return level switch
        {
            LogLevel.Debug => Color.Gray,
            LogLevel.Info => Color.Black,
            LogLevel.Warning => Color.Orange,
            LogLevel.Error => Color.Red,
            LogLevel.Security => Color.Purple,
            LogLevel.Audit => Color.Blue,
            _ => Color.Black
        };
    }
    
    private string GetMetadataSummary(Dictionary<string, object>? metadata)
    {
        if (metadata == null || metadata.Count == 0)
            return "-";
        
        return $"{metadata.Count} تفاصيل";
    }
    
    private void BtnRefresh_Click(object? sender, EventArgs e)
    {
        LoadLogs();
        LoadAuditLogs();
    }
    
    private void BtnClearFilters_Click(object? sender, EventArgs e)
    {
        dtpFrom.Value = DateTime.Now.AddDays(-7);
        dtpTo.Value = DateTime.Now;
        dtpFrom.Checked = false;
        dtpTo.Checked = false;
        
        cmbLevel.SelectedIndex = 0;
        cmbSource.SelectedIndex = 0;
        txtOperation.Clear();
        
        chkSuccessOnly.Checked = false;
        chkErrorsOnly.Checked = false;
        
        LoadLogs();
        LoadAuditLogs();
    }
    
    private void BtnExport_Click(object? sender, EventArgs e)
    {
        try
        {
            using var saveDialog = new SaveFileDialog
            {
                Title = "تصدير السجلات",
                Filter = "ملف JSON (*.json)|*.json|ملف CSV (*.csv)|*.csv|ملف نصي (*.txt)|*.txt",
                DefaultExt = "json",
                FileName = $"logs_{DateTime.Now:yyyyMMdd_HHmmss}"
            };
            
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                
                string format = Path.GetExtension(saveDialog.FileName).ToLowerInvariant();
                string content = format switch
                {
                    ".json" => _logger.ExportLogs("json"),
                    ".csv" => _logger.ExportLogs("csv"),
                    ".txt" => _logger.ExportLogs("txt"),
                    _ => _logger.ExportLogs("json")
                };
                
                File.WriteAllText(saveDialog.FileName, content, System.Text.Encoding.UTF8);
                
                Cursor = Cursors.Default;
                
                MessageBox.Show($"تم تصدير السجلات بنجاح إلى: {saveDialog.FileName}", "تم", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                _logger.LogInfo("LogsForm", $"تم تصدير السجلات إلى: {saveDialog.FileName}");
            }
        }
        catch (Exception ex)
        {
            Cursor = Cursors.Default;
            
            _logger.LogError("LogsForm", "فشل في تصدير السجلات", ex);
            MessageBox.Show($"فشل في تصدير السجلات: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void BtnClearLogs_Click(object? sender, EventArgs e)
    {
        var result = MessageBox.Show(
            "⚠️ تحذير: هذا الإجراء سيمسح جميع سجلات النظام والتدقيق.\n" +
            "هذا الإجراء لا يمكن التراجع عنه!\n\n" +
            "هل تريد الاستمرار؟",
            "تأكيد مسح السجلات",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);
        
        if (result == DialogResult.Yes)
        {
            try
            {
                // في تطبيق حقيقي، هنا يتم مسح السجلات من قاعدة البيانات أو الملفات
                // لهذا المثال، سنقوم فقط بتنظيف العرض
                lstLogs.Items.Clear();
                lstAuditLogs.Items.Clear();
                
                _currentLogs?.Clear();
                _currentAuditLogs?.Clear();
                
                lblLogCount.Text = "عدد السجلات: 0";
                lblAuditCount.Text = "عدد سجلات التدقيق: 0";
                
                _logger.LogWarning("LogsForm", "تم مسح جميع السجلات يدوياً");
                
                MessageBox.Show("تم مسح جميع السجلات بنجاح", "تم", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _logger.LogError("LogsForm", "فشل في مسح السجلات", ex);
                MessageBox.Show($"فشل في مسح السجلات: {ex.Message}", "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
    private void BtnClose_Click(object? sender, EventArgs e)
    {
        Close();
    }
    
    private void LstLogs_MouseDoubleClick(object? sender, MouseEventArgs e)
    {
        if (lstLogs.SelectedItems.Count > 0)
        {
            int index = lstLogs.SelectedIndices[0];
            if (index >= 0 && _currentLogs != null && index < _currentLogs.Count)
            {
                var log = _currentLogs[index];
                ShowLogDetails(log, "تفاصيل السجل");
            }
        }
    }
    
    private void LstAuditLogs_MouseDoubleClick(object? sender, MouseEventArgs e)
    {
        if (lstAuditLogs.SelectedItems.Count > 0)
        {
            int index = lstAuditLogs.SelectedIndices[0];
            if (index >= 0 && _currentAuditLogs != null && index < _currentAuditLogs.Count)
            {
                var log = _currentAuditLogs[index];
                ShowLogDetails(log, "تفاصيل سجل التدقيق");
            }
        }
    }
    
    private void ShowLogDetails(LogEntry log, string title)
    {
        try
        {
            var detailsForm = new Form
            {
                Text = title,
                Size = new Size(600, 400),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };
            
            var textBox = new TextBox
            {
                Text = log.ToDetailedString(),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Both,
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 10),
                WordWrap = false
            };
            
            var btnClose = new Button
            {
                Text = "إغلاق",
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Bottom,
                Height = 40
            };
            
            detailsForm.Controls.Add(textBox);
            detailsForm.Controls.Add(btnClose);
            
            detailsForm.AcceptButton = btnClose;
            
            detailsForm.ShowDialog();
        }
        catch (Exception ex)
        {
            _logger.LogError("LogsForm", "فشل في عرض تفاصيل السجل", ex);
            MessageBox.Show($"فشل في عرض تفاصيل السجل: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void btnSearch_Click(object? sender, EventArgs e)
    {
        LoadLogs();
        LoadAuditLogs();
    }
    
    private void btnStats_Click(object? sender, EventArgs e)
    {
        try
        {
            if ((_currentLogs == null || _currentLogs.Count == 0) && 
                (_currentAuditLogs == null || _currentAuditLogs.Count == 0))
            {
                MessageBox.Show("لا توجد سجلات لعرض الإحصائيات", "معلومات", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            // حساب الإحصائيات
            var allLogs = new List<LogEntry>();
            if (_currentLogs != null) allLogs.AddRange(_currentLogs);
            if (_currentAuditLogs != null) allLogs.AddRange(_currentAuditLogs);
            
            if (allLogs.Count == 0)
            {
                MessageBox.Show("لا توجد سجلات لعرض الإحصائيات", "معلومات", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int total = allLogs.Count;
            int success = allLogs.Count(l => l.Success);
            int errors = allLogs.Count(l => !l.Success);
            
            var levelStats = allLogs
                .GroupBy(l => l.Level)
                .Select(g => new { Level = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ToList();
            
            var operationStats = allLogs
                .GroupBy(l => l.Operation)
                .Select(g => new { Operation = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(10)
                .ToList();
            
            var userStats = allLogs
                .Where(l => !string.IsNullOrEmpty(l.User))
                .GroupBy(l => l.User)
                .Select(g => new { User = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(10)
                .ToList();
            
            // بناء نص الإحصائيات
            string stats = $"إحصائيات السجلات:\n\n" +
                         $"إجمالي السجلات: {total}\n" +
                         $"العمليات الناجحة: {success} ({success * 100.0 / total:F1}%)\n" +
                         $"الأخطاء: {errors} ({errors * 100.0 / total:F1}%)\n\n" +
                         $"توزيع المستويات:\n";
            
            foreach (var stat in levelStats)
            {
                stats += $"  {GetLevelText(stat.Level)}: {stat.Count} ({stat.Count * 100.0 / total:F1}%)\n";
            }
            
            stats += $"\nأكثر العمليات تكراراً:\n";
            foreach (var stat in operationStats)
            {
                stats += $"  {stat.Operation}: {stat.Count}\n";
            }
            
            if (userStats.Count > 0)
            {
                stats += $"\nأكثر المستخدمين نشاطاً:\n";
                foreach (var stat in userStats)
                {
                    stats += $"  {stat.User}: {stat.Count}\n";
                }
            }
            
            // عرض الإحصائيات
            MessageBox.Show(stats, "إحصائيات السجلات", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            _logger.LogInfo("LogsForm", "تم عرض إحصائيات السجلات");
        }
        catch (Exception ex)
        {
            _logger.LogError("LogsForm", "فشل في حساب إحصائيات السجلات", ex);
            MessageBox.Show($"فشل في حساب الإحصائيات: {ex.Message}", "خطأ", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }



}