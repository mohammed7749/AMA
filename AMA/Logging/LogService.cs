using System.Collections.Concurrent;
using System.Text.Json;

namespace SecureDataProtectionTool.Logging;

public class LogService : IDisposable
{
    private bool _disposed;
    private readonly ConcurrentQueue<LogEntry> _logQueue;
    private readonly Thread _logThread;
    private readonly string _logDirectory;
    private readonly string _logFilePath;
    private readonly string _auditLogPath;
    private bool _isRunning;
    private readonly object _fileLock = new();
    private readonly JsonSerializerOptions _jsonOptions;
    
    public event EventHandler<LogEntry>? LogEntryAdded;
    
    public LogService()
    {
        _logQueue = new ConcurrentQueue<LogEntry>();
        
        // تحديد مسار الملفات
        string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        _logDirectory = Path.Combine(appData, "SecureDataProtectionTool", "Logs");
        _logFilePath = Path.Combine(_logDirectory, $"app_{DateTime.Now:yyyyMMdd}.log");
        _auditLogPath = Path.Combine(_logDirectory, $"audit_{DateTime.Now:yyyyMMdd}.log");
        
        // إنشاء المجلدات إذا لم تكن موجودة
        if (!Directory.Exists(_logDirectory))
            Directory.CreateDirectory(_logDirectory);
        
        _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        _isRunning = true;
        _logThread = new Thread(ProcessLogQueue)
        {
            Name = "LogProcessor",
            IsBackground = true,
            Priority = ThreadPriority.BelowNormal
        };
        _logThread.Start();
    }
    
    public void Log(LogEntry entry)
    {
        if (entry == null)
            throw new ArgumentNullException(nameof(entry));
        
        // تنظيف الرسالة من البيانات الحساسة
        entry.Message = SanitizeMessage(entry.Message);
        
        // تنظيف الـ Metadata من البيانات الحساسة
        if (entry.Metadata != null)
        {
            var sanitizedMetadata = new Dictionary<string, object>();
            foreach (var kvp in entry.Metadata)
            {
                if (IsSensitiveKey(kvp.Key))
                {
                    sanitizedMetadata[kvp.Key] = "[REMOVED]";
                }
                else
                {
                    sanitizedMetadata[kvp.Key] = kvp.Value;
                }
            }
            entry.Metadata = sanitizedMetadata;
        }
        
        _logQueue.Enqueue(entry);
        LogEntryAdded?.Invoke(this, entry);
    }
    
    public void LogDebug(string operation, string message, Dictionary<string, object>? metadata = null)
    {
        Log(new LogEntry
        {
            Level = LogLevel.Debug,
            Operation = operation,
            Message = message,
            User = Environment.UserName,
            Source = "Application",
            Metadata = metadata
        });
    }
    
    public void LogInfo(string operation, string message, Dictionary<string, object>? metadata = null, bool success = true)
    {
        Log(new LogEntry
        {
            Level = LogLevel.Info,
            Operation = operation,
            Message = message,
            Success = success,
            User = Environment.UserName,
            Source = "Application",
            Metadata = metadata
        });
    }
    
    public void LogWarning(string operation, string message, Dictionary<string, object>? metadata = null)
    {
        Log(new LogEntry
        {
            Level = LogLevel.Warning,
            Operation = operation,
            Message = message,
            User = Environment.UserName,
            Source = "Application",
            Metadata = metadata
        });
    }
    
    public void LogError(string operation, string message, Exception? exception = null, Dictionary<string, object>? metadata = null)
    {
        Log(new LogEntry
        {
            Level = LogLevel.Error,
            Operation = operation,
            Message = message,
            Success = false,
            User = Environment.UserName,
            Source = "Application",
            Metadata = metadata,
            StackTrace = exception?.StackTrace
        });
    }
    
    public void LogSecurity(string operation, string message, Dictionary<string, object>? metadata = null)
    {
        var entry = new LogEntry
        {
            Level = LogLevel.Security,
            Operation = operation,
            Message = message,
            User = Environment.UserName,
            Source = "Security",
            Metadata = metadata
        };
        
        Log(entry);
        WriteToAuditLog(entry);
    }
    
