using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TestWPFApp.Infrastructure.Commands;
using TestWPFApp.Model.Decant;
using TestWPFApp.Services.Interfaces;
using TestWPFApp.Services.Students;
using TestWPFApp.View.Windows;
using TestWPFApp.ViewModels.Base;

namespace TestWPFApp.ViewModels
{
    internal class StudentsManagementViewModel : ViewModel
    {
        private readonly StudentsManager studentsManager;
        private readonly IUserDialogService userDialog;

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
        public StudentsManagementViewModel(StudentsManager studentsManager, IUserDialogService userDialog)
        {
            this.studentsManager = studentsManager;
            this.userDialog = userDialog;
        }
        #endregion

        public IEnumerable<Student> Students => studentsManager.Students;
        public IEnumerable<Group> Groups => studentsManager.Groups;
        #region Команды
        #region Команда редактирования
        private ICommand editStudentCommand;
        public ICommand EditStudentCommand => editStudentCommand ??= new LambdaCommand(OnEditStudentCommandExicuted, CanEditStudentCommandExicute);

        private bool CanEditStudentCommandExicute(object obj) => obj is Student;

        private void OnEditStudentCommandExicuted(object arg)
        {
            if (userDialog.Edit(arg))
            {
                studentsManager.Update((Student)arg);
                userDialog.ShowInformation("Студент отредактирован", "Менеджен студентов");
            }
            else
            {
                userDialog.ShowWarning("Отказ от редактирования", "Менеджер студентов");
            }

            OnPropertyChanged(nameof(Group));
            OnPropertyChanged(nameof(Student));





        }
#endregion
        #region Команда Добавления
        private ICommand addStudentCommand;
        public ICommand AddStudentCommand => addStudentCommand ??= new LambdaCommand(OnAddStudentCommandExicuted, CanAddStudentCommandExicute);

        private bool CanAddStudentCommandExicute(object obj) => SelectedGroup != null;

        private void OnAddStudentCommandExicuted(object arg)
        {
            var student = new Student();
            if (userDialog.Edit(student)|| !(userDialog.Confim("Не удалось создать, повторить?", "Менеджер студентов")))

            if (!studentsManager.CreateNewStudent(student, SelectedGroup.Name))
            { 
                    OnPropertyChanged(nameof(Student));
            }


            //else userDialog.ShowWarning("Отказ от добавления", "Менеджер студентов");

        }
        #endregion
        #endregion



    }
}
