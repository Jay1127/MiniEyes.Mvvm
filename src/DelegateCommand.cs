using System;
using System.Windows.Input;

namespace MiniMvvm
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _executeMethod;
        private readonly Func<bool> _canExecuteMethod;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public DelegateCommand(Action executeMethod)
            : this(executeMethod, () => true)
        {

        }

        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _executeMethod = executeMethod ?? throw new ArgumentNullException(nameof(executeMethod));
            _canExecuteMethod = canExecuteMethod ?? throw new ArgumentNullException(nameof(canExecuteMethod));
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteMethod();
        }

        public void Execute(object parameter)
        {
            _executeMethod();
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}