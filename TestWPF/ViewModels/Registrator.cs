using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestWPFApp.ViewModels
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<CountryStatisticViewModel>();
            services.AddSingleton<WebServerViewModel>();
            services.AddTransient<StudentsManagementViewModel>();
            //App.Host.Services.GetRequiredService<DataService>().GetData();
            return services;
        }
    }
}
