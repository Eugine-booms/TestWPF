using System;
using System.Collections.Generic;
using System.Text;
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





    }
}
