using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestWPFApp.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
        public StudentsManagementViewModel StudentManagement => App.Host.Services.GetRequiredService<StudentsManagementViewModel>();
    }
}
