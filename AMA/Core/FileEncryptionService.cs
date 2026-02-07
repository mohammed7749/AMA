using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SecureDataProtectionTool.Models;
using SecureDataProtectionTool.Security;
using SecureDataProtectionTool.Utils;

namespace SecureDataProtectionTool.Core;

public class FileEncryptionService : IDisposable
{
    private bool _disposed;
    private readonly CryptoEngine _cryptoEngine;
    private readonly Logging.LogService? _logger;
    private readonly Settings _settings;
    
    public FileEncryptionService(CryptoEngine cryptoEngine, Logging.LogService? logger = null, Settings? settings = null)
    {
        _cryptoEngine = cryptoEngine ?? throw new ArgumentNullException(nameof(cryptoEngine));
        _logger = logger;
        _settings = settings ?? new Settings();
    }
    
    public async Task<OperationResult> EncryptFileAsync(
        string inputPath,
        string outputPath,
        string password,
        string? username = null,
        string? additionalKey = null,
        IProgress<double>? progress = null,
        CancellationToken cancellationToken = default)
    {
        var startTime = DateTime.UtcNow;
        
        try
        {
            // التحقق من وجود الملف
            if (!File.Exists(inputPath) && !Directory.Exists(inputPath))
                return OperationResult.ErrorResult("المسار غير موجود", inputPath, "EncryptFile");
            
            // إذا كان مجلدًا، تشفير جميع الملفات داخله
            if (Directory.Exists(inputPath))
            {
                return await EncryptDirectoryAsync(inputPath, outputPath, password, username, additionalKey, progress, cancellationToken);
            }
            
            // إذا كان ملفًا واحدًا
            return await _cryptoEngine.EncryptFileAsync(inputPath, outputPath, password, username, additionalKey, progress: progress, cancellationToken);
        }
        catch (Exception ex)
        {
            if (_logger != null)
                _logger.LogError("FileEncryptionService", $"فشل في تشفير الملف: {inputPath}", ex);
            return OperationResult.ErrorResult("فشل في تشفير الملف", ex.Message, "EncryptFile");
        }
    }
    
    public async Task<OperationResult> DecryptFileAsync(
        string inputPath,
        string outputPath,
        string password,
        string? username = null,
        string? additionalKey = null,
        IProgress<double>? progress = null,
        CancellationToken cancellationToken = default)
    {
        var startTime = DateTime.UtcNow;
        
        try
        {
            // التحقق من وجود الملف
            if (!File.Exists(inputPath) && !Directory.Exists(inputPath))
                return OperationResult.ErrorResult("المسار غير موجود", inputPath, "DecryptFile");
            
            // إذا كان مجلدًا، فك تشفير جميع الملفات داخله
            if (Directory.Exists(inputPath))
            {
                return await DecryptDirectoryAsync(inputPath, outputPath, password, username, additionalKey, progress, cancellationToken);
            }
            
            // إذا كان ملفًا واحدًا
            return await _cryptoEngine.DecryptFileAsync(inputPath, outputPath, password, username, additionalKey, progress: progress, cancellationToken);
        }
        catch (Exception ex)
        {
            if (_logger != null)
                _logger.LogError("FileEncryptionService", $"فشل في فك تشفير الملف: {inputPath}", ex);
            return OperationResult.ErrorResult("فشل في فك تشفير الملف", ex.Message, "DecryptFile");
        }
    }
    
    private async Task<OperationResult> EncryptDirectoryAsync(
        string inputDir,
        string outputDir,
        string password,
        string? username,
        string? additionalKey,
        IProgress<double>? progress,
        CancellationToken cancellationToken)
    {
        try
        {
            // إنشاء مجلد الإخراج إذا لم يكن موجودًا
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);
            
            // الحصول على جميع الملفات
            var files = Directory.GetFiles(inputDir, "*", SearchOption.AllDirectories);
            int totalFiles = files.Length;
            int processedFiles = 0;
            
            var results = new List<OperationResult>();
            
            foreach (var file in files)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;
                
                // حساب المسار النسبي
                string relativePath = GetRelativePath(inputDir, file);
                string outputFile = Path.Combine(outputDir, relativePath + ".encrypted");
                
                // إنشاء المجلدات الفرعية إذا لزم الأمر
                string? outputFolder = Path.GetDirectoryName(outputFile);
                if (!string.IsNullOrEmpty(outputFolder) && !Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);
                
                // تشفير الملف
                var result = await _cryptoEngine.EncryptFileAsync(
                    file, outputFile, password, username, additionalKey, progress: null, cancellationToken);
                
                results.Add(result);
                processedFiles++;
                
                if (progress != null)
                    progress.Report((double)processedFiles / totalFiles * 100);
                
                if (_logger != null)
                    _logger.LogInfo("FileEncryptionService", 
                        $"تم تشفير الملف: {relativePath} ({result.Success})");
            }
            
