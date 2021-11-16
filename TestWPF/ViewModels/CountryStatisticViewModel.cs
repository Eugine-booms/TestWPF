using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TestWPFApp.Model;
using TestWPFApp.Services;
using TestWPFApp.Services.Interfaces;

namespace TestWPFApp.ViewModels
{
    internal class CountryStatisticViewModel : ViewModels.Base.ViewModel
    {
        public MainWindowViewModel MainViewMidel { get; internal set; }

        private readonly IDataService dataService;


        #region selectedCountry : CountryInfo  - Выбранная страна
        ///<summary> Выбранная страна
        private CountryInfo _selectedCountry;
        ///<summary> Выбранная страна
        public CountryInfo SelectedCountry
        {
            get => _selectedCountry;
            set => Set(ref _selectedCountry, value);
        }

        #endregion


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
        public ICommand RefreshDataCommand { get; }
        private bool CanRefreshDataCommandExecute(object p) => true;
        private void OnRefreshDataCommandExecuted(object p)
        {
            Countries = dataService.GetData();
        }
        #endregion


        #endregion

        /// <summary>
        /// Отладочный конструктор, для визуального дизайнера
        /// </summary>
        //public CountryStatisticViewModel():this(null)
        //{
        //    if (!App.IsDesigneMode) 
        //        throw new InvalidOperationException("Вызов конструктора не предназначенного для использования в обычном режиме");
        //    _countries = Enumerable.Range(1, 10)
        //        .Select(x => new CountryInfo()
        //        {
        //            Name = $"Country {x}",
        //            ProvinceCount = Enumerable.Range(1, 10).Select(j => new PlaceInfo()
        //            {
        //                Name = $"Province {j}",
        //                Location = new Point(x, j),
        //                InfectedCounts = Enumerable.Range(1, 10).Select(k => new ConfimedCount()
        //                {
        //                    Date = DateTime.Now.Subtract(TimeSpan.FromDays(100 - k)),
        //                    Count = k
        //                }).ToArray()

        //            }).ToArray(),
        //        }
        //        ).ToArray();
        //}
        public CountryStatisticViewModel(IDataService dataService)
        {
            //this.MainViewMidel = mainViewMidel;
            this.dataService = dataService;
            RefreshDataCommand = new Infrastructure.Commands.LambdaCommand(OnRefreshDataCommandExecuted);
        }
    }
}
