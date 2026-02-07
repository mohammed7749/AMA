namespace SecureDataProtectionTool.Models;

public class OperationResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string OperationType { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    
    // إضافة هذه الخاصية الجديدة لتخزين النتائج
    public string ResultData { get; set; } = string.Empty;
    
    public static OperationResult SuccessResult(string message, string operationType = "")
    {
        return new OperationResult
        {
            Success = true,
            Message = message,
            OperationType = operationType
        };
    }
    
    // دالة جديدة لإرجاع النتائج مع البيانات
    public static OperationResult SuccessResultWithData(string message, string resultData, string operationType = "")
    {
        return new OperationResult
        {
            Success = true,
            Message = message,
            ResultData = resultData,
            OperationType = operationType
        };
    }
    
    public static OperationResult ErrorResult(string message, string details = "", string operationType = "")
    {
        return new OperationResult
        {
            Success = false,
            Message = message,
            Details = details,
            OperationType = operationType
        };
    }
    
    public override string ToString()
    {
        return $"[{Timestamp:HH:mm:ss}] {(Success ? "✓" : "✗")} {OperationType}: {Message}";
    }
}