            int successCount = results.Count(r => r.Success);
            int failCount = results.Count(r => !r.Success);
            
            var operationResult = OperationResult.SuccessResult(
                $"تم تشفير {successCount} ملف بنجاح، فشل {failCount} ملف",
                "EncryptDirectory");
            
            operationResult.FileSize = results.Sum(r => r.FileSize);
            
            return operationResult;
        }
        catch (Exception ex)
        {
            if (_logger != null)
                _logger.LogError("FileEncryptionService", $"فشل في تشفير المجلد: {inputDir}", ex);
            return OperationResult.ErrorResult("فشل في تشفير المجلد", ex.Message, "EncryptDirectory");
        }
    }
    
    private async Task<OperationResult> DecryptDirectoryAsync(
        string inputDir,
        string outputDir,
        string password,
        string? username,
        string? additionalKey,
        IProgress<double>? progress,
        CancellationToken cancellationToken)
    {
        try
        {
            // إنشاء مجلد الإخراج إذا لم يكن موجودًا
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);
            
            // الحصول على جميع الملفات المشفرة
            var files = Directory.GetFiles(inputDir, "*.encrypted", SearchOption.AllDirectories);
            int totalFiles = files.Length;
            int processedFiles = 0;
            
            var results = new List<OperationResult>();
            
            foreach (var file in files)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;
                
                // حساب المسار النسبي وإزالة الامتداد
                string relativePath = GetRelativePath(inputDir, file);
                if (relativePath.EndsWith(".encrypted", StringComparison.OrdinalIgnoreCase))
                    relativePath = relativePath.Substring(0, relativePath.Length - ".encrypted".Length);
                
                string outputFile = Path.Combine(outputDir, relativePath);
                
                // إنشاء المجلدات الفرعية إذا لزم الأمر
                string? outputFolder = Path.GetDirectoryName(outputFile);
                if (!string.IsNullOrEmpty(outputFolder) && !Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);
                
                // فك تشفير الملف
                var result = await _cryptoEngine.DecryptFileAsync(
                    file, outputFile, password, username, additionalKey, progress: null, cancellationToken);
                
                results.Add(result);
                processedFiles++;
                
                if (progress != null)
                    progress.Report((double)processedFiles / totalFiles * 100);
                
                if (_logger != null)
                    _logger.LogInfo("FileEncryptionService", 
                        $"تم فك تشفير الملف: {relativePath} ({result.Success})");
            }
            
            int successCount = results.Count(r => r.Success);
            int failCount = results.Count(r => !r.Success);
            
            var operationResult = OperationResult.SuccessResult(
                $"تم فك تشفير {successCount} ملف بنجاح، فشل {failCount} ملف",
                "DecryptDirectory");
            
            operationResult.FileSize = results.Sum(r => r.FileSize);
            
            return operationResult;
        }
        catch (Exception ex)
        {
            if (_logger != null)
                _logger.LogError("FileEncryptionService", $"فشل في فك تشفير المجلد: {inputDir}", ex);
            return OperationResult.ErrorResult("فشل في فك تشفير المجلد", ex.Message, "DecryptDirectory");
        }
    }
    
    private string GetRelativePath(string basePath, string fullPath)
    {
        if (!fullPath.StartsWith(basePath, StringComparison.OrdinalIgnoreCase))
            return fullPath;
        
        return fullPath.Substring(basePath.Length).TrimStart(Path.DirectorySeparatorChar);
    }
    
    public async Task<OperationResult> BatchProcessAsync(
        IEnumerable<string> inputFiles,
        string outputDir,
        string password,
        bool encrypt,
        string? username = null,
        string? additionalKey = null,
        IProgress<(int Current, int Total, string FileName)>? progress = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var files = inputFiles.ToList();
            int totalFiles = files.Count;
            int processedFiles = 0;
            int successCount = 0;
            
            // إنشاء مجلد الإخراج إذا لم يكن موجودًا
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);
            
            foreach (var inputFile in files)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;
                
                try
                {
                    string fileName = Path.GetFileName(inputFile);
                    string outputFile = Path.Combine(outputDir, 
                        encrypt ? fileName + ".encrypted" : Path.GetFileNameWithoutExtension(fileName));
                    
                    OperationResult result;
                    
                    if (encrypt)
                    {
                        result = await _cryptoEngine.EncryptFileAsync(
                            inputFile, outputFile, password, username, additionalKey, 
                            progress: null, cancellationToken);
                    }
                    else
                    {
                        result = await _cryptoEngine.DecryptFileAsync(
                            inputFile, outputFile, password, username, additionalKey, 
                            progress: null, cancellationToken);
                    }
                    
                    if (result.Success)
                        successCount++;
                    
                    processedFiles++;
                    if (progress != null)
                        progress.Report((processedFiles, totalFiles, fileName));
                    
                    if (_logger != null)
                        _logger.LogInfo("FileEncryptionService", 
                            $"{(encrypt ? "تم تشفير" : "تم فك تشفير")} الملف: {fileName} ({result.Success})");
                }
                catch (Exception ex)
                {
                    if (_logger != null)
                        _logger.LogError("FileEncryptionService", 
                            $"فشل في معالجة الملف: {inputFile}", ex);
                    processedFiles++;
                    if (progress != null)
                        progress.Report((processedFiles, totalFiles, Path.GetFileName(inputFile) + " - فشل"));
                }
            }
            
            return OperationResult.SuccessResult(
                $"تم معالجة {successCount} من {totalFiles} ملف بنجاح",
                encrypt ? "BatchEncrypt" : "BatchDecrypt");
        }
        catch (Exception ex)
        {
            if (_logger != null)
                _logger.LogError("FileEncryptionService", "فشل في المعالجة الجماعية", ex);
            return OperationResult.ErrorResult("فشل في المعالجة الجماعية", ex.Message, 
                encrypt ? "BatchEncrypt" : "BatchDecrypt");
        }
    }
    
    public EncryptionMetadata? GetFileMetadata(string filePath)
    {
        try
        {
            return _cryptoEngine.GetFileMetadataAsync(filePath).GetAwaiter().GetResult();
        }
        catch
        {
            return null;
        }
    }
    
    public async Task<EncryptionMetadata?> GetFileMetadataAsync(string filePath)
    {
        try
        {
            return await _cryptoEngine.GetFileMetadataAsync(filePath);
        }
        catch
        {
            return null;
        }
    }
    
    public bool IsEncryptedFile(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                return false;
            
            var fileInfo = new FileInfo(filePath);
            if (fileInfo.Length < 100) // ملف صغير جداً لا يمكن أن يكون مشفراً
                return false;
            
            // تحقق سريع باستخدام Magic Bytes
            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 16, FileOptions.SequentialScan);
            byte[] header = new byte[16];
            int bytesRead = fs.Read(header, 0, 16);
            
            if (bytesRead < 16)
                return false;
            
            // تحقق من Magic Bytes "SDPT"
            return header[0] == 0x53 && header[1] == 0x44 && header[2] == 0x50 && header[3] == 0x54;
        }
        catch
        {
            return false;
        }
    }
    
    // طرق مساعدة جديدة من FileUtils
    public void SecureDeleteFile(string filePath, int passes = 3)
    {
        try
        {
            FileUtils.SecureDelete(filePath, passes);
            _logger?.LogInfo("FileEncryptionService", $"تم الحذف الآمن للملف: {filePath}");
        }
        catch (Exception ex)
        {
            _logger?.LogError("FileEncryptionService", "فشل في الحذف الآمن للملف", ex);
        }
    }
    
    public async Task SecureDeleteFileAsync(string filePath, int passes = 3, CancellationToken cancellationToken = default)
    {
        try
        {
            await FileUtils.SecureDeleteAsync(filePath, passes, cancellationToken);
            _logger?.LogInfo("FileEncryptionService", $"تم الحذف الآمن للملف: {filePath}");
        }
        catch (Exception ex)
        {
            _logger?.LogError("FileEncryptionService", "فشل في الحذف الآمن للملف", ex);
        }
    }
    
    public long GetFileSize(string filePath)
    {
        return FileUtils.GetFileSize(filePath);
    }
    
    public async Task<long> GetFileSizeAsync(string filePath)
    {
        return await FileUtils.GetFileSizeAsync(filePath);
    }
    
    public string GetFileSizeHumanReadable(string filePath)
    {
        return FileUtils.GetFileSizeHumanReadable(filePath);
    }
    
    public async Task<string> GetFileSizeHumanReadableAsync(string filePath)
    {
        return await FileUtils.GetFileSizeHumanReadableAsync(filePath);
    }
    
    public string CalculateFileChecksum(string filePath, Security.HashAlgorithmType algorithmType = Security.HashAlgorithmType.SHA256)
    {
        return FileUtils.CalculateFileChecksum(filePath, algorithmType);
    }
    
    public async Task<string> CalculateFileChecksumAsync(string filePath, Security.HashAlgorithmType algorithmType = Security.HashAlgorithmType.SHA256)
    {
        return await FileUtils.CalculateFileChecksumAsync(filePath, algorithmType);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
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
    
    ~FileEncryptionService()
    {
        Dispose(false);
    }
}