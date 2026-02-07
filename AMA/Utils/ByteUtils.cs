using System.Security.Cryptography;
using System.Text;

namespace SecureDataProtectionTool.Utils;

public static class ByteUtils
{
    public static string ToHexString(byte[] bytes)
    {
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }
    
    public static string ToBase64String(byte[] bytes)
    {
        return Convert.ToBase64String(bytes);
    }
    
    public static byte[] FromHexString(string hex)
    {
        if (string.IsNullOrEmpty(hex))
            return Array.Empty<byte>();
        
        // التعامل مع البادئة 0x إذا وجدت
        if (hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            hex = hex[2..];
        
        // التأكد من أن الطول زوجي
        if (hex.Length % 2 != 0)
            throw new ArgumentException("سلسلة hex يجب أن يكون طولها زوجياً");
        
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        
        return bytes;
    }
    
    public static byte[] FromBase64String(string base64)
    {
        if (string.IsNullOrEmpty(base64))
            return Array.Empty<byte>();
        
        return Convert.FromBase64String(base64);
    }
    
    public static byte[] Combine(params byte[][] arrays)
    {
        int totalLength = arrays.Sum(a => a.Length);
        byte[] result = new byte[totalLength];
        int offset = 0;
        
        foreach (byte[] array in arrays)
        {
            Buffer.BlockCopy(array, 0, result, offset, array.Length);
            offset += array.Length;
        }
        
        return result;
    }
    
    public static bool AreEqual(byte[] a, byte[] b)
    {
        // استخدام مقارنة ثابتة الزمن لمنع هجمات التوقيت
        if (a == null || b == null || a.Length != b.Length)
            return false;
        
        int result = 0;
        for (int i = 0; i < a.Length; i++)
        {
            result |= a[i] ^ b[i];
        }
        
        return result == 0;
    }
    
    public static void ClearBytes(byte[] bytes)
    {
        if (bytes != null)
        {
            Array.Clear(bytes);
        }
    }
    
    public static void ClearBytes(Span<byte> bytes)
    {
        bytes.Clear();
    }
    
    public static byte[] Xor(byte[] a, byte[] b)
    {
        if (a.Length != b.Length)
            throw new ArgumentException("المصفوفات يجب أن يكون لها نفس الطول");
        
        byte[] result = new byte[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = (byte)(a[i] ^ b[i]);
        }
        
        return result;
    }
    
    public static byte[] GetRandomBytes(int length)
    {
        byte[] bytes = new byte[length];
        RandomNumberGenerator.Fill(bytes);
        return bytes;
    }
    
    public static string GenerateRandomHex(int byteLength)
    {
        byte[] bytes = GetRandomBytes(byteLength);
        return ToHexString(bytes);
    }
    
    public static string GenerateRandomBase64(int byteLength)
    {
        byte[] bytes = GetRandomBytes(byteLength);
        return ToBase64String(bytes);
    }
    
    public static byte[] StringToBytes(string text)
    {
        return Encoding.UTF8.GetBytes(text);
    }
    
    public static string BytesToString(byte[] bytes)
    {
        return Encoding.UTF8.GetString(bytes);
    }
    
    public static byte[] CloneBytes(byte[] source)
    {
        if (source == null)
            return Array.Empty<byte>();
        
        byte[] clone = new byte[source.Length];
        Buffer.BlockCopy(source, 0, clone, 0, source.Length);
        return clone;
    }
    
    public static byte[] PadToMultiple(byte[] data, int blockSize)
    {
        int padding = blockSize - (data.Length % blockSize);
        if (padding == blockSize)
            return data;
        
        byte[] padded = new byte[data.Length + padding];
        Buffer.BlockCopy(data, 0, padded, 0, data.Length);
        
        // PKCS7 padding
        for (int i = data.Length; i < padded.Length; i++)
        {
            padded[i] = (byte)padding;
        }
        
        return padded;
    }
    
    public static byte[] RemovePadding(byte[] data, int blockSize)
    {
        if (data.Length == 0 || data.Length % blockSize != 0)
            throw new ArgumentException("البيانات غير صالحة أو غير مطابقة لحجم البلوك");
        
        int padding = data[^1];
        if (padding < 1 || padding > blockSize)
            throw new ArgumentException("تعبئة غير صالحة");
        
        // التحقق من أن جميع بايتات التعبئة صحيحة
        for (int i = data.Length - padding; i < data.Length; i++)
        {
            if (data[i] != padding)
                throw new ArgumentException("تعبئة غير صالحة");
        }
        
        byte[] unpadded = new byte[data.Length - padding];
        Buffer.BlockCopy(data, 0, unpadded, 0, unpadded.Length);
        return unpadded;
    }
}