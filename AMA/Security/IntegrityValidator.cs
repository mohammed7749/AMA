using System.Security.Cryptography;
using System.Text;

namespace SecureDataProtectionTool.Security;

public static class IntegrityValidator
{
    public static string CalculateFileHash(string filePath, HashAlgorithmType algorithmType = HashAlgorithmType.SHA256)
    {
        using var stream = File.OpenRead(filePath);
        return CalculateStreamHash(stream, algorithmType);
    }
    
    public static async Task<string> CalculateFileHashAsync(string filePath, HashAlgorithmType algorithmType = HashAlgorithmType.SHA256, 
        CancellationToken cancellationToken = default)
    {
        await using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 
            4096, FileOptions.Asynchronous | FileOptions.SequentialScan);
        return await CalculateStreamHashAsync(stream, algorithmType, cancellationToken);
    }
    
    public static string CalculateStreamHash(Stream stream, HashAlgorithmType algorithmType)
    {
        using var algorithm = GetHashAlgorithm(algorithmType);
        byte[] hash = algorithm.ComputeHash(stream);
        return BytesToHex(hash);
    }
    
    public static async Task<string> CalculateStreamHashAsync(Stream stream, HashAlgorithmType algorithmType, 
        CancellationToken cancellationToken = default)
    {
        using var algorithm = GetHashAlgorithm(algorithmType);
        byte[] hash = await algorithm.ComputeHashAsync(stream, cancellationToken);
        return BytesToHex(hash);
    }
    
    public static string CalculateStringHash(string input, HashAlgorithmType algorithmType)
    {
        using var algorithm = GetHashAlgorithm(algorithmType);
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        using var memoryStream = new MemoryStream(inputBytes);
        byte[] hash = algorithm.ComputeHash(memoryStream);
        return BytesToHex(hash);
    }
    
    public static async Task<string> CalculateStringHashAsync(string input, HashAlgorithmType algorithmType, 
        CancellationToken cancellationToken = default)
    {
        using var algorithm = GetHashAlgorithm(algorithmType);
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        using var memoryStream = new MemoryStream(inputBytes);
        byte[] hash = await algorithm.ComputeHashAsync(memoryStream, cancellationToken);
        return BytesToHex(hash);
    }
    
    public static byte[] CalculateHashBytes(string input, HashAlgorithmType algorithmType)
    {
        using var algorithm = GetHashAlgorithm(algorithmType);
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        using var memoryStream = new MemoryStream(inputBytes);
        return algorithm.ComputeHash(memoryStream);
    }
    
    private static HashAlgorithm GetHashAlgorithm(HashAlgorithmType type)
    {
        return type switch
        {
            HashAlgorithmType.MD5 => MD5.Create(),
            HashAlgorithmType.SHA1 => SHA1.Create(),
            HashAlgorithmType.SHA256 => SHA256.Create(),
            HashAlgorithmType.SHA384 => SHA384.Create(),
            HashAlgorithmType.SHA512 => SHA512.Create(),
            _ => throw new ArgumentException("نوع خوارزمية التجزئة غير معروف")
        };
    }
    
    public static bool VerifyFileHash(string filePath, string expectedHash, HashAlgorithmType algorithmType)
    {
        string actualHash = CalculateFileHash(filePath, algorithmType);
        return CompareHashes(actualHash, expectedHash);
    }
    
    public static async Task<bool> VerifyFileHashAsync(string filePath, string expectedHash, 
        HashAlgorithmType algorithmType, CancellationToken cancellationToken = default)
    {
        string actualHash = await CalculateFileHashAsync(filePath, algorithmType, cancellationToken);
        return CompareHashes(actualHash, expectedHash);
    }
    
    public static bool VerifyStringHash(string input, string expectedHash, HashAlgorithmType algorithmType)
    {
        string actualHash = CalculateStringHash(input, algorithmType);
        return CompareHashes(actualHash, expectedHash);
    }
    
    public static async Task<bool> VerifyStringHashAsync(string input, string expectedHash, 
        HashAlgorithmType algorithmType, CancellationToken cancellationToken = default)
    {
        string actualHash = await CalculateStringHashAsync(input, algorithmType, cancellationToken);
        return CompareHashes(actualHash, expectedHash);
    }
    
    private static bool CompareHashes(string hash1, string hash2)
    {
        // استخدام مقارنة ثابتة الزمن لمنع هجمات التوقيت
        if (hash1.Length != hash2.Length)
            return false;
        
        int result = 0;
        for (int i = 0; i < hash1.Length; i++)
        {
            result |= hash1[i] ^ hash2[i];
        }
        
        return result == 0;
    }
    
    private static string BytesToHex(byte[] bytes)
    {
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }
    
    public static string GenerateHMAC(string data, string key, HashAlgorithmType algorithmType)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
        
        using var algorithm = GetHMACAlgorithm(algorithmType, keyBytes);
        byte[] hmac = algorithm.ComputeHash(dataBytes);
        return BytesToHex(hmac);
    }
    
    private static HMAC GetHMACAlgorithm(HashAlgorithmType type, byte[] key)
    {
        return type switch
        {
            HashAlgorithmType.MD5 => new HMACMD5(key),
            HashAlgorithmType.SHA1 => new HMACSHA1(key),
            HashAlgorithmType.SHA256 => new HMACSHA256(key),
            HashAlgorithmType.SHA384 => new HMACSHA384(key),
            HashAlgorithmType.SHA512 => new HMACSHA512(key),
            _ => throw new ArgumentException("نوع خوارزمية HMAC غير معروف")
        };
    }
    
    public static bool VerifyHMAC(string data, string key, string expectedHmac, HashAlgorithmType algorithmType)
    {
        string actualHmac = GenerateHMAC(data, key, algorithmType);
        return CompareHashes(actualHmac, expectedHmac);
    }
}

public enum HashAlgorithmType
{
    MD5,
    SHA1,
    SHA256,
    SHA384,
    SHA512
}