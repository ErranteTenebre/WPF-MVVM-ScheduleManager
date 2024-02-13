using CursachApp.Infrastructure;
using CursachApp.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Windows;
using CursachApp.Infrastructure.Repositories;
using System.Runtime.InteropServices.JavaScript;
using CursachApp.Services;

namespace CursachApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static  IHost _host;

        public static IHost Host => _host ??= Program.CreateHostBuilder([]).Build();

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.RegisterServices();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }

}
