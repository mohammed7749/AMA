using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using SecureDataProtectionTool.Security;
using SecureDataProtectionTool.Models;

namespace SecureDataProtectionTool.Utils;

public class SettingsManager : IDisposable
{
    private bool _disposed;
    private readonly SecureMemory? _encryptionKey;
    private readonly string _settingsPath;
    private readonly JsonSerializerOptions _jsonOptions;
    private Settings? _currentSettings;
    private readonly object _lock = new();
    
    public event EventHandler<SettingsChangedEventArgs>? SettingsChanged;
    
    public SettingsManager()
    {
        // تحديد مسار الإعدادات
        string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string appFolder = Path.Combine(appData, "SecureDataProtectionTool");
        
        if (!Directory.Exists(appFolder))
            Directory.CreateDirectory(appFolder);
        
        _settingsPath = Path.Combine(appFolder, "settings.dat");
        
        // توليد أو تحميل مفتاح التشفير
        _encryptionKey = GetOrCreateEncryptionKey(appFolder);
        
        _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
    }
    
    public Settings LoadSettings()
    {
        lock (_lock)
        {
            try
            {
                if (!File.Exists(_settingsPath))
                {
                    _currentSettings = CreateDefaultSettings();
                    SaveSettings(_currentSettings);
                    return _currentSettings;
                }
                
                byte[] encryptedData = File.ReadAllBytes(_settingsPath);
                string json = Decrypt(encryptedData, _encryptionKey!);
                
                _currentSettings = JsonSerializer.Deserialize<Settings>(json, _jsonOptions);
                
                if (_currentSettings == null)
                {
                    _currentSettings = CreateDefaultSettings();
                }
                else
                {
                    _currentSettings.Validate();
                }
                
                return _currentSettings;
            }
            catch (Exception ex)
            {
                // في حالة الخطأ، نعود للإعدادات الافتراضية
                _currentSettings = CreateDefaultSettings();
                SaveSettings(_currentSettings);
                
                var logger = new Logging.LogService();
                logger.LogError("SettingsManager", "فشل في تحميل الإعدادات، استخدام الإعدادات الافتراضية", ex);
                
                return _currentSettings;
            }
        }
    }
    
    public async Task<Settings> LoadSettingsAsync(CancellationToken cancellationToken = default)
    {
        return await Task.Run(() => LoadSettings(), cancellationToken);
    }
    
    public void SaveSettings(Settings settings)
    {
        if (settings == null)
            throw new ArgumentNullException(nameof(settings));
        
        lock (_lock)
        {
            try
            {
                settings.Validate();
                
                string json = JsonSerializer.Serialize(settings, _jsonOptions);
                byte[] encryptedData = Encrypt(json, _encryptionKey!);
                
                // الكتابة إلى ملف مؤقت أولاً
                string tempPath = _settingsPath + ".tmp";
                File.WriteAllBytes(tempPath, encryptedData);
                
                // استبدال الملف الأصلي
                File.Copy(tempPath, _settingsPath, true);
                File.Delete(tempPath);
                
                _currentSettings = settings;
                
                SettingsChanged?.Invoke(this, new SettingsChangedEventArgs(settings));
            }
            catch (Exception ex)
            {
                var logger = new Logging.LogService();
                logger.LogError("SettingsManager", "فشل في حفظ الإعدادات", ex);
                throw;
            }
        }
    }
    
