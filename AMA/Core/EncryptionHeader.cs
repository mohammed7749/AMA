using System.Buffers.Binary;

namespace SecureDataProtectionTool.Core;

public static class EncryptionHeader
{
    // Magic Bytes لتحديد أن الملف مشفر بهذا البرنامج
    public static readonly byte[] MAGIC_BYTES = { 0x53, 0x44, 0x50, 0x54 }; // "SDPT"
    public const byte VERSION = 0x02;
    
    // أنواع الخوارزميات
    public const byte ALG_AES256 = 0x01;
    public const byte ALG_AES128 = 0x02;
    public const byte ALG_DES = 0x03;
    
    // أنواع KDF
    public const byte KDF_PBKDF2 = 0x01;
    public const byte KDF_ARGON2 = 0x02;
    
    // أنواع وضع التشفير
    public const byte MODE_CBC = 0x01;
    public const byte MODE_GCM = 0x02;
    
    public const int HEADER_SIZE = 16; // حجم الرأس بالبايت
    
    public static byte[] CreateHeader(
        byte algorithmId = ALG_AES256,
        byte kdfType = KDF_PBKDF2,
        byte mode = MODE_CBC,
        int saltLength = 32,
        int ivLength = 16,
        int iterations = 100000)
    {
        using var ms = new MemoryStream(HEADER_SIZE);
        
        // Magic Bytes + Version
        ms.Write(MAGIC_BYTES, 0, MAGIC_BYTES.Length);
        ms.WriteByte(VERSION);
        
        // Algorithm Info
        ms.WriteByte(algorithmId);
        ms.WriteByte(kdfType);
        ms.WriteByte(mode);
        
        // Lengths
        ms.WriteByte((byte)saltLength);
        ms.WriteByte((byte)ivLength);
        
        // Iterations (4 bytes)
        var iterationsBytes = BitConverter.GetBytes(iterations);
        if (!BitConverter.IsLittleEndian)
            Array.Reverse(iterationsBytes);
        ms.Write(iterationsBytes, 0, 4);
        
        // Reserved (2 bytes)
        ms.WriteByte(0x00);
        ms.WriteByte(0x00);
        
        return ms.ToArray();
    }
    
    public static bool ValidateHeader(byte[] header)
    {
        if (header.Length < HEADER_SIZE)
            return false;
        
        // التحقق من Magic Bytes
        for (int i = 0; i < MAGIC_BYTES.Length; i++)
        {
            if (header[i] != MAGIC_BYTES[i])
                return false;
        }
        
        // التحقق من الإصدار
        if (header[4] > VERSION)
            return false;
        
        return true;
    }
    
    public static HeaderInfo ParseHeader(byte[] header)
    {
        if (!ValidateHeader(header))
            throw new InvalidOperationException("رأس تشفير غير صالح");
        
        var info = new HeaderInfo
        {
            Version = header[4],
            AlgorithmId = header[5],
            KdfType = header[6],
            Mode = header[7],
            SaltLength = header[8],
            IvLength = header[9],
            Iterations = BinaryPrimitives.ReadInt32LittleEndian(header.AsSpan(10, 4))
        };
        
        return info;
    }
    
    public static string GetAlgorithmName(byte algorithmId)
    {
        return algorithmId switch
        {
            ALG_AES256 => "AES-256",
            ALG_AES128 => "AES-128",
            ALG_DES => "DES",
            _ => "Unknown"
        };
    }
    
    public static string GetKdfName(byte kdfType)
    {
        return kdfType switch
        {
            KDF_PBKDF2 => "PBKDF2",
            KDF_ARGON2 => "Argon2",
            _ => "Unknown"
        };
    }
    
    public static string GetModeName(byte mode)
    {
        return mode switch
        {
            MODE_CBC => "CBC",
            MODE_GCM => "GCM",
            _ => "Unknown"
        };
    }
    
    public class HeaderInfo
    {
        public byte Version { get; set; }
        public byte AlgorithmId { get; set; }
        public byte KdfType { get; set; }
        public byte Mode { get; set; }
        public int SaltLength { get; set; }
        public int IvLength { get; set; }
        public int Iterations { get; set; }
        
        public string AlgorithmName => GetAlgorithmName(AlgorithmId);
        public string KdfName => GetKdfName(KdfType);
        public string ModeName => GetModeName(Mode);
    }
}