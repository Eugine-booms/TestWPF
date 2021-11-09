using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TestWPFApp.Infrastructure.Commands.Base;

namespace TestWPFApp.Infrastructure.Commands
{
    internal class CloseAppCommand : Command
    {
        public override bool CanExecute(object parameter) => true;
        

        public override void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
