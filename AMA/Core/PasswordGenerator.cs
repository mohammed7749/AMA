using System.Security.Cryptography;
using System.Text;

namespace SecureDataProtectionTool.Core;

public class PasswordGenerator : IDisposable
{
    private bool _disposed;
    private readonly RandomNumberGenerator _rng;
    private readonly Logging.LogService? _logger;
    
    private const string UPPERCASE_EN = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string LOWERCASE_EN = "abcdefghijklmnopqrstuvwxyz";
    private const string UPPERCASE_AR = "أبتثجحخدذرزسشصضطظعغفقكلمنهوي";
    private const string LOWERCASE_AR = "أبتثجحخدذرزسشصضطظعغفقكلمنهوي";
    private const string NUMBERS = "0123456789";
    private const string SYMBOLS = "!@#$%^&*()-_=+[]{}|;:,.<>?";
    private const string AMBIGUOUS = "lI1O0";
    private const string SIMILAR = "il1|o0O";
    
    public PasswordGenerator(Logging.LogService? logger = null)
    {
        _rng = RandomNumberGenerator.Create();
        _logger = logger;
    }
    
    public string GeneratePassword(PasswordOptions options)
    {
        if (options == null)
            throw new ArgumentNullException(nameof(options));
        
        options.Validate();
        
        // بناء مجموعة الأحرف
        var charset = new StringBuilder();
        
        if (options.IncludeUppercase)
            charset.Append(options.UseArabic ? UPPERCASE_AR : UPPERCASE_EN);
        
        if (options.IncludeLowercase)
            charset.Append(options.UseArabic ? LOWERCASE_AR : LOWERCASE_EN);
        
        if (options.IncludeNumbers)
            charset.Append(NUMBERS);
        
        if (options.IncludeSymbols)
            charset.Append(SYMBOLS);
        
        if (charset.Length == 0)
            charset.Append(LOWERCASE_EN + NUMBERS);
        
        string charSetString = charset.ToString();
        
        // إزالة الأحرف المربكة إذا طلب
        if (options.ExcludeAmbiguous)
        {
            charSetString = RemoveCharacters(charSetString, AMBIGUOUS);
        }
        
        if (options.ExcludeSimilar)
        {
            charSetString = RemoveCharacters(charSetString, SIMILAR);
        }
        
        // توليد كلمة المرور
        var password = new StringBuilder();
        byte[] randomBytes = new byte[options.Length];
        _rng.GetBytes(randomBytes);
        
        // التأكد من وجود نوع واحد على الأقل من كل نوع مطلوب
        if (options.IncludeUppercase && password.ToString().IndexOfAny(
            (options.UseArabic ? UPPERCASE_AR : UPPERCASE_EN).ToCharArray()) == -1)
        {
            int index = randomBytes[0] % (options.UseArabic ? UPPERCASE_AR : UPPERCASE_EN).Length;
            password.Append(options.UseArabic ? UPPERCASE_AR[index] : UPPERCASE_EN[index]);
        }
        
        if (options.IncludeLowercase && password.ToString().IndexOfAny(
            (options.UseArabic ? LOWERCASE_AR : LOWERCASE_EN).ToCharArray()) == -1)
        {
            int index = randomBytes[1] % (options.UseArabic ? LOWERCASE_AR : LOWERCASE_EN).Length;
            password.Append(options.UseArabic ? LOWERCASE_AR[index] : LOWERCASE_EN[index]);
        }
        
        if (options.IncludeNumbers && password.ToString().IndexOfAny(NUMBERS.ToCharArray()) == -1)
        {
            int index = randomBytes[2] % NUMBERS.Length;
            password.Append(NUMBERS[index]);
        }
        
        if (options.IncludeSymbols && password.ToString().IndexOfAny(SYMBOLS.ToCharArray()) == -1)
        {
            int index = randomBytes[3] % SYMBOLS.Length;
            password.Append(SYMBOLS[index]);
        }
        
        // إكمال الباقي
        int remaining = options.Length - password.Length;
        for (int i = 0; i < remaining; i++)
        {
            password.Append(charSetString[randomBytes[i + 4] % charSetString.Length]);
        }
        
        // خلط الأحرف عشوائياً
        string result = ShuffleString(password.ToString());
        
        _logger?.LogInfo("PasswordGenerator", 
            $"تم توليد كلمة مرور طولها {options.Length} حرف");
        
        return result;
    }
    
