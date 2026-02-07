using System.Text.Json.Serialization;

namespace SecureDataProtectionTool.Models;

public class EncryptionMetadata
{
    public string Algorithm { get; set; } = "AES-256";
    public string Mode { get; set; } = "CBC";
    public int KeySize { get; set; } = 256;
    public int BlockSize { get; set; } = 128;
    public string KdfType { get; set; } = "PBKDF2";
    public int Iterations { get; set; } = 100000;
    public int SaltLength { get; set; } = 32;
    public DateTime EncryptionTime { get; set; } = DateTime.UtcNow;
    public bool HasAdditionalKey { get; set; } = false;
    public string Version { get; set; } = "1.0";
    public string OriginalFileName { get; set; } = string.Empty;
    public long OriginalFileSize { get; set; }
    
    [JsonIgnore]
    public bool IsValid => !string.IsNullOrEmpty(Algorithm) && KeySize > 0;
}