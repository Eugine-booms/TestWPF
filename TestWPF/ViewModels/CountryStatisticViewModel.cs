using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestWPFApp.Model;
using TestWPFApp.Services;

namespace TestWPFApp.ViewModels
{
    internal class CountryStatisticViewModel : ViewModels.Base.ViewModel
    {
        private MainWindowViewModel MainViewMidel { get; }

        private readonly DataService dataService;


        #region countries : IEnumerable<CountryInfo>  - Статистика по странам
        ///<summary> "Статистика по странам"
        private IEnumerable<CountryInfo> _countries;
        ///<summary> "Статистика по странам"
        public IEnumerable<CountryInfo> Countries
        {
            get => _countries;
            private set => Set(ref _countries, value);
        }
        #endregion


        #region Команды

        #region RefreshDataCommand
        public ICommand RefreshDataCommand{get;}
        private bool CanRefreshDataCommandExecute(object p) => true;
        private void OnRefreshDataCommandExecuted(object p)
        {
            Countries = dataService.GetData();
        }
        #endregion


        #endregion

        public CountryStatisticViewModel(MainWindowViewModel mainViewMidel)
        {
            this.MainViewMidel = mainViewMidel;
            dataService = new DataService();
            RefreshDataCommand = new Infrastructure.Commands.LambdaCommand(OnRefreshDataCommandExecuted);
        }
    }
}