    public string GeneratePassphrase(PassphraseOptions options)
    {
        if (options == null)
            throw new ArgumentNullException(nameof(options));
        
        options.Validate();
        
        // قائمة كلمات (يمكن تحميلها من ملف)
        string[] wordList = options.Language switch
        {
            "ar" => GetArabicWordList(),
            "en" => GetEnglishWordList(),
            _ => GetEnglishWordList()
        };
        
        var passphrase = new StringBuilder();
        byte[] randomBytes = new byte[options.WordCount * 4];
        _rng.GetBytes(randomBytes);
        
        for (int i = 0; i < options.WordCount; i++)
        {
            int index = BitConverter.ToInt32(randomBytes, i * 4) % wordList.Length;
            if (index < 0) index = -index;
            
            passphrase.Append(wordList[index]);
            
            if (i < options.WordCount - 1)
            {
                passphrase.Append(options.Separator);
            }
        }
        
        // إضافة رقم إذا طلب
        if (options.IncludeNumber)
        {
            passphrase.Append(randomBytes[0] % 10);
        }
        
        // إضافة رمز إذا طلب
        if (options.IncludeSymbol)
        {
            passphrase.Append(SYMBOLS[randomBytes[1] % SYMBOLS.Length]);
        }
        
        // تحويل للحالة المناسبة
        string result = options.Capitalize 
            ? passphrase.ToString().ToUpperInvariant() 
            : passphrase.ToString();
        
        _logger?.LogInfo("PasswordGenerator", 
            $"تم توليد عبارة مرور من {options.WordCount} كلمة");
        
        return result;
    }
    
    public string GeneratePIN(int length = 4)
    {
        if (length < 4 || length > 8)
            throw new ArgumentException("طول PIN يجب أن يكون بين 4 و 8 أرقام");
        
        byte[] randomBytes = new byte[length];
        _rng.GetBytes(randomBytes);
        
        var pin = new StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            pin.Append(NUMBERS[randomBytes[i] % NUMBERS.Length]);
        }
        
