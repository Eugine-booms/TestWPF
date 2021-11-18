using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestWPFApp.Infrastructure.Commands;
using TestWPFApp.ViewModels.Base;

namespace TestWPFApp.ViewModels
{
    internal class WebServerViewModel : ViewModel
    {
        #region Enable
        private bool _enabled;
        public bool Enabled 
        { 
            get => _enabled; 
            set => Set(ref _enabled, value); 
        }

        #endregion

        #region Команда запуска
        private ICommand _startCommand;
        public ICommand StartCommand => _startCommand ??= new LambdaCommand(OnStartCommandExecuted, CanStartCommandExecute);

        private bool CanStartCommandExecute(object p) => !Enabled;
        private void OnStartCommandExecuted(object p)
        {
            Enabled = true;
        }
        #endregion


        #region Команда остановки
        private ICommand _stopCommand;
        public ICommand StopCommand => _stopCommand ??= new LambdaCommand(OnStopCommandExecuted, CanStopCommandExecute);
        private bool CanStopCommandExecute(object p) => Enabled;
        private void OnStopCommandExecuted(object obj)
        {
            Enabled = false;
        }
        #endregion


    }
}
