using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TestWPFApp.View.Windows;


namespace TestWPFApp.Infrastructure.Commands
{
    internal class OpenWindowManageStudentCommand : Base.Command
    {
        private StudentsManagementWindow _window;
        public override bool CanExecute(object parameter) => _window != null;

        public override void Execute(object parameter)

        {
            var window = new StudentsManagementWindow
            {
                Owner = Application.Current.MainWindow

            };
            _window = window;
            window.Closed += OnWindowClosed; 
            {
                
            }

            window.ShowDialog();
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            ((Window)sender).Closed -= OnWindowClosed;
            _window = null;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
