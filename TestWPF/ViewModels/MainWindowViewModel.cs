using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using TestWPFApp.Infrastructure.Commands;
using TestWPFApp.Model;
using TestWPFApp.Model.Decant;
using TestWPFApp.Services.Interfaces;
using TestWPFApp.ViewModels.Base;


namespace TestWPFApp.ViewModels
{
    [MarkupExtensionReturnType(typeof(MainWindowViewModel))]
    internal class MainWindowViewModel : ViewModel
    {



        #region fuelControl : double  - Индикатор топлива
        ///<summary> Индикатор топлива
        private double _fuelControl;
        ///<summary> Индикатор топлива
        public double FuelControl
        {
            get => _fuelControl;
            set => Set(ref _fuelControl, value);
        }
        #endregion


        #region Coefficient : double  - Коэффициент
        ///<summary> Коэффициент
        private double _сoefficient = 1;
        ///<summary> Коэффициент
        public double Сoefficient
        {
            get => _сoefficient;
            set => Set(ref _сoefficient, value);
        }
        #endregion

        private readonly IAsycDataService _asycDataService;


        public WebServerViewModel WebServerViewModel { get; }

        #region Country
        public CountryStatisticViewModel CountryStatisticViewModel { get; }

        #endregion




        #region Directory


        public DirectoryViewModel DiskRootDir { get; } = new DirectoryViewModel("d:\\");

        #region selectedPath : DirectoryViewModel  - Выбранная директория
        ///<summary> Выбранная директория
        private DirectoryViewModel _selectedPath;
        ///<summary> Выбранная директория
        public DirectoryViewModel SelectedPath
        {
            get => _selectedPath;
            set => Set(ref _selectedPath, value);
        }
        #endregion


        #endregion

        /*--------------------------------------------------------------------------------------*/
        #region Коллекция разнородных объектов  


        public object[] CompositeCollection { get; private set; }

        #region selectedCompositeValue : object  - Выбранный непонятный элемент
        ///<summary> Выбранный непонятный элемент
        private object _selectedCompositeValue;
        ///<summary> Выбранный непонятный элемент
        public object SelectedCompositeValue
        {
            get => _selectedCompositeValue;
            set => Set(ref _selectedCompositeValue, value);
        }
        #endregion
        #endregion
        //-------------------------------------------------------------------------------------------
        #region Студенты
        public IEnumerable<Student> TestStudents =>

            Enumerable.Range(1, App.IsDesigneMode ? 10 : 100)
            .Select(i => new Student()
            {
                Name = $"Имя {i}",
                Surname = $"Фамилия {i}"
            });

        public ObservableCollection<Group> Groups { get; set; }

