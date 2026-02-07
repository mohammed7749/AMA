using System.Security.Cryptography;
using System.Text;

namespace SecureDataProtectionTool.Core;

public class CustomCryptography : IDisposable
{
    private bool _disposed;
    private readonly Logging.LogService? _logger;
    
    public enum AlgorithmType
    {
        AES256,
        AES128,
        DES,
        TripleDES,
        MD5,
        SHA1,
        SHA256,
        SHA512
    }
    
    public CustomCryptography(Logging.LogService? logger = null)
    {
        _logger = logger;
    }
    
    public string EncryptString(string plainText, string password, AlgorithmType algorithm)
    {
        try
        {
            return algorithm switch
            {
                AlgorithmType.AES256 => EncryptAES(plainText, password, 256),
                AlgorithmType.AES128 => EncryptAES(plainText, password, 128),
                AlgorithmType.DES => EncryptDES(plainText, password),
                AlgorithmType.TripleDES => EncryptTripleDES(plainText, password),
                AlgorithmType.MD5 => ComputeHash(plainText, HashAlgorithmName.MD5),
                AlgorithmType.SHA1 => ComputeHash(plainText, HashAlgorithmName.SHA1),
                AlgorithmType.SHA256 => ComputeHash(plainText, HashAlgorithmName.SHA256),
                AlgorithmType.SHA512 => ComputeHash(plainText, HashAlgorithmName.SHA512),
                _ => throw new ArgumentException("خوارزمية غير معروفة")
            };
        }
        catch (Exception ex)
        {
            _logger?.LogError("CustomCryptography", $"فشل في التشفير باستخدام {algorithm}", ex);
            throw;
        }
    }
    
    public string DecryptString(string cipherText, string password, AlgorithmType algorithm)
    {
        try
        {
            return algorithm switch
            {
                AlgorithmType.AES256 => DecryptAES(cipherText, password, 256),
                AlgorithmType.AES128 => DecryptAES(cipherText, password, 128),
                AlgorithmType.DES => DecryptDES(cipherText, password),
                AlgorithmType.TripleDES => DecryptTripleDES(cipherText, password),
                _ => throw new InvalidOperationException($"{algorithm} هي دالة تجزئة ولا يمكن فك تشفيرها")
            };
        }
        catch (Exception ex)
        {
            _logger?.LogError("CustomCryptography", $"فشل في فك التشفير باستخدام {algorithm}", ex);
            throw;
        }
    }
    
