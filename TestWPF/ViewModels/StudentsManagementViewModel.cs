using System;
using System.Collections.Generic;
using System.Text;
using TestWPFApp.ViewModels.Base;

namespace TestWPFApp.ViewModels
{
    internal class StudentsManagementViewModel  : ViewModel
    {

        #region Заголовок окна
private string title = "Управление студентами";

        public string Title
        {
            get { return  title; }
            set { Set(ref title, value); }
        }
#endregion




    }
}
