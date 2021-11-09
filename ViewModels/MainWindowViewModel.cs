using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TestWPFApp.Infrastructure.Commands;
using TestWPFApp.ViewModels.Base;


namespace TestWPFApp.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        
        #region Title : string  - Заголовок окна


        private string _title = "New Window";

        /// <summary> Заголовок окна </summary>
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
            //то что мы должны были писать но нам помог базовый класс VM
            //if (Equals(_Title, value)) return;
            //_Title = value;
            //OnPropertyChanged();
        }
        #endregion

        #region status : string  - Статус программы
        ///<summary> Статус программы
        private string _status= "Готов";

        

        ///<summary> Статус программы
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
        #endregion

        #region Команды
        #region CloseAppCommand

        
        public ICommand CloseAppCommand { get; }
        /// <summary>
        /// Может ли выполниться команда
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Может ли выполниться команда</returns>
        private bool CanCloseAppCommandExicute(object p)  => true;
        /// <summary>
        /// Выполняется в момент выполнения команды
        /// </summary>
        /// <param name="p"></param>
        private void OnCloseAppCommandExicuted(object p) 
        {
            Application.Current.Shutdown();
        }
        #endregion

        #endregion
        public MainWindowViewModel()
        {
            #region Command

            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExicuted, CanCloseAppCommandExicute);

            #endregion
        }



    }
}
