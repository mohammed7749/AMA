using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SecureDataProtectionTool.Models;
using SecureDataProtectionTool.Security;

namespace SecureDataProtectionTool.Core;

public class CryptoEngine : IDisposable
{
    private bool _disposed;
    private readonly KeyDerivationService _kdfService;
    private readonly Logging.LogService? _logger;
    private readonly Settings _settings;
    
    public CryptoEngine(KeyDerivationService kdfService, Logging.LogService? logger = null, Settings? settings = null)
    {
        _kdfService = kdfService ?? throw new ArgumentNullException(nameof(kdfService));
        _logger = logger;
        _settings = settings ?? new Settings();
    }
    
    public async Task<OperationResult> EncryptFileAsync(
        string inputFile,
        string outputFile,
        string password,
        string? username = null,
        string? additionalKey = null,
        IProgress<double>? progress = null,
        CancellationToken cancellationToken = default)
    {
        var startTime = DateTime.UtcNow;
        
        try
        {
            if (!File.Exists(inputFile))
                return OperationResult.ErrorResult("الملف غير موجود", inputFile, "EncryptFile");
            
            var fileInfo = new FileInfo(inputFile);
            if (fileInfo.Length == 0)
                return OperationResult.ErrorResult("الملف فارغ", inputFile, "EncryptFile");
            
            // توليد الملح و IV
            var (salt, iv) = _kdfService.GenerateSaltAndIV(_settings.SaltLength, 16);
            
            // اشتقاق المفتاح
            byte[] key = _kdfService.DeriveKey(
                password,
                salt,
                _settings.KeySize / 8,
                _settings.UseUsername ? username : null,
                _settings.UseAdditionalKey ? additionalKey : null,
                _settings.Pbkdf2Iterations);
            
            using var aes = Aes.Create();
            aes.KeySize = _settings.KeySize;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = key;
            aes.IV = iv;
            
            await using (var inputStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan))
            await using (var outputStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan))
            {
                // كتابة رأس التشفير
                byte[] header = EncryptionHeader.CreateHeader(
                    algorithmId: EncryptionHeader.ALG_AES256,
                    saltLength: salt.Length,
                    ivLength: iv.Length,
                    iterations: _settings.Pbkdf2Iterations);
                
                await outputStream.WriteAsync(header, cancellationToken);
                
                // كتابة الملح و IV
                await outputStream.WriteAsync(salt, cancellationToken);
                await outputStream.WriteAsync(iv, cancellationToken);
                
                // التشفير
                using (var encryptor = aes.CreateEncryptor())
                await using (var cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                {
                    long totalBytes = fileInfo.Length;
                    long bytesRead = 0;
                    byte[] buffer = new byte[81920];
                    
                    int bytes;
                    while ((bytes = await inputStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
                    {
                        await cryptoStream.WriteAsync(buffer, 0, bytes, cancellationToken);
                        bytesRead += bytes;
                        
                        if (progress != null)
                            progress.Report((double)bytesRead / totalBytes * 100);
                        
                        if (cancellationToken.IsCancellationRequested)
                        {
                            await cryptoStream.FlushAsync(cancellationToken);
                            outputStream.Close();
                            File.Delete(outputFile);
                            return OperationResult.ErrorResult("تم إلغاء العملية", inputFile, "EncryptFile");
                        }
                    }
                }
            }
            
            // تنظيف البيانات الحساسة
            Array.Clear(key, 0, key.Length);
            Array.Clear(salt, 0, salt.Length);
            Array.Clear(iv, 0, iv.Length);
            
            var duration = DateTime.UtcNow - startTime;
            
            // حذف الملف الأصلي إذا تم تحديده
            if (_settings.AutoDeleteOriginal)
            {
                await SecureDeleteFileAsync(inputFile, cancellationToken);
            }
            
            if (_logger != null)
                _logger.LogInfo("CryptoEngine", $"تم تشفير الملف: {inputFile} → {outputFile}", 
                    new System.Collections.Generic.Dictionary<string, object> { 
                        { "Size", fileInfo.Length }, 
                        { "Duration", duration } 
                    });
            
            var result = OperationResult.SuccessResult(
                $"تم تشفير الملف بنجاح ({FormatBytes(fileInfo.Length)})",
                "EncryptFile");
            
            result.FilePath = outputFile;
            result.FileSize = fileInfo.Length;
            result.Duration = duration;
            
            return result;
        }
        catch (Exception ex)
        {
            if (_logger != null)
                _logger.LogError("CryptoEngine", $"فشل في تشفير الملف: {inputFile}", ex);
            return OperationResult.ErrorResult("فشل في تشفير الملف", ex.Message, "EncryptFile");
        }
    }
    
    public async Task<OperationResult> DecryptFileAsync(
        string inputFile,
        string outputFile,
        string password,
        string? username = null,
        string? additionalKey = null,
        IProgress<double>? progress = null,
        CancellationToken cancellationToken = default)
    {
        var startTime = DateTime.UtcNow;
        
        try
        {
            if (!File.Exists(inputFile))
                return OperationResult.ErrorResult("الملف غير موجود", inputFile, "DecryptFile");
            
            await using (var inputStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan))
            {
                // قراءة الرأس
                byte[] header = new byte[EncryptionHeader.HEADER_SIZE];
                int bytesRead = await inputStream.ReadAsync(header, 0, header.Length, cancellationToken);
                
                if (bytesRead != EncryptionHeader.HEADER_SIZE || !EncryptionHeader.ValidateHeader(header))
                    return OperationResult.ErrorResult("الملف ليس ملف تشفير صالح", inputFile, "DecryptFile");
                
                // تحليل الرأس
                var headerInfo = EncryptionHeader.ParseHeader(header);
                
                // قراءة الملح و IV
                byte[] salt = new byte[headerInfo.SaltLength];
                byte[] iv = new byte[headerInfo.IvLength];
                
                await inputStream.ReadAsync(salt, 0, salt.Length, cancellationToken);
                await inputStream.ReadAsync(iv, 0, iv.Length, cancellationToken);
                
                // اشتقاق المفتاح
                byte[] key = _kdfService.DeriveKey(
                    password,
                    salt,
                    headerInfo.AlgorithmId == EncryptionHeader.ALG_AES256 ? 32 : 16,
                    username,
                    additionalKey,
                    headerInfo.Iterations);
                
                using var aes = Aes.Create();
                aes.KeySize = key.Length * 8;
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = key;
                aes.IV = iv;
                
                await using (var outputStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan))
                using (var decryptor = aes.CreateDecryptor())
                await using (var cryptoStream = new CryptoStream(inputStream, decryptor, CryptoStreamMode.Read))
                {
                    long totalBytes = new FileInfo(inputFile).Length - EncryptionHeader.HEADER_SIZE - salt.Length - iv.Length;
                    long processedBytes = 0;
                    byte[] buffer = new byte[81920];
                    
                    int bytes;
                    while ((bytes = await cryptoStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
                    {
                        await outputStream.WriteAsync(buffer, 0, bytes, cancellationToken);
                        processedBytes += bytes;
                        
                        if (progress != null)
                            progress.Report((double)processedBytes / totalBytes * 100);
                        
                        if (cancellationToken.IsCancellationRequested)
                        {
                            outputStream.Close();
                            File.Delete(outputFile);
                            return OperationResult.ErrorResult("تم إلغاء العملية", inputFile, "DecryptFile");
                        }
                    }
                }
                
                // تنظيف البيانات الحساسة
                Array.Clear(key, 0, key.Length);
                Array.Clear(salt, 0, salt.Length);
                Array.Clear(iv, 0, iv.Length);
            }
            
            var duration = DateTime.UtcNow - startTime;
            
            if (_logger != null)
                _logger.LogInfo("CryptoEngine", $"تم فك تشفير الملف: {inputFile} → {outputFile}", 
                    new System.Collections.Generic.Dictionary<string, object> { 
                        { "Size", new FileInfo(inputFile).Length }, 
                        { "Duration", duration } 
                    });
            
            var result = OperationResult.SuccessResult(
                $"تم فك تشفير الملف بنجاح ({FormatBytes(new FileInfo(inputFile).Length)})",
                "DecryptFile");
            
            result.FilePath = outputFile;
            result.FileSize = new FileInfo(inputFile).Length;
            result.Duration = duration;
            
            return result;
        }
        catch (CryptographicException ex)
        {
            if (_logger != null)
                _logger.LogError("CryptoEngine", $"فشل فك التشفير (كلمة مرور خاطئة؟): {inputFile}", ex);
            return OperationResult.ErrorResult("كلمة المرور غير صحيحة أو الملف تالف", ex.Message, "DecryptFile");
        }
        catch (Exception ex)
        {
            if (_logger != null)
                _logger.LogError("CryptoEngine", $"فشل في فك تشفير الملف: {inputFile}", ex);
            return OperationResult.ErrorResult("فشل في فك تشفير الملف", ex.Message, "DecryptFile");
        }
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
            
            var (salt, iv) = _kdfService.GenerateSaltAndIV(_settings.SaltLength, 16);
            
            byte[] key = _kdfService.DeriveKey(
                password,
                salt,
                _settings.KeySize / 8,
                _settings.UseUsername ? username : null,
                _settings.UseAdditionalKey ? additionalKey : null,
                _settings.Pbkdf2Iterations);
            
            using var aes = Aes.Create();
            aes.KeySize = _settings.KeySize;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = key;
            aes.IV = iv;
            
            using var encryptor = aes.CreateEncryptor();
            using var ms = new MemoryStream();
            
            // كتابة الملح و IV
            await ms.WriteAsync(salt, 0, salt.Length);
            await ms.WriteAsync(iv, 0, iv.Length);
            
            // التشفير
            using (var cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            using (var sw = new StreamWriter(cryptoStream, Encoding.UTF8))
            {
                await sw.WriteAsync(plainText);
                await sw.FlushAsync();
            }
            
            string encryptedBase64 = Convert.ToBase64String(ms.ToArray());
            
            // تنظيف البيانات الحساسة
            Array.Clear(key, 0, key.Length);
            Array.Clear(salt, 0, salt.Length);
            Array.Clear(iv, 0, iv.Length);
            
            var duration = DateTime.UtcNow - startTime;
            
            if (_logger != null)
                _logger.LogInfo("CryptoEngine", "تم تشفير النص بنجاح", 
                    new System.Collections.Generic.Dictionary<string, object> { 
                        { "TextLength", plainText.Length },
                        { "Duration", duration }
                    });
            
            var result = OperationResult.SuccessResultWithData(
                "تم تشفير النص بنجاح", 
                encryptedBase64,
                "EncryptText");
            
            result.FileSize = plainText.Length;
            result.Duration = duration;
            
            return result;
        }
        catch (Exception ex)
        {
            if (_logger != null)
                _logger.LogError("CryptoEngine", "فشل في تشفير النص", ex);
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
            byte[] encryptedBytes = Convert.FromBase64String(encryptedBase64);
            
            if (encryptedBytes.Length < 48) // salt(32) + iv(16) كحد أدنى
                return OperationResult.ErrorResult("نص مشفر غير صالح", "", "DecryptText");
            
            using var ms = new MemoryStream(encryptedBytes);
            
            // قراءة الملح و IV
            byte[] salt = new byte[_settings.SaltLength];
            byte[] iv = new byte[16];
            
            await ms.ReadAsync(salt, 0, salt.Length);
            await ms.ReadAsync(iv, 0, iv.Length);
            
            // اشتقاق المفتاح
            byte[] key = _kdfService.DeriveKey(
                password,
                salt,
                _settings.KeySize / 8,
                username,
                additionalKey,
                _settings.Pbkdf2Iterations);
            
            using var aes = Aes.Create();
            aes.KeySize = _settings.KeySize;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = key;
            aes.IV = iv;
            
            using var decryptor = aes.CreateDecryptor();
            using var cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cryptoStream, Encoding.UTF8);
            
            string decryptedText = await sr.ReadToEndAsync();
            
            // تنظيف البيانات الحساسة
            Array.Clear(key, 0, key.Length);
            Array.Clear(salt, 0, salt.Length);
            Array.Clear(iv, 0, iv.Length);
            
            var duration = DateTime.UtcNow - startTime;
            
            if (_logger != null)
                _logger.LogInfo("CryptoEngine", "تم فك تشفير النص بنجاح", 
                    new System.Collections.Generic.Dictionary<string, object> { 
                        { "TextLength", decryptedText.Length },
                        { "Duration", duration }
                    });
            
            var result = OperationResult.SuccessResultWithData(
                "تم فك تشفير النص بنجاح", 
                decryptedText,
                "DecryptText");
            
            result.FileSize = decryptedText.Length;
            result.Duration = duration;
            
            return result;
        }
        catch (CryptographicException ex)
        {
            if (_logger != null)
                _logger.LogError("CryptoEngine", "فشل فك تشفير النص (كلمة مرور خاطئة؟)", ex);
            return OperationResult.ErrorResult("كلمة المرور غير صحيحة", ex.Message, "DecryptText");
        }
        catch (Exception ex)
        {
            if (_logger != null)
                _logger.LogError("CryptoEngine", "فشل في فك تشفير النص", ex);
            return OperationResult.ErrorResult("فشل في فك تشفير النص", ex.Message, "DecryptText");
        }
    }
    
