using Microsoft.Extensions.DependencyInjection;
using SecureDataProtectionTool.Logging;
using SecureDataProtectionTool.UI;
using System.Runtime.Versioning;

namespace SecureDataProtectionTool;

[SupportedOSPlatform("windows")]
internal static class Program
{
    [STAThread]
    [SupportedOSPlatform("windows")]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        
        // Setup DI Container
        var services = new ServiceCollection();
        ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();
        
        // Handle unhandled exceptions
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += Application_ThreadException;
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        
        var mainForm = serviceProvider.GetRequiredService<MainForm>();
        Application.Run(mainForm);
    }
    
    private static void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton<LogService>();
        services.AddSingleton<Core.KeyDerivationService>();
        services.AddSingleton<Core.CryptoEngine>();
        services.AddSingleton<Core.FileEncryptionService>();
        services.AddSingleton<Core.TextEncryptionService>();
        services.AddSingleton<Core.PasswordGenerator>();
        services.AddSingleton<Core.CustomCryptography>();
        services.AddSingleton<Core.PasswordCracker>();
        services.AddSingleton<Utils.SettingsManager>();
        
        services.AddTransient<MainForm>();
        services.AddTransient<FileEncryptionForm>();
        services.AddTransient<FileDecryptionForm>();
        services.AddTransient<TextEncryptionForm>();
        services.AddTransient<TextDecryptionForm>();
        services.AddTransient<LogsForm>();
        services.AddTransient<SettingsForm>();
        services.AddTransient<PasswordGeneratorForm>();
        services.AddTransient<PasswordCrackerForm>();
    }
    
    private static void Application_ThreadException(object? sender, System.Threading.ThreadExceptionEventArgs e)
    {
        MessageBox.Show($"خطأ غير معالج: {e.Exception.Message}\n\n{e.Exception.StackTrace}", 
            "خطأ في التطبيق", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    
    private static void CurrentDomain_UnhandledException(object? sender, UnhandledExceptionEventArgs e)
    {
        var ex = e.ExceptionObject as Exception;
        MessageBox.Show($"خطأ فادح: {ex?.Message}\n\n{ex?.StackTrace}", 
            "خطأ فادح", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}