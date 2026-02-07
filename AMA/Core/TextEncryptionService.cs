using System.Security.Cryptography;
using System.Text;
using SecureDataProtectionTool.Models;
using SecureDataProtectionTool.Security;

namespace SecureDataProtectionTool.Core;

public class TextEncryptionService : IDisposable
{
    private bool _disposed;
    private readonly CryptoEngine _cryptoEngine;
    private readonly Logging.LogService? _logger;
    private readonly Settings _settings;
    private System.Timers.Timer? _clipboardTimer;
    
    public TextEncryptionService(CryptoEngine cryptoEngine, Logging.LogService? logger = null, Settings? settings = null)
    {
        _cryptoEngine = cryptoEngine ?? throw new ArgumentNullException(nameof(cryptoEngine));
        _logger = logger;
        _settings = settings ?? new Settings();
    }
    
    public async Task<OperationResult> EncryptTextAsync(
        string plainText,
        string password,
        string? username = null,
        string? additionalKey = null)
    {
        var startTime = DateTime.UtcNow;
        
        try
        {
            if (string.IsNullOrEmpty(plainText))
                return OperationResult.ErrorResult("النص فارغ", "", "EncryptText");
            
            if (string.IsNullOrEmpty(password))
                return OperationResult.ErrorResult("كلمة المرور مطلوبة", "", "EncryptText");
            
            var result = await _cryptoEngine.EncryptTextAsync(plainText, password, username, additionalKey);
            result.Duration = DateTime.UtcNow - startTime;
            
            if (result.Success && _settings.ClearClipboardAfterUse)
            {
                StartClipboardTimer();
            }
            
            return result;
        }
        catch (Exception ex)
        {
            _logger?.LogError("TextEncryptionService", "فشل في تشفير النص", ex);
            return OperationResult.ErrorResult("فشل في تشفير النص", ex.Message, "EncryptText");
        }
    }
    
    public async Task<OperationResult> DecryptTextAsync(
        string encryptedBase64,
        string password,
        string? username = null,
        string? additionalKey = null)
    {
        var startTime = DateTime.UtcNow;
        
        try
        {
            if (string.IsNullOrEmpty(encryptedBase64))
                return OperationResult.ErrorResult("النص المشفر فارغ", "", "DecryptText");
            
            if (string.IsNullOrEmpty(password))
                return OperationResult.ErrorResult("كلمة المرور مطلوبة", "", "DecryptText");
            
            var result = await _cryptoEngine.DecryptTextAsync(encryptedBase64, password, username, additionalKey);
            result.Duration = DateTime.UtcNow - startTime;
            
            if (result.Success && _settings.ClearClipboardAfterUse)
            {
                StartClipboardTimer();
            }
            
            return result;
        }
        catch (Exception ex)
        {
            _logger?.LogError("TextEncryptionService", "فشل في فك تشفير النص", ex);
            return OperationResult.ErrorResult("فشل في فك تشفير النص", ex.Message, "DecryptText");
        }
    }
    
    public async Task<string?> EncryptToBase64Async(
        string plainText,
        string password,
        string? username = null,
        string? additionalKey = null)
    {
        try
        {
            var result = await EncryptTextAsync(plainText, password, username, additionalKey);
            if (result.Success)
            {
                return result.ResultData;
            }
            return null;
        }
        catch
        {
            return null;
        }
    }
    
    public async Task<string?> DecryptFromBase64Async(
        string encryptedBase64,
        string password,
        string? username = null,
        string? additionalKey = null)
    {
        try
        {
            var result = await DecryptTextAsync(encryptedBase64, password, username, additionalKey);
            if (result.Success)
            {
                return result.ResultData;
            }
            return null;
        }
        catch
        {
            return null;
        }
    }
    
    public void CopyToClipboard(string text, bool secure = true)
    {
        try
        {
            if (secure)
            {
                // استخدام DataObject للنسخ الآمن
                var data = new DataObject();
                data.SetText(text, TextDataFormat.UnicodeText);
                Clipboard.SetDataObject(data, true);
            }
            else
            {
                Clipboard.SetText(text);
            }
            
            _logger?.LogInfo("TextEncryptionService", "تم نسخ النص إلى الحافظة");
            
            if (_settings.ClearClipboardAfterUse)
            {
                StartClipboardTimer();
            }
        }
        catch (Exception ex)
        {
            _logger?.LogError("TextEncryptionService", "فشل في نسخ النص إلى الحافظة", ex);
            throw;
        }
    }
    
    public string? GetFromClipboard(bool secure = true)
    {
        try
        {
            if (secure)
            {
                // استخدام IDataObject للقراءة الآمنة
                var dataObject = Clipboard.GetDataObject();
                if (dataObject?.GetDataPresent(DataFormats.UnicodeText) ?? false)
                {
                    return dataObject.GetData(DataFormats.UnicodeText) as string;
                }
            }
            else
            {
                return Clipboard.GetText();
            }
            
            return null;
        }
        catch (Exception ex)
        {
            _logger?.LogError("TextEncryptionService", "فشل في قراءة النص من الحافظة", ex);
            return null;
        }
    }
    
    public void ClearClipboard()
    {
        try
        {
            Clipboard.Clear();
            _logger?.LogInfo("TextEncryptionService", "تم مسح الحافظة");
        }
        catch (Exception ex)
        {
            _logger?.LogError("TextEncryptionService", "فشل في مسح الحافظة", ex);
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
            ClearClipboard();
            _clipboardTimer?.Stop();
            _clipboardTimer?.Dispose();
            _clipboardTimer = null;
        };
        _clipboardTimer.AutoReset = false;
        _clipboardTimer.Start();
        
        _logger?.LogInfo("TextEncryptionService", 
            $"بدأ مؤقت مسح الحافظة ({_settings.ClipboardTimeout} ثانية)");
    }
    
    public string GenerateRandomText(int length, bool includeSpecialChars = true)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        const string specialChars = "!@#$%^&*()-_=+[]{}|;:,.<>?";
        
        string charset = chars + (includeSpecialChars ? specialChars : "");
        
        var result = new StringBuilder(length);
        byte[] randomBytes = new byte[length];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        
        for (int i = 0; i < length; i++)
        {
            result.Append(charset[randomBytes[i] % charset.Length]);
        }
        
        return result.ToString();
    }
    
    public bool ValidateText(string text, int minLength = 1, int maxLength = int.MaxValue)
    {
        if (string.IsNullOrEmpty(text))
            return false;
        
        if (text.Length < minLength || text.Length > maxLength)
            return false;
        
        // يمكن إضافة مزيد من التحقق هنا
        return true;
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _clipboardTimer?.Stop();
                _clipboardTimer?.Dispose();
                _cryptoEngine?.Dispose();
            }
            _disposed = true;
        }
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    ~TextEncryptionService()
    {
        Dispose(false);
    }
}