    private string EncryptAES(string plainText, string password, int keySize)
    {
        using var aes = Aes.Create();
        aes.KeySize = keySize;
        aes.BlockSize = 128;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        
        using var sha = SHA256.Create();
        aes.Key = sha.ComputeHash(Encoding.UTF8.GetBytes(password)).Take(keySize / 8).ToArray();
        
        aes.GenerateIV();
        
        using var encryptor = aes.CreateEncryptor();
        using var ms = new MemoryStream();
        
        ms.Write(aes.IV, 0, aes.IV.Length);
        
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs, Encoding.UTF8))
        {
            sw.Write(plainText);
        }
        
        return Convert.ToBase64String(ms.ToArray());
    }
    
    private string DecryptAES(string cipherText, string password, int keySize)
    {
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        
        using var aes = Aes.Create();
        aes.KeySize = keySize;
        aes.BlockSize = 128;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        
        using var sha = SHA256.Create();
        aes.Key = sha.ComputeHash(Encoding.UTF8.GetBytes(password)).Take(keySize / 8).ToArray();
        
        byte[] iv = new byte[16];
        Array.Copy(cipherBytes, 0, iv, 0, 16);
        aes.IV = iv;
        
        using var decryptor = aes.CreateDecryptor();
        using var ms = new MemoryStream(cipherBytes, 16, cipherBytes.Length - 16);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs, Encoding.UTF8);
        
        return sr.ReadToEnd();
    }
    
    private string EncryptDES(string plainText, string password)
    {
        using var des = DES.Create();
        des.Mode = CipherMode.CBC;
        des.Padding = PaddingMode.PKCS7;
        
        // توليد مفتاح ومتجه تهيئة من كلمة المرور
        byte[] keyBytes = Encoding.UTF8.GetBytes(password.PadRight(8).Substring(0, 8));
        byte[] ivBytes = new byte[8];
        Array.Copy(keyBytes, ivBytes, 8);
        
        des.Key = keyBytes;
        des.IV = ivBytes;
        
        using var encryptor = des.CreateEncryptor();
        using var ms = new MemoryStream();
        
        ms.Write(des.IV, 0, des.IV.Length);
        
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs, Encoding.UTF8))
        {
            sw.Write(plainText);
        }
        
        return Convert.ToBase64String(ms.ToArray());
    }
    
    private string DecryptDES(string cipherText, string password)
    {
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        
        using var des = DES.Create();
        des.Mode = CipherMode.CBC;
        des.Padding = PaddingMode.PKCS7;
        
        byte[] keyBytes = Encoding.UTF8.GetBytes(password.PadRight(8).Substring(0, 8));
        byte[] ivBytes = new byte[8];
        Array.Copy(cipherBytes, 0, ivBytes, 0, 8);
        
        des.Key = keyBytes;
        des.IV = ivBytes;
        
        using var decryptor = des.CreateDecryptor();
        using var ms = new MemoryStream(cipherBytes, 8, cipherBytes.Length - 8);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs, Encoding.UTF8);
        
        return sr.ReadToEnd();
    }
    
    private string EncryptTripleDES(string plainText, string password)
    {
        using var tripleDes = TripleDES.Create();
        tripleDes.Mode = CipherMode.CBC;
        tripleDes.Padding = PaddingMode.PKCS7;
        
        using var md5 = MD5.Create();
        byte[] key = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
        byte[] iv = new byte[8];
        Array.Copy(key, iv, 8);
        
        tripleDes.Key = key;
        tripleDes.IV = iv;
        
        using var encryptor = tripleDes.CreateEncryptor();
        using var ms = new MemoryStream();
        
        ms.Write(tripleDes.IV, 0, tripleDes.IV.Length);
        
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs, Encoding.UTF8))
        {
            sw.Write(plainText);
        }
        
        return Convert.ToBase64String(ms.ToArray());
    }
    
    private string DecryptTripleDES(string cipherText, string password)
    {
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        
        using var tripleDes = TripleDES.Create();
        tripleDes.Mode = CipherMode.CBC;
        tripleDes.Padding = PaddingMode.PKCS7;
        
        using var md5 = MD5.Create();
        byte[] key = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
        byte[] iv = new byte[8];
        Array.Copy(cipherBytes, 0, iv, 0, 8);
        
        tripleDes.Key = key;
        tripleDes.IV = iv;
        
        using var decryptor = tripleDes.CreateDecryptor();
        using var ms = new MemoryStream(cipherBytes, 8, cipherBytes.Length - 8);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs, Encoding.UTF8);
        
        return sr.ReadToEnd();
    }
    
    private string ComputeHash(string input, HashAlgorithmName algorithmName)
    {
        using HashAlgorithm algorithm = algorithmName.Name switch
        {
            "MD5" => MD5.Create(),
            "SHA1" => SHA1.Create(),
            "SHA256" => SHA256.Create(),
            "SHA512" => SHA512.Create(),
            _ => throw new ArgumentException("خوارزمية تجزئة غير معروفة")
        };
        
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashBytes = algorithm.ComputeHash(inputBytes);
        
        return Convert.ToHexString(hashBytes).ToLower();
    }
    
    public bool VerifyHash(string input, string hash, AlgorithmType algorithm)
    {
        string computedHash = ComputeHash(input, GetHashAlgorithmName(algorithm));
        return string.Equals(computedHash, hash, StringComparison.OrdinalIgnoreCase);
    }
    
    private HashAlgorithmName GetHashAlgorithmName(AlgorithmType algorithm)
    {
        return algorithm switch
        {
            AlgorithmType.MD5 => HashAlgorithmName.MD5,
            AlgorithmType.SHA1 => HashAlgorithmName.SHA1,
            AlgorithmType.SHA256 => HashAlgorithmName.SHA256,
            AlgorithmType.SHA512 => HashAlgorithmName.SHA512,
            _ => throw new ArgumentException("ليست خوارزمية تجزئة")
        };
    }
    
    public Dictionary<AlgorithmType, string> GetAvailableAlgorithms()
    {
        return new Dictionary<AlgorithmType, string>
        {
            { AlgorithmType.AES256, "AES-256 (آمن)" },
            { AlgorithmType.AES128, "AES-128" },
            { AlgorithmType.DES, "DES (غير آمن)" },
            { AlgorithmType.TripleDES, "3DES" },
            { AlgorithmType.MD5, "MD5 (تجزئة)" },
            { AlgorithmType.SHA1, "SHA-1 (تجزئة)" },
            { AlgorithmType.SHA256, "SHA-256 (تجزئة)" },
            { AlgorithmType.SHA512, "SHA-512 (تجزئة)" }
        };
    }
    
    public string GetAlgorithmDescription(AlgorithmType algorithm)
    {
        return algorithm switch
        {
            AlgorithmType.AES256 => "AES-256: معيار تشفير متقدم، 256-bit، آمن جداً",
            AlgorithmType.AES128 => "AES-128: معيار تشفير متقدم، 128-bit، آمن",
            AlgorithmType.DES => "DES: معيار تشفير بيانات، 56-bit، غير آمن للاستخدام الحديث",
            AlgorithmType.TripleDES => "3DES: 3 طبقات من DES، 112-bit، متوسط الأمان",
            AlgorithmType.MD5 => "MD5: خوارزمية تجزئة 128-bit، غير آمنة ضد التصادم",
            AlgorithmType.SHA1 => "SHA-1: خوارزمية تجزئة 160-bit، ضعيفة ضد التصادم",
            AlgorithmType.SHA256 => "SHA-256: خوارزمية تجزئة 256-bit، آمنة",
            AlgorithmType.SHA512 => "SHA-512: خوارزمية تجزئة 512-bit، آمنة جداً",
            _ => "غير معروف"
        };
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            _disposed = true;
        }
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    ~CustomCryptography()
    {
        Dispose(false);
    }
}