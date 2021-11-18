using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestWPFApp.Infrastructure.Commands;
using TestWPFApp.Services.Interfaces;
using TestWPFApp.ViewModels.Base;

namespace TestWPFApp.ViewModels
{
    internal class WebServerViewModel : ViewModel
    {
        private readonly IWebServerService webServer;
        #region Enable
        public bool Enabled 
        { 
            get => webServer.Enabled; 
            set
            {
                webServer.Enabled = value;
                OnPropertyChanged(nameof(Enabled));
            }
        }

        #endregion

        #region Команда запуска
        private ICommand _startCommand;
        public ICommand StartCommand => _startCommand ??= new LambdaCommand(OnStartCommandExecuted, CanStartCommandExecute);

        private bool CanStartCommandExecute(object p) => !Enabled;
        private void OnStartCommandExecuted(object p)
        {
            //Enabled = true;
            webServer.Start(8080);
            OnPropertyChanged(nameof(Enabled));
        }
        #endregion


        #region Команда остановки
        private ICommand _stopCommand;
        

        public WebServerViewModel(IWebServerService webServer)
        {
            this.webServer = webServer;
        }

        public ICommand StopCommand => _stopCommand ??= new LambdaCommand(OnStopCommandExecuted, CanStopCommandExecute);
        private bool CanStopCommandExecute(object p) => Enabled;
        private void OnStopCommandExecuted(object obj)
        {
            //Enabled = false;
            webServer.Stop();
            OnPropertyChanged(nameof(Enabled));
        }
        #endregion


    }
}
