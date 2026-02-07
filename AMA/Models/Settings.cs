using System.Text.Json.Serialization;

namespace SecureDataProtectionTool.Models;

public class Settings
{
    // Encryption Settings
    public int Pbkdf2Iterations { get; set; } = 100000;
    public int SaltLength { get; set; } = 32;
    public int KeySize { get; set; } = 256;
    public bool UseAdditionalKey { get; set; } = false;
    public bool UseUsername { get; set; } = false;
    
    // Security Settings
    public int AutoLockTimeout { get; set; } = 300; // 5 دقائق
    public int ClipboardTimeout { get; set; } = 30; // 30 ثانية
    public bool ClearClipboardAfterUse { get; set; } = true;
    public bool WipeMemoryAfterUse { get; set; } = true;
    public bool AutoDeleteOriginal { get; set; } = false;
    public int WipePasses { get; set; } = 3;
    
    // إضافة الخصائص المفقودة
    public bool AutoLockEnabled { get; set; } = false;
    public int AutoLockMinutes { get; set; } = 5;
    public bool ConfirmBeforeExit { get; set; } = true;
    public bool ConfirmExit => ConfirmBeforeExit; // لتوافق الكود الحالي
    
    // Password Generation Settings
    public int MinPasswordLength { get; set; } = 12;
    public int MaxPasswordLength { get; set; } = 24;
    public bool IncludeUppercase { get; set; } = true;
    public bool IncludeLowercase { get; set; } = true;
    public bool IncludeNumbers { get; set; } = true;
    public bool IncludeSymbols { get; set; } = true;
    public bool ExcludeSimilar { get; set; } = true;
    public bool ExcludeAmbiguous { get; set; } = true;
    
    // Custom Cryptography Settings
    public bool EnableCustomCrypto { get; set; } = false;
    public string SelectedAlgorithm { get; set; } = "AES256";
    public bool EnableMD5 { get; set; } = false;
    public bool EnableDES { get; set; } = false;
    
    // UI Settings
    public string Theme { get; set; } = "Dark";
    public string Language { get; set; } = "ar";
    public bool ShowToolTips { get; set; } = true;
    
    // User Information
    public string Username { get; set; } = string.Empty;
    public string AdditionalKey { get; set; } = string.Empty;
    
    // Logging Settings
    public bool EnableLogging { get; set; } = true;
    public int LogRetentionDays { get; set; } = 30;
    public bool LogToFile { get; set; } = true;
    public bool LogToDatabase { get; set; } = false;
    
    [JsonIgnore]
    public bool IsValid => Pbkdf2Iterations >= 10000 && SaltLength >= 16;
    
    public void Validate()
    {
        if (Pbkdf2Iterations < 10000)
            Pbkdf2Iterations = 10000;
        if (SaltLength < 16)
            SaltLength = 16;
        if (MinPasswordLength < 8)
            MinPasswordLength = 8;
        if (MaxPasswordLength < MinPasswordLength)
            MaxPasswordLength = MinPasswordLength + 8;
        if (ClipboardTimeout < 5)
            ClipboardTimeout = 5;
        if (AutoLockMinutes < 1)
            AutoLockMinutes = 1;
        if (AutoLockMinutes > 60)
            AutoLockMinutes = 60;
    }
}