    public void LogAudit(string operation, string message, Dictionary<string, object>? metadata = null)
    {
        var entry = new LogEntry
        {
            Level = LogLevel.Audit,
            Operation = operation,
            Message = message,
            User = Environment.UserName,
            Source = "Audit",
            Metadata = metadata
        };
        
        Log(entry);
        WriteToAuditLog(entry);
    }
    
    public List<LogEntry> GetLogs(
        DateTime? from = null,
        DateTime? to = null,
        LogLevel? level = null,
        string? operation = null,
        string? source = null,
        bool? success = null,
        int maxCount = 1000)
    {
        var logs = new List<LogEntry>();
        
        try
        {
            // قراءة من ملفات السجل
            var logFiles = Directory.GetFiles(_logDirectory, "app_*.log")
                .OrderByDescending(f => f)
                .Take(7); // آخر 7 أيام
            
            foreach (var file in logFiles)
            {
                if (logs.Count >= maxCount)
                    break;
                
                var fileLogs = ReadLogsFromFile(file, from, to, level, operation, source, success);
                logs.AddRange(fileLogs);
            }
            
            return logs.OrderByDescending(l => l.Timestamp).Take(maxCount).ToList();
        }
        catch
        {
            return logs;
        }
    }
    
    public List<LogEntry> GetAuditLogs(
        DateTime? from = null,
        DateTime? to = null,
        string? operation = null,
        int maxCount = 1000)
    {
        var logs = new List<LogEntry>();
        
        try
        {
            var auditFiles = Directory.GetFiles(_logDirectory, "audit_*.log")
                .OrderByDescending(f => f)
                .Take(30); // آخر 30 يوم
            
            foreach (var file in auditFiles)
            {
                if (logs.Count >= maxCount)
                    break;
                
                var fileLogs = ReadLogsFromFile(file, from, to, null, operation, "Audit", null);
                logs.AddRange(fileLogs);
            }
            
            return logs.OrderByDescending(l => l.Timestamp).Take(maxCount).ToList();
        }
        catch
        {
            return logs;
        }
    }
    
    private List<LogEntry> ReadLogsFromFile(
        string filePath,
        DateTime? from,
        DateTime? to,
        LogLevel? level,
        string? operation,
        string? source,
        bool? success)
    {
        var logs = new List<LogEntry>();
        
        try
        {
            if (!File.Exists(filePath))
                return logs;
            
            string[] lines = File.ReadAllLines(filePath);
            
            foreach (string line in lines)
            {
                try
                {
                    var entry = JsonSerializer.Deserialize<LogEntry>(line, _jsonOptions);
                    if (entry != null)
                    {
                        bool matches = true;
                        
                        if (from.HasValue && entry.Timestamp < from.Value)
                            matches = false;
                        if (to.HasValue && entry.Timestamp > to.Value)
                            matches = false;
                        if (level.HasValue && entry.Level != level.Value)
                            matches = false;
                        if (!string.IsNullOrEmpty(operation) && !entry.Operation.Contains(operation, StringComparison.OrdinalIgnoreCase))
                            matches = false;
                        if (!string.IsNullOrEmpty(source) && entry.Source != source)
                            matches = false;
                        if (success.HasValue && entry.Success != success.Value)
                            matches = false;
                        
                        if (matches)
                            logs.Add(entry);
                    }
                }
                catch
                {
                    // تجاهل السطور غير الصالحة
                }
            }
        }
        catch
        {
            // تجاهل الأخطاء في قراءة الملف
        }
        
        return logs;
    }
    
    public void ClearOldLogs(int retentionDays = 30)
    {
        try
        {
            var cutoffDate = DateTime.Now.AddDays(-retentionDays);
            var logFiles = Directory.GetFiles(_logDirectory, "*.log");
            
            foreach (var file in logFiles)
            {
                try
                {
                    var fileInfo = new FileInfo(file);
                    if (fileInfo.CreationTime < cutoffDate)
                    {
                        fileInfo.Delete();
                    }
                }
                catch
                {
                    // تجاهل الملفات التي لا يمكن حذفها
                }
            }
            
            LogInfo("LogService", $"تم تنظيف السجلات القديمة (أكثر من {retentionDays} يوم)");
        }
        catch (Exception ex)
        {
            LogError("LogService", "فشل في تنظيف السجلات القديمة", ex);
        }
    }
    
