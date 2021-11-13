using System;
using System.Collections.Generic;
using System.Text;
using TestWPFApp.Services;

namespace TestWPFApp.ViewModels
{
    internal class CountryStatisticViewModel : ViewModels.Base.ViewModel
    {
        private MainWindowViewModel MainViewMidel { get; }
        private DataService dataService;

        public CountryStatisticViewModel(MainWindowViewModel mainViewMidel)
        {
            this.MainViewMidel = mainViewMidel;
            dataService = new DataService();
        }
    }
}
