using System;
using System.Security.Cryptography;
using System.Text;
using SecureDataProtectionTool.Models;
using SecureDataProtectionTool.Security;

namespace SecureDataProtectionTool.Core;

public class KeyDerivationService : IDisposable
{
    private bool _disposed;
    private readonly RandomNumberGenerator _rng;
    
    public KeyDerivationService()
    {
        _rng = RandomNumberGenerator.Create();
    }
    
    public byte[] DeriveKey(string password, byte[] salt, int keySizeBytes,
                           string? username = null, string? additionalKey = null,
                           int iterations = 100000)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("كلمة المرور مطلوبة");
        
        if (salt == null || salt.Length == 0)
            throw new ArgumentException("الملح مطلوب");
        
        using var securePassword = new SecureMemory(Encoding.UTF8.GetBytes(password));
        
        // دمج المدخلات
        byte[] combinedInput = CombineInputs(
            securePassword.GetBytes(),
            username != null ? Encoding.UTF8.GetBytes(username) : Array.Empty<byte>(),
            additionalKey != null ? Encoding.UTF8.GetBytes(additionalKey) : Array.Empty<byte>()
        );
        
        try
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(
                combinedInput,
                salt,
                iterations,
                HashAlgorithmName.SHA256);
            
            return pbkdf2.GetBytes(keySizeBytes);
        }
        finally
        {
            // تنظيف المصفوفات الحساسة
            Array.Clear(combinedInput, 0, combinedInput.Length);
        }
    }
    
    public byte[] GenerateSalt(int length)
    {
        if (length < 16)
            throw new ArgumentException("يجب أن يكون طول الملح 16 بايت على الأقل");
        
        byte[] salt = new byte[length];
        _rng.GetBytes(salt);
        return salt;
    }
    
    public byte[] GenerateIV(int length)
    {
        if (length < 12)
            throw new ArgumentException("يجب أن يكون طول IV 12 بايت على الأقل");
        
        byte[] iv = new byte[length];
        _rng.GetBytes(iv);
        return iv;
    }
    
    public (byte[] Salt, byte[] IV) GenerateSaltAndIV(int saltLength, int ivLength)
    {
        return (GenerateSalt(saltLength), GenerateIV(ivLength));
    }
    
    private static byte[] CombineInputs(params byte[][] inputs)
    {
        int totalLength = 0;
        foreach (var input in inputs)
            totalLength += input.Length;
        
        byte[] result = new byte[totalLength];
        int offset = 0;
        
        foreach (var input in inputs)
        {
            Buffer.BlockCopy(input, 0, result, offset, input.Length);
            offset += input.Length;
        }
        
        return result;
    }
    
    public string GenerateRandomString(int length, string charset)
    {
        if (string.IsNullOrEmpty(charset))
            throw new ArgumentException("مجموعة الأحرف مطلوبة");
        
        var result = new StringBuilder(length);
        byte[] randomBytes = new byte[length];
        _rng.GetBytes(randomBytes);
        
        for (int i = 0; i < length; i++)
        {
            result.Append(charset[randomBytes[i] % charset.Length]);
        }
        
        return result.ToString();
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _rng?.Dispose();
            }
            _disposed = true;
        }
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    ~KeyDerivationService()
    {
        Dispose(false);
    }
}