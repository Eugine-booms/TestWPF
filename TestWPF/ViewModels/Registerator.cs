﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestWPFApp.ViewModels
{
    internal static class Registerator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<CountryStatisticViewModel>();
            //App.Host.Services.GetRequiredService<DataService>().GetData();
            return services;
        }
    }
}
