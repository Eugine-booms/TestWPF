using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace TestWPFApp.Infrastructure.Commands
{
    internal class CloseWindowCommand : Base.Command
    {
        public override bool CanExecute(object parameter) => parameter is Window;

        public override void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            var window = (Window)parameter;
            window.Close();
        }
    }
}
