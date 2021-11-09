using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TestWPFApp.Infrastructure.Commands.Base
{
    internal abstract class Command : ICommand
    {
        /// <summary>
        /// Событие генерируется когда меняется состояние CanExecute
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            //передача управление системе 
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        /// <summary>
        /// Говорит может быть выполнена команда в зависимости от параметра
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>true - команда может быть выполнена, false - не может </returns>
        public abstract bool CanExecute(object parameter);

        /// <summary>
        /// Выполнение команды
        /// </summary>
        /// <param name="parameter"></param>
        public abstract void Execute(object parameter);
        
    }
}
