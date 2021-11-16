using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TestWPFApp.Services;
using TestWPFApp.ViewModels;

namespace TestWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsDesigneMode { get; private set; } = true;

        

        protected override void OnStartup(StartupEventArgs e)
        {
            IsDesigneMode = false;
            base.OnStartup(e);
        }

        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<DataService>();
            services.AddSingleton<CountryStatisticViewModel>();

        }
    }
}