    public async Task SaveSettingsAsync(Settings settings, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => SaveSettings(settings), cancellationToken);
    }
    
    public Settings CurrentSettings
    {
        get
        {
            if (_currentSettings == null)
                _currentSettings = LoadSettings();
            
            return _currentSettings;
        }
    }
    
    public void UpdateSettings(Action<Settings> updateAction)
    {
        if (updateAction == null)
            throw new ArgumentNullException(nameof(updateAction));
        
        lock (_lock)
        {
            var settings = CurrentSettings.Clone();
            updateAction(settings);
            SaveSettings(settings);
        }
    }
    
    public async Task UpdateSettingsAsync(Action<Settings> updateAction, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => UpdateSettings(updateAction), cancellationToken);
    }
    
    public void ResetToDefaults()
    {
        var defaultSettings = CreateDefaultSettings();
        SaveSettings(defaultSettings);
    }
    
    public async Task ResetToDefaultsAsync(CancellationToken cancellationToken = default)
    {
        await Task.Run(ResetToDefaults, cancellationToken);
    }
    
    public string ExportSettings()
    {
        var settings = CurrentSettings;
        return JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
    }
    
    public void ImportSettings(string json)
    {
        if (string.IsNullOrEmpty(json))
            throw new ArgumentException("بيانات JSON غير صالحة", nameof(json));
        
        var settings = JsonSerializer.Deserialize<Settings>(json, _jsonOptions);
        if (settings == null)
            throw new InvalidOperationException("فشل في تحليل إعدادات JSON");
        
        SaveSettings(settings);
    }
    
    public bool BackupSettings(string backupPath)
    {
        try
        {
            if (!File.Exists(_settingsPath))
                return false;
            
            File.Copy(_settingsPath, backupPath, true);
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public bool RestoreSettings(string backupPath)
    {
        try
        {
            if (!File.Exists(backupPath))
                return false;
            
            File.Copy(backupPath, _settingsPath, true);
            _currentSettings = null; // إجبار إعادة التحميل
            
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    private static SecureMemory GetOrCreateEncryptionKey(string appFolder)
    {
        string keyPath = Path.Combine(appFolder, "key.dat");
        
        if (File.Exists(keyPath))
        {
            try
            {
                byte[] keyBytes = File.ReadAllBytes(keyPath);
                return new SecureMemory(keyBytes);
            }
            catch
            {
                // إذا فشل تحميل المفتاح، ننشئ مفتاحاً جديداً
            }
        }
        
        // توليد مفتاح جديد
        byte[] newKey = new byte[32]; // 256-bit
        RandomNumberGenerator.Fill(newKey);
        
        var secureKey = new SecureMemory(newKey);
        
        try
        {
            File.WriteAllBytes(keyPath, newKey);
            
            // إخفاء الملف
            File.SetAttributes(keyPath, File.GetAttributes(keyPath) | FileAttributes.Hidden);
        }
        catch
        {
            // تجاهل الأخطاء في حفظ المفتاح
        }
        
        return secureKey;
    }
    
    private static Settings CreateDefaultSettings()
    {
        return new Settings
        {
            Pbkdf2Iterations = 100000,
            SaltLength = 32,
            KeySize = 256,
            UseAdditionalKey = false,
            UseUsername = false,
            AutoLockTimeout = 300,
            ClipboardTimeout = 30,
            ClearClipboardAfterUse = true,
            WipeMemoryAfterUse = true,
            AutoDeleteOriginal = false,
            WipePasses = 3,
            MinPasswordLength = 12,
            MaxPasswordLength = 24,
            IncludeUppercase = true,
            IncludeLowercase = true,
            IncludeNumbers = true,
            IncludeSymbols = true,
            ExcludeSimilar = true,
            ExcludeAmbiguous = true,
            EnableCustomCrypto = false,
            SelectedAlgorithm = "AES256",
            EnableMD5 = false,
            EnableDES = false,
            Theme = "Dark",
            Language = "ar",
            ShowToolTips = true,
            ConfirmBeforeExit = true,
            Username = Environment.UserName,
            AdditionalKey = string.Empty,
            EnableLogging = true,
            LogRetentionDays = 30,
            LogToFile = true,
            LogToDatabase = false
        };
    }
    
    private static byte[] Encrypt(string plainText, SecureMemory key)
    {
        using var aes = Aes.Create();
        aes.Key = key.GetBytes();
        aes.GenerateIV();
        
        using var encryptor = aes.CreateEncryptor();
        using var ms = new MemoryStream();
        
        ms.Write(aes.IV, 0, aes.IV.Length);
        
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs, Encoding.UTF8))
        {
            sw.Write(plainText);
        }
        
        return ms.ToArray();
    }
    
    private static string Decrypt(byte[] cipherText, SecureMemory key)
    {
        using var aes = Aes.Create();
        aes.Key = key.GetBytes();
        
        byte[] iv = new byte[16];
        Array.Copy(cipherText, 0, iv, 0, 16);
        aes.IV = iv;
        
        using var decryptor = aes.CreateDecryptor();
        using var ms = new MemoryStream(cipherText, 16, cipherText.Length - 16);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs, Encoding.UTF8);
        
        return sr.ReadToEnd();
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _encryptionKey?.Dispose();
            }
            _disposed = true;
        }
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    ~SettingsManager()
    {
        Dispose(false);
    }
}

public class SettingsChangedEventArgs : EventArgs
{
    public Settings NewSettings { get; }
    
    public SettingsChangedEventArgs(Settings newSettings)
    {
        NewSettings = newSettings ?? throw new ArgumentNullException(nameof(newSettings));
    }
}

public static class SettingsExtensions
{
    public static Settings Clone(this Settings settings)
    {
        var json = JsonSerializer.Serialize(settings);
        return JsonSerializer.Deserialize<Settings>(json)!;
    }
}