    public async Task<EncryptionMetadata?> GetFileMetadataAsync(string filePath)
    {
        try
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous))
            {
                byte[] header = new byte[EncryptionHeader.HEADER_SIZE];
                int bytesRead = await stream.ReadAsync(header, 0, header.Length);
                
                if (bytesRead != EncryptionHeader.HEADER_SIZE || !EncryptionHeader.ValidateHeader(header))
                    return null;
                
                var headerInfo = EncryptionHeader.ParseHeader(header);
                var fileInfo = new FileInfo(filePath);
                
                return new EncryptionMetadata
                {
                    Algorithm = headerInfo.AlgorithmName,
                    Mode = headerInfo.ModeName,
                    KeySize = headerInfo.AlgorithmId == EncryptionHeader.ALG_AES256 ? 256 : 128,
                    BlockSize = 128,
                    KdfType = headerInfo.KdfName,
                    Iterations = headerInfo.Iterations,
                    SaltLength = headerInfo.SaltLength,
                    EncryptionTime = fileInfo.CreationTimeUtc,
                    Version = headerInfo.Version.ToString(),
                    OriginalFileName = Path.GetFileNameWithoutExtension(filePath),
                    OriginalFileSize = fileInfo.Length - EncryptionHeader.HEADER_SIZE - headerInfo.SaltLength - headerInfo.IvLength
                };
            }
        }
        catch
        {
            return null;
        }
    }
    
    private async Task SecureDeleteFileAsync(string filePath, CancellationToken cancellationToken)
    {
        try
        {
            var fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
                return;
            
            long fileSize = fileInfo.Length;
            
            // الكتابة فوق الملف عدة مرات
            byte[] randomData = new byte[81920];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomData);
            }
            
            for (int pass = 0; pass < _settings.WipePasses; pass++)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;
                
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.None, 4096, FileOptions.Asynchronous))
                {
                    for (long position = 0; position < fileSize; position += randomData.Length)
                    {
                        if (cancellationToken.IsCancellationRequested)
                            break;
                        
                        int bytesToWrite = (int)Math.Min(randomData.Length, fileSize - position);
                        await fs.WriteAsync(randomData, 0, bytesToWrite, cancellationToken);
                    }
                    
                    await fs.FlushAsync(cancellationToken);
                }
                
                // بيانات مختلفة لكل دورة
                if (pass < _settings.WipePasses - 1)
                {
                    using (var rng = RandomNumberGenerator.Create())
                    {
                        rng.GetBytes(randomData);
                    }
                }
            }
            
            Array.Clear(randomData, 0, randomData.Length);
            fileInfo.Delete();
            
            if (_logger != null)
                _logger.LogInfo("CryptoEngine", $"تم الحذف الآمن للملف: {filePath}", 
                    new System.Collections.Generic.Dictionary<string, object> { 
                        { "Passes", _settings.WipePasses }, 
                        { "Size", fileSize } 
                    });
        }
        catch (Exception ex)
        {
            if (_logger != null)
                _logger.LogError("CryptoEngine", $"فشل في الحذف الآمن للملف: {filePath}", ex);
            // استمرار في الحذف العادي
            try { File.Delete(filePath); } catch { }
        }
    }
    
    private static string FormatBytes(long bytes)
    {
        string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
        int counter = 0;
        decimal number = bytes;
        
        while (Math.Round(number / 1024) >= 1)
        {
            number /= 1024;
            counter++;
        }
        
        return $"{number:N2} {suffixes[counter]}";
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _kdfService?.Dispose();
            }
            _disposed = true;
        }
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    ~CryptoEngine()
    {
        Dispose(false);
    }
}