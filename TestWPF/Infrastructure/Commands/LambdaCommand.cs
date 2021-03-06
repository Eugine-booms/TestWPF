using System;
using System.Collections.Generic;
using System.Text;
using TestWPFApp.Infrastructure.Commands.Base;

namespace TestWPFApp.Infrastructure.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;
        public LambdaCommand(Action<object> execute, Func<object, bool> canExecute=null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(Execute));
            _canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute(parameter);
            return true;
            //сократили предыдущее
            //return _canExecute?.Invoke(parameter) ?? true;
        }

        public override void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            _execute(parameter);
        }

        
    }
}