        #region selectedGroup : Group  - Выбранная группа
        ///<summary> Выбранная группа
        private Group _selectedGroup;
        ///<summary> Выбранная группа
        public Group SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                if (!Set(ref _selectedGroup, value)) return;
                _selectedGroupStudents.Source = value?.Students;
                OnPropertyChanged(nameof(SelectedGroupStudents));
            }
        }
        #endregion

        #region Сортировка студентов
        private readonly CollectionViewSource _selectedGroupStudents = new CollectionViewSource();
        public ICollectionView SelectedGroupStudents => _selectedGroupStudents?.View;
        private void SelectedGroupStudents_Filter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Student student))
            {
                e.Accepted = false;
                return;
            }
            if (student.Name is null || student.Surname is null)
            {
                e.Accepted = false;
                return;
            }
            var searchText = SelectedGroupStudentSerchTextBox;
            if (string.IsNullOrWhiteSpace(searchText)) return;
            if (student.Name.Contains(searchText.Trim(' '), StringComparison.OrdinalIgnoreCase)
                || student.Surname.Contains(searchText.Trim(' '), StringComparison.OrdinalIgnoreCase)) return;
            e.Accepted = false;
        }

        #region selectedGroupStudentSerchTextBox : string  - Строка поиска студента
        ///<summary> Строка поиска студента
        private string _selectedGroupStudentSerchTextBox;
        ///<summary> Строка поиска студента
        public string SelectedGroupStudentSerchTextBox
        {
            get => _selectedGroupStudentSerchTextBox;
            set
            {
                if (!Set(ref _selectedGroupStudentSerchTextBox, value)) return;
                _selectedGroupStudents.View.Refresh();

            }

        }
        #endregion

        #endregion

        #region tabControlItemCount : int  - Количество вкладок в TabControl
        ///<summary> Количество вкладок в TabControl
        private int _tabControlItemCount = 5;
        ///<summary> Количество вкладок в TabControl
        public int TabControlItemCount
        {
            get => _tabControlItemCount;
            set => Set(ref _tabControlItemCount, value);
        }
        #endregion

        #region selectedPageIndex : int  - Номер выбранной вкладки
        ///<summary> Номер выбраной вкладки
        private int _selectedPageIndex = 6;
        ///<summary> Номер выбраной вкладки
        public int SelectedPageIndex
        {
            get => _selectedPageIndex;
            set => Set(ref _selectedPageIndex, value);
        }
        #endregion
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

        /*--------------------------------------------------------------------------------------*/

        #region Команды
        #region ChangeTabIndexCommand

        public ICommand ChangeTabIndexCommand { get; }
        private bool CanChangeTabIndexCommandExecute(object p) => SelectedPageIndex >= 0;
        private void OnChangeTabIndexCommandExecuted(object p)
        {
            if ((p is null)) return;
            int nextPageIndex = SelectedPageIndex + Convert.ToInt32(p);
            if (nextPageIndex >= 0 && nextPageIndex < TabControlItemCount)
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
            //(RootObject as Window)?.Close();
            //
        }
        #endregion

        #region CreateNewGroupCommand

        public ICommand CreateNewGroupCommand { get; }

        private bool CanCreateNewGroupExecute(object p) => true;
        private void OnCreateNewGroupExecuted(object p)
        {
            var group_max_index = Groups.Count + 1;
            var new_group = new Group()
            {
                Name = $"Группа {group_max_index}",
                Students = new ObservableCollection<Student>()
            };
            Groups.Add(new_group);
        }
        #endregion

        #region DeleteGroupCommand

        public ICommand DeleteGroupCommand { get; }



        private bool CanDeleteGroupExecute(object p) => p is Group group && Groups.Contains(group);
        private void OnDeleteGroupExecuted(object p)
        {
            if (!(p is Group group)) return;
            var groupIndex = Groups.IndexOf(group);
            Groups.Remove(group);
            if (groupIndex < Groups.Count)
            {
                SelectedGroup = Groups[groupIndex];
            }
        }
        #endregion


        #region Команды для демонстрации асинхронного сервиса


        #region dataValue : string  - Результат 
        ///<summary> Результат 
        private string _dataValue;
        ///<summary> Результат 
        public string DataValue
        {
            get => _dataValue;
            private set => Set(ref _dataValue, value);
        }
        #endregion


        #region Команда СТАРТ
        public ICommand StartProcessCommand { get; }
        private bool CanStartProcessCommandExecute(object arg) => true;


        private void OnStartProcessCommandExecuted(object obj)
        {
            new Thread(ComputeValue).Start();
        }

        private void ComputeValue()
        {
            DataValue = _asycDataService.GetResult(DateTime.Now);
        }

        #endregion

        #region Команда СТОП
        public ICommand StopProcessCommand { get; }

        private bool CanStopProcessCommandExecute(object arg) => true;


        private void OnStopProcessCommandExecuted(object obj)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion





        #endregion
        /*--------------------------------------------------------------------------------------*/
        #region Конструктор 

        public MainWindowViewModel(CountryStatisticViewModel Statistic, IAsycDataService asycDataService, WebServerViewModel webServerViewModel)
        {
            _asycDataService = asycDataService;
            WebServerViewModel = webServerViewModel;
            CountryStatisticViewModel = Statistic;
            Statistic.MainViewMidel = this;
            #region Command

            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExicuted, CanCloseAppCommandExicute);
            ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecuted, CanChangeTabIndexCommandExecute);
            CreateNewGroupCommand = new LambdaCommand(OnCreateNewGroupExecuted, CanCreateNewGroupExecute);
            DeleteGroupCommand = new LambdaCommand(OnDeleteGroupExecuted, CanDeleteGroupExecute);
            StartProcessCommand = new LambdaCommand(OnStartProcessCommandExecuted, CanStartProcessCommandExecute);
            StopProcessCommand = new LambdaCommand(OnStopProcessCommandExecuted, CanStopProcessCommandExecute);

            #endregion
            TestDataPoint = GenerateTestDataPoint();
            var student_index = 1;
            var students = Enumerable.Range(1, 10).Select(i => new Student()
            {
                Name = $"Name {student_index}",
                Surname = $"Surname {student_index}",
                Patronumic = $"Patronumic {student_index++}",
                Birthday = DateTime.Now,
                Rating = 0
            });
            var groups = Enumerable.Range(1, 20).Select(i => new Group()
            {
                Name = $"Группа {i}",
                Students = new ObservableCollection<Student>(students)
            });
            Groups = new ObservableCollection<Group>(groups);


            var data_list = new List<object>();
            data_list.Add("Hello");
            data_list.Add(42);
            var group = Groups[1];
            data_list.Add(group);
            data_list.Add(group.Students[0]);
            CompositeCollection = data_list.ToArray();
            _selectedGroupStudents.Filter += SelectedGroupStudents_Filter;
            //можно задать различные сортировки и групировки для ollectionViewSource
            //_selectedGroupStudents.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Descending));
            //_selectedGroupStudents.GroupDescriptions.Add(new PropertyGroupDescription("Name"));
        }




        #endregion
        /*--------------------------------------------------------------------------------------*/
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
        /*--------------------------------------------------------------------------------------*/

    }
}
