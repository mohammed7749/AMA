using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;

namespace SecureDataProtectionTool.Core;

public class PasswordCracker : IDisposable
{
    private bool _disposed;
    private bool _isRunning;
    private readonly ConcurrentDictionary<string, string> _wordlist;
    private readonly Logging.LogService? _logger;
    private CancellationTokenSource? _cts;
    private long _attempts;
    private DateTime _startTime;
    private long _totalCombinations;
    private int _lastReportedProgress;
    
    public event EventHandler<string>? PasswordFound;
    public event EventHandler<(int Progress, long Attempts, TimeSpan Elapsed)>? ProgressChanged;
    public event EventHandler<string>? StatusChanged;
    
    public PasswordCracker(Logging.LogService? logger = null)
    {
        _wordlist = new ConcurrentDictionary<string, string>();
        _logger = logger;
        _lastReportedProgress = -1;
    }
    
    public void LoadWordlistFromFile(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("ملف قائمة الكلمات غير موجود", filePath);
            
            var lines = File.ReadAllLines(filePath, Encoding.UTF8);
            int loadedCount = 0;
            
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string trimmedLine = line.Trim();
                    if (!_wordlist.ContainsKey(trimmedLine))
                    {
                        _wordlist[trimmedLine] = trimmedLine;
                        loadedCount++;
                    }
                }
            }
            
            _logger?.LogInfo("PasswordCracker", $"تم تحميل {loadedCount} كلمة من القائمة");
            OnStatusChanged($"تم تحميل {loadedCount} كلمة من القائمة");
        }
        catch (Exception ex)
        {
            _logger?.LogError("PasswordCracker", "فشل في تحميل قائمة الكلمات", ex);
            throw;
        }
    }
    
    public void LoadWordlist(IEnumerable<string> words)
    {
        int loadedCount = 0;
        foreach (var word in words)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                string trimmedWord = word.Trim();
                if (!_wordlist.ContainsKey(trimmedWord))
                {
                    _wordlist[trimmedWord] = trimmedWord;
                    loadedCount++;
                }
            }
        }
        
        _logger?.LogInfo("PasswordCracker", $"تم تحميل {loadedCount} كلمة");
        OnStatusChanged($"تم تحميل {loadedCount} كلمة");
    }
    
    public Task<string?> DictionaryAttackAsync(
        string targetHash,
        HashAlgorithmName hashAlgorithm,
        CancellationToken cancellationToken = default)
    {
        return Task.Run(() => ExecuteAttack("القاموس", targetHash, hashAlgorithm, cancellationToken, 
            (token) => ExecuteDictionaryAttack(targetHash, hashAlgorithm, token)), cancellationToken);
    }
    
    private string? ExecuteDictionaryAttack(
        string targetHash,
        HashAlgorithmName hashAlgorithm,
        CancellationToken cancellationToken)
    {
        long totalWords = _wordlist.Count;
        if (totalWords == 0)
        {
            OnStatusChanged("قائمة الكلمات فارغة");
            return null;
        }
        
        int wordIndex = 0;
        DateTime lastProgressTime = DateTime.UtcNow;
        long lastAttempts = 0;
        
        foreach (var word in _wordlist.Values)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                OnStatusChanged("تم إلغاء الهجوم");
                return null;
            }
            
            _attempts++;
            wordIndex++;
            
            UpdateProgress(totalWords, wordIndex, ref lastProgressTime, ref lastAttempts);
            
            string wordHash = ComputeHash(word, hashAlgorithm);
            if (string.Equals(wordHash, targetHash, StringComparison.OrdinalIgnoreCase))
            {
                OnPasswordFound(word);
                OnStatusChanged($"تم العثور على كلمة المرور: {word}");
                _logger?.LogSecurity("PasswordCracker", $"تم العثور على كلمة المرور في هجوم القاموس: {word}");
                return word;
            }
            
            var variations = GenerateVariations(word);
            foreach (var variation in variations)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;
                
                _attempts++;
                string variationHash = ComputeHash(variation, hashAlgorithm);
                
                if (string.Equals(variationHash, targetHash, StringComparison.OrdinalIgnoreCase))
                {
                    OnPasswordFound(variation);
                    OnStatusChanged($"تم العثور على كلمة المرور: {variation}");
                    _logger?.LogSecurity("PasswordCracker", $"تم العثور على كلمة المرور (مختلفة): {variation}");
                    return variation;
                }
            }
        }
        
        return null;
    }
    
    public Task<string?> BruteForceAttackAsync(
        string targetHash,
        HashAlgorithmName hashAlgorithm,
        int minLength = 1,
        int maxLength = 8,
        string? charset = null,
        CancellationToken cancellationToken = default)
    {
        return Task.Run(() => ExecuteAttack("القوة الغاشمة", targetHash, hashAlgorithm, cancellationToken, 
            (token) => ExecuteBruteForceAttack(targetHash, hashAlgorithm, minLength, maxLength, charset, token)), cancellationToken);
    }
    
    private string? ExecuteBruteForceAttack(
        string targetHash,
        HashAlgorithmName hashAlgorithm,
        int minLength,
        int maxLength,
        string? charset,
        CancellationToken cancellationToken)
    {
        charset ??= "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        
        _totalCombinations = CalculateCombinations(charset.Length, minLength, maxLength);
        
        if (_totalCombinations <= 0)
        {
            OnStatusChanged("خطأ: عدد الاحتمالات غير صالح");
            return null;
        }
        
        OnStatusChanged($"مجموع الاحتمالات: {_totalCombinations:N0}");
        
        for (int length = minLength; length <= maxLength; length++)
        {
            if (cancellationToken.IsCancellationRequested)
                break;
            
            OnStatusChanged($"جاري اختبار الطول: {length} أحرف...");
            
            if (GenerateCombinationsIterative(targetHash, hashAlgorithm, charset, length, cancellationToken))
            {
                return "found";
            }
            
            if (cancellationToken.IsCancellationRequested)
                break;
        }
        
        return null;
    }
    
    private string? ExecuteAttack(
        string attackType,
        string targetHash,
        HashAlgorithmName hashAlgorithm,
        CancellationToken cancellationToken,
        Func<CancellationToken, string?> attackFunction)
    {
        _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        _isRunning = true;
        _attempts = 0;
        _startTime = DateTime.UtcNow;
        _lastReportedProgress = -1;
        
        try
        {
            OnStatusChanged($"بدء هجوم {attackType}...");
            
            var result = attackFunction(_cts.Token);
            
            if (result == null)
            {
                var totalElapsed = DateTime.UtcNow - _startTime;
                OnProgressChanged(100, _attempts, totalElapsed);
                OnStatusChanged($"انتهى الهجوم دون نجاح. المحاولات: {_attempts:N0}, الوقت: {totalElapsed:mm\\:ss}");
                _logger?.LogInfo("PasswordCracker", $"انتهى هجوم {attackType} دون نجاح. المحاولات: {_attempts:N0}");
            }
            
            return result;
        }
        catch (Exception ex)
        {
            _logger?.LogError("PasswordCracker", $"خطأ في هجوم {attackType}", ex);
            OnStatusChanged($"خطأ: {ex.Message}");
            throw;
        }
        finally
        {
            _isRunning = false;
            _cts?.Dispose();
            _cts = null;
        }
    }
    
    private void UpdateProgress(long totalItems, long currentIndex, ref DateTime lastProgressTime, ref long lastAttempts)
    {
        var elapsed = DateTime.UtcNow - _startTime;
        
        if (_attempts % 1000 == 0 || (DateTime.UtcNow - lastProgressTime).TotalSeconds >= 1)
        {
            int progress = totalItems > 0 ? 
                Math.Min((int)((currentIndex * 100) / (double)totalItems), 100) : 0;
            
            if (progress != _lastReportedProgress)
            {
                OnProgressChanged(progress, _attempts, elapsed);
                _lastReportedProgress = progress;
            }
            
            double speed = (DateTime.UtcNow - lastProgressTime).TotalSeconds > 0 ? 
                (_attempts - lastAttempts) / (DateTime.UtcNow - lastProgressTime).TotalSeconds : 0;
            
            OnStatusChanged($"تم تجربة {currentIndex:N0} من {totalItems:N0} - السرعة: {speed:N0}/ثانية");
            
            lastProgressTime = DateTime.UtcNow;
            lastAttempts = _attempts;
        }
    }
    
    private bool GenerateCombinationsIterative(
        string targetHash,
        HashAlgorithmName hashAlgorithm,
        string charset,
        int length,
        CancellationToken cancellationToken)
    {
        if (length <= 0 || string.IsNullOrEmpty(charset))
            return false;
        
        int[] indices = new int[length];
        char[] currentWord = new char[length];
        
        for (int i = 0; i < length; i++)
        {
            indices[i] = 0;
            currentWord[i] = charset[0];
        }
        
        long combinationsForLength = CalculatePower(charset.Length, length);
        long testedForLength = 0;
        DateTime lastProgressTime = DateTime.UtcNow;
        
        while (!cancellationToken.IsCancellationRequested)
        {
            for (int i = 0; i < length; i++)
            {
                currentWord[i] = charset[indices[i]];
            }
            string word = new string(currentWord);
            
            _attempts++;
            testedForLength++;
            
            var elapsed = DateTime.UtcNow - _startTime;
            
            if (_attempts % 1000 == 0 || (DateTime.UtcNow - lastProgressTime).TotalSeconds >= 1)
            {
                if (_totalCombinations > 0)
                {
                    int progress = Math.Min((int)((_attempts * 100) / (double)_totalCombinations), 100);
                    
                    if (progress != _lastReportedProgress)
                    {
                        OnProgressChanged(progress, _attempts, elapsed);
                        _lastReportedProgress = progress;
                    }
                }
                
                OnStatusChanged($"الطول {length}: {testedForLength:N0}/{combinationsForLength:N0}");
                lastProgressTime = DateTime.UtcNow;
            }
            
            string hash = ComputeHash(word, hashAlgorithm);
            if (string.Equals(hash, targetHash, StringComparison.OrdinalIgnoreCase))
            {
                OnPasswordFound(word);
                return true;
            }
            
            int pos = length - 1;
            while (pos >= 0)
            {
                indices[pos]++;
                if (indices[pos] < charset.Length)
                {
                    break;
                }
                indices[pos] = 0;
                pos--;
            }
            
            if (pos < 0)
                break;
        }
        
        return false;
    }
    
    private long CalculateCombinations(int charsetLength, int minLength, int maxLength)
    {
        long total = 0;
        for (int i = minLength; i <= maxLength; i++)
        {
            total += CalculatePower(charsetLength, i);
            
            if (total < 0)
                return long.MaxValue;
        }
        return total;
    }
    
    private long CalculatePower(int @base, int exponent)
    {
        long result = 1;
        for (int i = 0; i < exponent; i++)
        {
            if (result > long.MaxValue / @base)
                return long.MaxValue;
            result *= @base;
        }
        return result;
    }
    
    private IEnumerable<string> GenerateVariations(string word)
    {
        var variations = new HashSet<string>();
        
        if (string.IsNullOrEmpty(word))
            return variations;
        
        variations.Add(word.ToUpper());
        variations.Add(word.ToLower());
        if (word.Length > 0)
        {
            variations.Add(char.ToUpper(word[0]) + word[1..].ToLower());
        }
        
        for (int i = 0; i <= 9; i++)
        {
            variations.Add(word + i);
            variations.Add(i + word);
        }
        
        var commonSymbols = new[] { "!", "@", "#", "$", "%", "&", "*" };
        foreach (var symbol in commonSymbols)
        {
            variations.Add(word + symbol);
            variations.Add(symbol + word);
        }
        
        var leetReplacements = new Dictionary<char, string>
        {
            ['a'] = "4", ['A'] = "4",
            ['e'] = "3", ['E'] = "3",
            ['i'] = "1", ['I'] = "1",
            ['o'] = "0", ['O'] = "0",
            ['s'] = "5", ['S'] = "5",
            ['t'] = "7", ['T'] = "7"
        };
        
        string leetWord = word;
        foreach (var replacement in leetReplacements)
        {
            leetWord = leetWord.Replace(replacement.Key.ToString(), replacement.Value);
        }
        if (leetWord != word)
            variations.Add(leetWord);
        
        return variations;
    }
    
    public string ComputeHash(string input, HashAlgorithmName algorithmName)
    {
        HashAlgorithm algorithm = algorithmName.Name switch
        {
            "MD5" => MD5.Create(),
            "SHA1" => SHA1.Create(),
            "SHA256" => SHA256.Create(),
            "SHA384" => SHA384.Create(),
            "SHA512" => SHA512.Create(),
            _ => throw new ArgumentException("خوارزمية تجزئة غير معروفة")
        };
        
        using (algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = algorithm.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes).ToLower();
        }
    }
    
    public HashAlgorithmName GetHashAlgorithmName(string algorithmName)
    {
        return algorithmName switch
        {
            "MD5" => HashAlgorithmName.MD5,
            "SHA1" => HashAlgorithmName.SHA1,
            "SHA256" => HashAlgorithmName.SHA256,
            "SHA384" => HashAlgorithmName.SHA384,
            "SHA512" => HashAlgorithmName.SHA512,
            _ => HashAlgorithmName.SHA256
        };
    }
    
    public void Stop()
    {
        _isRunning = false;
        _cts?.Cancel();
        OnStatusChanged("تم إيقاف الهجوم");
        _logger?.LogInfo("PasswordCracker", "تم إيقاف الهجوم يدوياً");
    }
    
    public bool IsRunning => _isRunning;
    public long Attempts => _attempts;
    public TimeSpan Elapsed => _isRunning ? DateTime.UtcNow - _startTime : TimeSpan.Zero;
    public double Speed => Elapsed.TotalSeconds > 0 ? Attempts / Elapsed.TotalSeconds : 0;
    
    public (long Attempts, TimeSpan Elapsed) GetStats()
    {
        if (!_isRunning && _startTime == DateTime.MinValue)
            return (0, TimeSpan.Zero);
        
        var elapsed = _isRunning ? DateTime.UtcNow - _startTime : TimeSpan.Zero;
        return (_attempts, elapsed);
    }
    
    protected virtual void OnPasswordFound(string password)
    {
        PasswordFound?.Invoke(this, password);
    }
    
    protected virtual void OnProgressChanged(int progress, long attempts, TimeSpan elapsed)
    {
        ProgressChanged?.Invoke(this, (progress, attempts, elapsed));
    }
    
    protected virtual void OnStatusChanged(string status)
    {
        StatusChanged?.Invoke(this, status);
    }
    
    public void ClearWordlist()
    {
        _wordlist.Clear();
        _logger?.LogInfo("PasswordCracker", "تم مسح قائمة الكلمات");
    }
    
    public int WordlistCount => _wordlist.Count;
    
    public IEnumerable<string> GetCommonPasswords()
    {
        return new[]
        {
            "password", "123456", "12345678", "1234", "qwerty",
            "12345", "dragon", "football", "monkey", "letmein",
            "admin", "welcome", "password1", "123123", "sunshine",
            "master", "hello", "charlie", "aa123456", "donald",
            "computer", "tigger", "shadow", "harley", "hockey",
            "george", "michael", "snoopy", "jessica", "pepper",
            "111111", "zaq1zaq1", "mustang", "access", "jordan",
            "abcd", "test", "secret", "letmein123", "password123"
        };
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                Stop();
                _cts?.Dispose();
                ClearWordlist();
            }
            _disposed = true;
        }
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    ~PasswordCracker()
    {
        Dispose(false);
    }
}