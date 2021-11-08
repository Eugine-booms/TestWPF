using System;
using System.Collections.Generic;
using System.Text;
using TestWPFApp.ViewModels.Base;


namespace TestWPFApp.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        private string _Title = "New Window";

        /// <summary> Заголовок окна </summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
            //то что мы должны были писать но нам помог базовый класс VM
            //if (Equals(_Title, value)) return;
            //_Title = value;
            //OnPropertyChanged();
        }
    }
}
