using System.Security.Cryptography;
using System.Text;

namespace SecureDataProtectionTool.Utils;

public static class FileUtils
{
    public static bool IsFileLocked(string filePath)
    {
        try
        {
            using var stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            return false;
        }
        catch (IOException)
        {
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public static async Task<bool> IsFileLockedAsync(string filePath)
    {
        try
        {
            await using var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None, 
                4096, FileOptions.Asynchronous);
            return false;
        }
        catch (IOException)
        {
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public static long GetFileSize(string filePath)
    {
        try
        {
            return new FileInfo(filePath).Length;
        }
        catch
        {
            return 0;
        }
    }
    
    public static async Task<long> GetFileSizeAsync(string filePath)
    {
        try
        {
            var fileInfo = new FileInfo(filePath);
            await Task.Run(() => fileInfo.Refresh());
            return fileInfo.Length;
        }
        catch
        {
            return 0;
        }
    }
    
    public static string GetFileSizeHumanReadable(string filePath)
    {
        try
        {
            long bytes = GetFileSize(filePath);
            return FormatBytes(bytes);
        }
        catch
        {
            return "0 B";
        }
    }
    
    public static async Task<string> GetFileSizeHumanReadableAsync(string filePath)
    {
        try
        {
            long bytes = await GetFileSizeAsync(filePath);
            return FormatBytes(bytes);
        }
        catch
        {
            return "0 B";
        }
    }
    
    public static string FormatBytes(long bytes)
    {
        string[] suffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
        if (bytes == 0)
            return "0 B";
        
        int magnitude = (int)Math.Log(bytes, 1024);
        double adjustedSize = bytes / Math.Pow(1024, magnitude);
        
        return $"{adjustedSize:N2} {suffixes[magnitude]}";
    }
    
    public static async Task SecureDeleteAsync(string filePath, int passes = 3, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(filePath))
            return;
        
        string tempPath = Path.GetTempFileName();
        
        try
        {
            long fileSize = new FileInfo(filePath).Length;
            
            for (int pass = 0; pass < passes; pass++)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;
                
                await using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.None, 
                    4096, FileOptions.Asynchronous | FileOptions.SequentialScan);
                
                byte[] randomData = new byte[81920];
                RandomNumberGenerator.Fill(randomData);
                
                for (long position = 0; position < fileSize; position += randomData.Length)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;
                    
                    int bytesToWrite = (int)Math.Min(randomData.Length, fileSize - position);
                    await fs.WriteAsync(randomData.AsMemory(0, bytesToWrite), cancellationToken);
                }
                
                await fs.FlushAsync(cancellationToken);
                
                // بيانات مختلفة لكل دورة
                if (pass < passes - 1)
                {
                    RandomNumberGenerator.Fill(randomData);
                }
                
                Array.Clear(randomData);
            }
        }
        finally
        {
            try
            {
                File.Delete(filePath);
            }
            catch
            {
                // تجاهل الأخطاء في الحذف
            }
        }
    }
    
    public static void SecureDelete(string filePath, int passes = 3)
    {
        if (!File.Exists(filePath))
            return;
        
        try
        {
            long fileSize = new FileInfo(filePath).Length;
            Random random = new();
            
            for (int pass = 0; pass < passes; pass++)
            {
                using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.None);
                
                for (long position = 0; position < fileSize; position += 1024)
                {
                    byte[] buffer = new byte[1024];
                    random.NextBytes(buffer);
                    
                    int bytesToWrite = (int)Math.Min(buffer.Length, fileSize - position);
                    fs.Write(buffer, 0, bytesToWrite);
                }
            }
        }
        finally
        {
            try
            {
                File.Delete(filePath);
            }
            catch
            {
                // تجاهل الأخطاء في الحذف
            }
        }
    }
    
    public static bool IsValidPath(string path)
    {
        try
        {
            Path.GetFullPath(path);
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public static string SanitizeFileName(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
            return fileName;
        
        var invalidChars = Path.GetInvalidFileNameChars();
        foreach (char invalidChar in invalidChars)
        {
            fileName = fileName.Replace(invalidChar, '_');
        }
        
        // تقييد الطول
        if (fileName.Length > 255)
        {
            string extension = Path.GetExtension(fileName);
            string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            nameWithoutExtension = nameWithoutExtension[..(255 - extension.Length)];
            fileName = nameWithoutExtension + extension;
        }
        
        return fileName;
    }
    
    public static string SanitizeFilePath(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            return filePath;
        
        try
        {
            // تحقق من أن المسار صالح
            string fullPath = Path.GetFullPath(filePath);
            
            // تنظيف المسار من الأحرف غير الصالحة
            char[] invalidChars = Path.GetInvalidPathChars();
            foreach (char invalidChar in invalidChars)
            {
                fullPath = fullPath.Replace(invalidChar, '_');
            }
            
            // تنظيف اسم الملف من الأحرف غير الصالحة
            string directory = Path.GetDirectoryName(fullPath) ?? "";
            string fileName = Path.GetFileName(fullPath);
            
            if (!string.IsNullOrEmpty(fileName))
            {
                char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
                foreach (char invalidChar in invalidFileNameChars)
                {
                    fileName = fileName.Replace(invalidChar, '_');
                }
            }
            
            // إعادة بناء المسار
            if (!string.IsNullOrEmpty(directory) && !string.IsNullOrEmpty(fileName))
            {
                return Path.Combine(directory, fileName);
            }
            else if (!string.IsNullOrEmpty(fileName))
            {
                return fileName;
            }
            else
            {
                return directory;
            }
        }
        catch (Exception)
        {
            // إذا فشل تنظيف المسار، ارجع المسار الأصلي بعد استبدال الأحرف غير الصالحة
            char[] invalidChars = Path.GetInvalidPathChars().Concat(Path.GetInvalidFileNameChars()).Distinct().ToArray();
            string sanitizedPath = filePath;
            
            foreach (char invalidChar in invalidChars)
            {
                sanitizedPath = sanitizedPath.Replace(invalidChar, '_');
            }
            
            return sanitizedPath;
        }
    }
    
    public static string GetSafeTempFilePath(string extension = ".tmp")
    {
        string tempPath = Path.GetTempPath();
        string fileName = Guid.NewGuid().ToString() + extension;
        return Path.Combine(tempPath, fileName);
    }
    
    public static async Task<string> CalculateFileChecksumAsync(string filePath, SecureDataProtectionTool.Security.HashAlgorithmType algorithmType = SecureDataProtectionTool.Security.HashAlgorithmType.SHA256)
    {
        return await Security.IntegrityValidator.CalculateFileHashAsync(filePath, algorithmType);
    }
    
    public static string CalculateFileChecksum(string filePath, SecureDataProtectionTool.Security.HashAlgorithmType algorithmType = SecureDataProtectionTool.Security.HashAlgorithmType.SHA256)
    {
        return Security.IntegrityValidator.CalculateFileHash(filePath, algorithmType);
    }
    
    public static bool CompareFiles(string file1, string file2)
    {
        if (!File.Exists(file1) || !File.Exists(file2))
            return false;
        
        if (GetFileSize(file1) != GetFileSize(file2))
            return false;
        
        string hash1 = CalculateFileChecksum(file1);
        string hash2 = CalculateFileChecksum(file2);
        
        return hash1 == hash2;
    }
    
    public static async Task<bool> CompareFilesAsync(string file1, string file2)
    {
        if (!File.Exists(file1) || !File.Exists(file2))
            return false;
        
        var size1 = await GetFileSizeAsync(file1);
        var size2 = await GetFileSizeAsync(file2);
        
        if (size1 != size2)
            return false;
        
        var hash1 = await CalculateFileChecksumAsync(file1);
        var hash2 = await CalculateFileChecksumAsync(file2);
        
        return hash1 == hash2;
    }
    
    public static void EnsureDirectoryExists(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }
    
    public static string GetUniqueFileName(string directory, string fileName)
    {
        string baseName = Path.GetFileNameWithoutExtension(fileName);
        string extension = Path.GetExtension(fileName);
        string fullPath = Path.Combine(directory, fileName);
        
        int counter = 1;
        while (File.Exists(fullPath))
        {
            fileName = $"{baseName} ({counter}){extension}";
            fullPath = Path.Combine(directory, fileName);
            counter++;
        }
        
        return fullPath;
    }
    
    public static IEnumerable<string> EnumerateFilesSafe(string path, string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        try
        {
            return Directory.EnumerateFiles(path, searchPattern, searchOption);
        }
        catch
        {
            return Enumerable.Empty<string>();
        }
    }
}