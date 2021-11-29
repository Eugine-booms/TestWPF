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
        private static Window ActiveWindow => Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
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
                Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
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

        public string GetStringValue(string message, string caption, string defaultValue = null)
        {
            var value_dialog = new StringValueDialogWindow()
            {
                Message = message,
                Title = caption,
                Value = defaultValue ?? string.Empty,
                Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner

            };
          return  value_dialog.ShowDialog() == true ? value_dialog.Value : defaultValue; 
        }
    }
}
