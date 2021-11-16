using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using TestWPFApp.Services;
using TestWPFApp.Services.Interfaces;
using TestWPFApp.ViewModels;

namespace TestWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsDesigneMode { get; private set; } = true;

        private static IHost host1;

        public static IHost Host => host1 ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        //protected virtual void OnStartup(StartupEventArgs e);
        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesigneMode = false;
            var host = Host;
            base.OnStartup(e);
            await host.StartAsync().ConfigureAwait(false);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            var host = Host;
            await host.StopAsync().ConfigureAwait(false);
            host1 = null;
            
            

        }
        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<IDataService, DataService>();


            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<CountryStatisticViewModel>();


            //App.Host.Services.GetRequiredService<DataService>().GetData();


        }

        public static string CurrentDirectory => IsDesigneMode
            ? Path.GetDirectoryName(GetSourceCodePath())
            : Environment.CurrentDirectory;

        private static string GetSourceCodePath([CallerFilePath] string Path = null) => Path;
    }
}
