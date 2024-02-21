using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MVVM_WPF_Schedule;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        var app = new App();
        app.InitializeComponent();
        app.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] Args)
    {
        return Host.CreateDefaultBuilder(Args)
            .UseContentRoot(App.CurrentDirectory)
            .ConfigureAppConfiguration((host, cfg) => cfg
                .SetBasePath(App.CurrentDirectory)
                .AddJsonFile("appsettings.json", true, true)
            )
            .ConfigureServices(App.ConfigureServices)
            .ConfigureLogging(builder => {

                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Trace);
            });
    }
}