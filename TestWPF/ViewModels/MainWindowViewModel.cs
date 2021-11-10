using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TestWPFApp.Infrastructure.Commands;
using TestWPFApp.Model;
using TestWPFApp.ViewModels.Base;


namespace TestWPFApp.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        #region tabControlItemCount : int  - Количество вкладок в TabControl
        ///<summary> Количество вкладок в TabControl
        private int _tabControlItemCount=5;
        ///<summary> Количество вкладок в TabControl
        public int TabControlItemCount
        {
            get => _tabControlItemCount;
            set => Set(ref _tabControlItemCount, value);
        }
        #endregion

        #region selectedPageIndex : int  - Номер выбранной вкладки
        ///<summary> Номер выбраной вкладки
        private int _selectedPageIndex;
        ///<summary> Номер выбраной вкладки
        public int SelectedPageIndex
        {
            get => _selectedPageIndex;
            set => Set(ref _selectedPageIndex, value);
        }
        #endregion


        #region testDataPoint : IEnumerable  - Тестовый набор данных для визуализации графиков
        ///<summary> Точки графика
        private IEnumerable<DataPoint> _testDataPoint;
        ///<summary> Точки графика
        public IEnumerable<DataPoint> TestDataPoint
        {
            get => _testDataPoint;
            set => Set(ref _testDataPoint, value);
        }
        #endregion

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
        private string _status = "Готов";



        ///<summary> Статус программы
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
        #endregion

        #region Команды
        #region ChangeTabIndexCommand

        
        public ICommand ChangeTabIndexCommand { get; }
        private bool CanChangeTabIndexCommandExecute(object p) => SelectedPageIndex >= 0;
        private void OnChangeTabIndexCommandExecuted(object p)
        {
            if ((p is null)) return;
            int nextPageIndex = SelectedPageIndex+ Convert.ToInt32(p);
            if (nextPageIndex>=0 && nextPageIndex<TabControlItemCount)
            {
                SelectedPageIndex += Convert.ToInt32(p);
            }
            
        }
        #endregion

        #region CloseAppCommand


        public ICommand CloseAppCommand { get; }
        /// <summary>
        /// Может ли выполниться команда
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Может ли выполниться команда</returns>
        private bool CanCloseAppCommandExicute(object p) => true;
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

        #region Конструктор 

        public MainWindowViewModel()
        {
            #region Command

            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExicuted, CanCloseAppCommandExicute);
            ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecuted, CanChangeTabIndexCommandExecute);
            #endregion

            TestDataPoint = GenerateTestDataPoint(); ;
        }
        #endregion

        #region Вспомогательные методы

        
        private static List<DataPoint> GenerateTestDataPoint()
        {
            var data_points = new List<DataPoint>((int)(360 / 0.1));
            for (var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);
                data_points.Add(new DataPoint { XValue = x, YValue = y });
            }
            return data_points;
        }
        #endregion


    }
}
