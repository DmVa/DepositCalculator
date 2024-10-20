﻿using System.Windows.Input;

namespace DepositCalculator.Common
{
    public class BaseCommand : ICommand
    {
        private Action _action;
        private Func<bool> _canExecute;

        public BaseCommand(Action action, Func<bool> canExecute) 
        {
            _action = action;
            _canExecute = canExecute;
        }

      
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
       
        public bool CanExecute(object? parameter)
        {
            return _canExecute.Invoke();
        }

        public void Execute(object? parameter)
        {
            _action();
        }
    }
}