    public string ExportLogs(string format = "json")
    {
        try
        {
            var logs = GetLogs(maxCount: 10000);
            
            return format.ToLowerInvariant() switch
            {
                "json" => JsonSerializer.Serialize(logs, new JsonSerializerOptions { WriteIndented = true }),
                "csv" => ExportToCsv(logs),
                "txt" => ExportToText(logs),
                _ => throw new ArgumentException("تنسيق غير مدعوم")
            };
        }
        catch (Exception ex)
        {
            LogError("LogService", "فشل في تصدير السجلات", ex);
            throw;
        }
    }
    
    private string ExportToCsv(List<LogEntry> logs)
    {
        var csv = new System.Text.StringBuilder();
        csv.AppendLine("Timestamp,Level,Operation,Message,User,Source,Success");
        
        foreach (var log in logs)
        {
            csv.AppendLine($"\"{log.Timestamp:yyyy-MM-dd HH:mm:ss}\",\"{log.Level}\",\"{log.Operation}\",\"{log.Message}\",\"{log.User}\",\"{log.Source}\",\"{log.Success}\"");
        }
        
        return csv.ToString();
    }
    
    private string ExportToText(List<LogEntry> logs)
    {
        var text = new System.Text.StringBuilder();
        
        foreach (var log in logs)
        {
            text.AppendLine(log.ToString());
        }
        
        return text.ToString();
    }
    
    private void ProcessLogQueue()
    {
        while (_isRunning)
        {
            try
            {
                if (_logQueue.TryDequeue(out LogEntry? entry))
                {
                    WriteToFile(entry);
                    Thread.Sleep(1);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
            catch
            {
                Thread.Sleep(1000);
            }
        }
        
        // كتابة أي سجلات متبقية عند التوقف
        while (_logQueue.TryDequeue(out LogEntry? entry))
        {
            WriteToFile(entry);
        }
    }
    
    private void WriteToFile(LogEntry entry)
    {
        try
        {
            string json = JsonSerializer.Serialize(entry, _jsonOptions);
            
            lock (_fileLock)
            {
                File.AppendAllText(_logFilePath, json + Environment.NewLine);
            }
        }
        catch
        {
            // تجاهل الأخطاء في الكتابة
        }
    }
    
    private void WriteToAuditLog(LogEntry entry)
    {
        try
        {
            string json = JsonSerializer.Serialize(entry, _jsonOptions);
            
            lock (_fileLock)
            {
                File.AppendAllText(_auditLogPath, json + Environment.NewLine);
            }
        }
        catch
        {
            // تجاهل الأخطاء في الكتابة
        }
    }
    
    private static string SanitizeMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
            return message;
        
        // قائمة الأنماط الحساسة
        var sensitivePatterns = new[]
        {
            "password=", "pass=", "pwd=", "كلمة=", "المرور=",
            "key=", "مفتاح=",
            "secret=", "سر=",
            "token=",
            "creditcard=", "بطاقة=",
            "ssn=", "رقم=",
            "phone=", "هاتف=",
            "email=", "بريد="
        };
        
        foreach (var pattern in sensitivePatterns)
        {
            int index = message.IndexOf(pattern, StringComparison.OrdinalIgnoreCase);
            if (index >= 0)
            {
                // البحث عن نهاية القيمة
                int valueStart = index + pattern.Length;
                int valueEnd = message.IndexOfAny(new[] { ' ', '&', '\n', '\r' }, valueStart);
                if (valueEnd == -1)
                    valueEnd = message.Length;
                
                int valueLength = valueEnd - valueStart;
                if (valueLength > 0)
                {
                    message = message.Remove(valueStart, valueLength).Insert(valueStart, "[REMOVED]");
                }
            }
        }
        
        return message;
    }
    
    private static bool IsSensitiveKey(string key)
    {
        var sensitiveKeys = new[]
        {
            "password", "pass", "pwd", "كلمة", "المرور",
            "key", "مفتاح",
            "secret", "سر",
            "token",
            "creditcard", "بطاقة",
            "ssn", "رقم",
            "phone", "هاتف",
            "email", "بريد"
        };
        
        return sensitiveKeys.Contains(key, StringComparer.OrdinalIgnoreCase);
    }
    
    public void Dispose()
    {
        if (!_disposed)
        {
            _isRunning = false;
            _logThread?.Join(2000);
            
            ClearOldLogs();
            
            _disposed = true;
        }
    }
    
    ~LogService()
    {
        Dispose();
    }
}