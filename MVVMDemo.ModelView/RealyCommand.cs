using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMDemo.ModelView
{
    public class RealyCommand : ICommand
    {

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        public RealyCommand(Action<object> execute):this(execute,null)
        {

        }

        public RealyCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute==null)
            {
                throw new ArgumentNullException("Execute");                
            }
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
