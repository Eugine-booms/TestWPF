using System;
using System.Collections.Generic;
using System.Text;
using TestWPFApp.Services.Interfaces;

namespace TestWPFApp.Services
{
    class WindowsUserDialogService : IUserDialogServis
    {
        public bool Confim(string message, string Caption, bool Exclamation = false)
        {
            throw new NotImplementedException();
        }

        public bool Edit(object item)
        {
            throw new NotImplementedException();
        }

        public void ShowError(string message, string Caption)
        {
            throw new NotImplementedException();
        }

        public void ShowInformation(string information, string Caption)
        {
            throw new NotImplementedException();
        }

        public void ShowWarning(string message, string Caption)
        {
            throw new NotImplementedException();
        }
    }
}
