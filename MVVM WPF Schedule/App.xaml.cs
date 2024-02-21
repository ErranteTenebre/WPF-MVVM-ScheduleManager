using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVM_WPF_Schedule.Services;

namespace MVVM_WPF_Schedule;

public partial class App : Application
{
    public static IHost Host;
    public static IConfiguration Configuration { get; set; }
    public static bool IsDesignMode { get; private set; } = true;

    public static string CurrentDirectory =>
        IsDesignMode ? Path.GetDirectoryName(GetSourceCodePath()) : Environment.CurrentDirectory;
    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
        Configuration = builder.Build();
        IsDesignMode = false;

        Host = Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        await Host.StartAsync().ConfigureAwait(false);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
        await Host.StopAsync().ConfigureAwait(false);
        Host.Dispose();
    }

    public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
    {
        services.RegisterServices(Configuration);
    }

    private static string GetSourceCodePath([CallerFilePath] string Path = null)
    {
        if (string.IsNullOrWhiteSpace(Path))
            throw new ArgumentNullException(nameof(Path));
        return Path;
    }
}