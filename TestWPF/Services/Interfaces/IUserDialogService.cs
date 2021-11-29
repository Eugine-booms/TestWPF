using System;
using System.Collections.Generic;
using System.Text;

namespace TestWPFApp.Services.Interfaces
{
    interface IUserDialogService
    {
        bool Edit(object item);
        void ShowInformation(string information, string Caption);
        void ShowWarning(string message, string Caption);
        void ShowError(string message, string Caption);
        bool Confim(string message, string Caption, bool Exclamation = false);

        string GetStringValue(string message, string Caption, string DefaultValue = default(string));
    }
}
