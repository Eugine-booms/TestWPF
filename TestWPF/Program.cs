using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestWPFApp
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] Args) =>
                Host.CreateDefaultBuilder(Args)
                .UseContentRoot(App.CurrentDirectory)
                .ConfigureAppConfiguration((host, cfg) => cfg.SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true))
                .ConfigureServices(App.ConfigureServices);
        //Это короткая форма записи вот этого 
        /*public static IHostBuilder CreateHostBuilder(string[] Args)
        {
            var host_builder = Host.CreateDefaultBuilder(Args);
            host_builder.UseContentRoot(Environment.CurrentDirectory);
            host_builder.ConfigureAppConfiguration((host, cfg) =>
            {
                cfg.SetBasePath(Environment.CurrentDirectory);
                cfg.AddJsonFile("appsettigs.json", optional: true, reloadOnChange: true);
            });

            host_builder.ConfigureServices(App.ConfigureServices);

            return host_builder;

        }*/


    }
}