        return pin.ToString();
    }
    
    public PasswordStrength EvaluateStrength(string password)
    {
        if (string.IsNullOrEmpty(password))
            return PasswordStrength.VeryWeak;
        
        int score = 0;
        
        // الطول
        if (password.Length >= 8) score++;
        if (password.Length >= 12) score++;
        if (password.Length >= 16) score++;
        
        // التعقيد
        if (password.Any(char.IsUpper)) score++;
        if (password.Any(char.IsLower)) score++;
        if (password.Any(char.IsDigit)) score++;
        if (password.Any(IsSymbol)) score++;
        
        // التنوع
        if (password.Distinct().Count() >= password.Length * 0.7) score++;
        
        // الأنماط الشائعة
        if (!IsCommonPassword(password)) score++;
        
        return score switch
        {
            <= 3 => PasswordStrength.Weak,
            <= 5 => PasswordStrength.Moderate,
            <= 7 => PasswordStrength.Strong,
            _ => PasswordStrength.VeryStrong
        };
    }
    
    public string GetStrengthDescription(PasswordStrength strength)
    {
        return strength switch
        {
            PasswordStrength.VeryWeak => "ضعيف جداً - غير مقبول",
            PasswordStrength.Weak => "ضعيف - يحتاج تحسين",
            PasswordStrength.Moderate => "متوسط - مقبول",
            PasswordStrength.Strong => "قوي - جيد",
            PasswordStrength.VeryStrong => "قوي جداً - ممتاز",
            _ => "غير معروف"
        };
    }
    
    public IEnumerable<string> GenerateMultiple(PasswordOptions options, int count)
    {
        if (count <= 0)
            throw new ArgumentException("العدد يجب أن يكون أكبر من صفر");
        
        var passwords = new List<string>();
        for (int i = 0; i < count; i++)
        {
            passwords.Add(GeneratePassword(options));
        }
        
        return passwords;
    }
    
    private static bool IsSymbol(char c)
    {
        return SYMBOLS.Contains(c);
    }
    
    private static bool IsCommonPassword(string password)
    {
        var commonPasswords = new HashSet<string>
        {
            "password", "123456", "12345678", "1234", "qwerty",
            "12345", "dragon", "football", "monkey", "letmein",
            "admin", "welcome", "password1", "123123", "sunshine"
        };
        
        return commonPasswords.Contains(password.ToLowerInvariant());
    }
    
    private static string RemoveCharacters(string input, string charsToRemove)
    {
        foreach (char c in charsToRemove)
        {
            input = input.Replace(c.ToString(), "");
        }
        return input;
    }
    
    private static string ShuffleString(string input)
    {
        char[] array = input.ToCharArray();
        RandomNumberGenerator.Shuffle<char>(new Span<char>(array));
        return new string(array);
    }
    
    private static string[] GetArabicWordList()
    {
        return new[]
        {
            "مفتاح", "شمس", "قمر", "نجمة", "بحر", "جبل", "شجرة", "وردة",
            "كتاب", "قلم", "ورقة", "منزل", "سيارة", "طائرة", "سفينة", "قطار",
            "كمبيوتر", "هاتف", "إنترنت", "برنامج", "شبكة", "سيرفر", "بيانات", "ملف",
            "سر", "أمان", "تشفير", "فك", "حماية", "معلومات", "نظام", "دخول"
        };
    }
    
    private static string[] GetEnglishWordList()
    {
        return new[]
        {
            "apple", "brave", "cloud", "dream", "eagle", "flame", "grace", "heart",
            "ivory", "jewel", "knife", "light", "magic", "night", "ocean", "peace",
            "queen", "river", "stone", "truth", "unity", "vivid", "world", "xenon",
            "yearn", "zebra", "alpha", "beta", "gamma", "delta", "echo", "foxtrot"
        };
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _rng.Dispose();
            }
            _disposed = true;
        }
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    ~PasswordGenerator()
    {
        Dispose(false);
    }
}

public class PasswordOptions
{
    public int Length { get; set; } = 12;
    public bool IncludeUppercase { get; set; } = true;
    public bool IncludeLowercase { get; set; } = true;
    public bool IncludeNumbers { get; set; } = true;
    public bool IncludeSymbols { get; set; } = true;
    public bool ExcludeAmbiguous { get; set; } = true;
    public bool ExcludeSimilar { get; set; } = true;
    public bool UseArabic { get; set; } = false;
    
    public void Validate()
    {
        if (Length < 8)
            Length = 8;
        if (Length > 128)
            Length = 128;
    }
}

public class PassphraseOptions
{
    public int WordCount { get; set; } = 4;
    public string Separator { get; set; } = "-";
    public bool Capitalize { get; set; } = false;
    public bool IncludeNumber { get; set; } = true;
    public bool IncludeSymbol { get; set; } = false;
    public string Language { get; set; } = "en";
    
    public void Validate()
    {
        if (WordCount < 3)
            WordCount = 3;
        if (WordCount > 10)
            WordCount = 10;
        if (string.IsNullOrEmpty(Separator))
            Separator = "-";
    }
}

public enum PasswordStrength
{
    VeryWeak,
    Weak,
    Moderate,
    Strong,
    VeryStrong
}