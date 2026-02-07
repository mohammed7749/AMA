namespace SecureDataProtectionTool.Logging;

public class LogEntry
{
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public LogLevel Level { get; set; } = LogLevel.Info;
    public string Operation { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string? User { get; set; }
    public string Source { get; set; } = "Application";
    public bool Success { get; set; } = true;
    public Dictionary<string, object>? Metadata { get; set; }
    public string? StackTrace { get; set; }
    
    public LogEntry() { }
    
    public LogEntry(LogLevel level, string operation, string message, bool success = true)
    {
        Level = level;
        Operation = operation;
        Message = message;
        Success = success;
        User = Environment.UserName;
    }
    
    public override string ToString()
    {
        return $"[{Timestamp:yyyy-MM-dd HH:mm:ss}] [{Level}] {Operation}: {Message}";
    }
    
    public string ToDetailedString()
    {
        return $"""
            Timestamp: {Timestamp:yyyy-MM-dd HH:mm:ss.fff}
            Level: {Level}
            Operation: {Operation}
            Message: {Message}
            User: {User}
            Source: {Source}
            Success: {Success}
            StackTrace: {StackTrace ?? "N/A"}
            """;
    }
}

public enum LogLevel
{
    Debug,
    Info,
    Warning,
    Error,
    Security,
    Audit
}