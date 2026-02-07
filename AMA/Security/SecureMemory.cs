using System.Runtime.InteropServices;
using System.Security;

namespace SecureDataProtectionTool.Security;

public sealed class SecureMemory : IDisposable
{
    private IntPtr _ptr;
    private int _length;
    private bool _disposed;
    private readonly GCHandle _handle;
    
    public unsafe SecureMemory(byte[] data)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));
        
        _length = data.Length;
        
        // تثبيت البيانات في الذاكرة
        _handle = GCHandle.Alloc(data, GCHandleType.Pinned);
        _ptr = _handle.AddrOfPinnedObject();
        
        // تأمين الصفحات في الذاكرة
        LockMemory();
    }
    
    public unsafe SecureMemory(string data)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));
        
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
        _length = bytes.Length;
        
        _handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
        _ptr = _handle.AddrOfPinnedObject();
        
        LockMemory();
        
        // تنظيف المصفوفة الأصلية
        Array.Clear(bytes, 0, bytes.Length);
    }
    
    public byte[] GetBytes()
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(SecureMemory));
        
        byte[] copy = new byte[_length];
        Marshal.Copy(_ptr, copy, 0, _length);
        return copy;
    }
    
    public unsafe SecureString ToSecureString()
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(SecureMemory));
        
        byte* p = (byte*)_ptr.ToPointer();
        SecureString secureString = new SecureString();
        
        // تحويل البايتات إلى أحرف وإضافتها لـ SecureString
        for (int i = 0; i < _length; i++)
        {
            secureString.AppendChar((char)p[i]);
        }
        
        secureString.MakeReadOnly();
        return secureString;
    }
    
    public unsafe void Clear()
    {
        if (_disposed)
            return;
        
        // كتابة أصفار فوق البيانات
        byte* p = (byte*)_ptr.ToPointer();
        for (int i = 0; i < _length; i++)
        {
            p[i] = 0;
        }
    }
    
    public int Length => _length;
    
    public bool IsDisposed => _disposed;
    
    private void LockMemory()
    {
        try
        {
            if (!VirtualLock(_ptr, (UIntPtr)_length))
            {
                throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
            }
        }
        catch (EntryPointNotFoundException)
        {
            // VirtualLock غير مدعوم على هذا النظام، تجاهل
        }
    }
    
    private void UnlockMemory()
    {
        try
        {
            if (!VirtualUnlock(_ptr, (UIntPtr)_length))
            {
                // لا نرمي استثناء هنا لأننا في عملية التخلص
            }
        }
        catch (EntryPointNotFoundException)
        {
            // VirtualUnlock غير مدعوم، تجاهل
        }
    }
    
    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            Clear();
            UnlockMemory();
            
            if (_handle.IsAllocated)
            {
                _handle.Free();
            }
            
            _ptr = IntPtr.Zero;
            _length = 0;
            _disposed = true;
        }
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    ~SecureMemory()
    {
        Dispose(false);
    }
    
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool VirtualLock(IntPtr lpAddress, UIntPtr dwSize);
    
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool VirtualUnlock(IntPtr lpAddress, UIntPtr dwSize);
}