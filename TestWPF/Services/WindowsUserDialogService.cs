using System;
using System.Linq;
using System.Windows;
using TestWPFApp.Model.Decant;
using TestWPFApp.Services.Interfaces;
using TestWPFApp.View.Windows;

namespace TestWPFApp.Services
{
    class WindowsUserDialogService : IUserDialogService
    {
        public bool Confim(string message, string caption, bool exclamation = false) =>
            MessageBox.Show(
                message,
                caption,
                MessageBoxButton.YesNo,
                exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question)
            == MessageBoxResult.Yes;

        public bool Edit(object item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            switch (item)
            {
                case Student student:
                    return EditStudent(student);
                default:
                    throw new NotSupportedException($"Редактирование объектов типа {item.GetType().Name} не поддерживается");

            }

        }

        private bool EditStudent(Student student)
        {
            var dlg = new StudentEditorWindow()
            {
                FirstName = student.Name,
                LastName = student.Surname,
                Patronumic = student.Patronumic,
                Rating = student.Rating,
                Birthday = student.Birthday,
                Owner = Application.Current.Windows.OfType<StudentsManagementWindow>().FirstOrDefault(),
                WindowStartupLocation= WindowStartupLocation.CenterOwner
            };
            if (dlg.ShowDialog() != true) return false;

            student.Name = dlg.FirstName;
            student.Surname = dlg.LastName;
            student.Patronumic = dlg.Patronumic;
            student.Rating = dlg.Rating;
            student.Birthday = dlg.Birthday;
            

            return true;
        }

        public void ShowError(string message, string caption) => MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);

        public void ShowInformation(string message, string caption) => MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Information);

        public void ShowWarning(string message, string caption) => MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Warning);
    }
}
