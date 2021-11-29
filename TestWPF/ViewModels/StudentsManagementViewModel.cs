using System;
using System.Collections.Generic;
using System.Text;
using TestWPFApp.Model.Decant;
using TestWPFApp.Services.Students;
using TestWPFApp.ViewModels.Base;

namespace TestWPFApp.ViewModels
{
    internal class StudentsManagementViewModel : ViewModel
    {
        private readonly StudentsManager studentsManager;

        #region Заголовок окна
        private string title = "Управление студентами";

        public string Title
        {
            get { return title; }
            set { Set(ref title, value); }
        }


        #endregion

        #region selectedGroup : Group  - Выбранная группа студентов
        ///<summary> Выбранная группа студентов
        private Group _selectedGroup;
        ///<summary> Выбранная группа студентов
        public Group SelectedGroup
        {
            get => _selectedGroup;
            set => Set(ref _selectedGroup, value);
        }
        #endregion

        #region selectedStudent : Student  - Выбраны студент
        ///<summary> Выбраны студент
        private Student _selectedStudent;
        ///<summary> Выбраны студент
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set => Set(ref _selectedStudent, value);
        }
        #endregion


        #region Конструктор
        public StudentsManagementViewModel(StudentsManager studentsManager)
        {
            this.studentsManager = studentsManager;
        }
        #endregion

        public IEnumerable<Student> Students => studentsManager.Students;
        public IEnumerable<Group> Groups => studentsManager.Groups;




    }
}
