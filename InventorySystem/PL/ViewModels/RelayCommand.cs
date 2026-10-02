using System;
using System.Windows.Input;

namespace InventorySystem.PL.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        public RelayCommand(
            Action Execute,
            Func<bool>? canExcute = null)
        {
            _execute = Execute;
            _canExecute = canExcute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object? parameter)
        {
            _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this,
                EventArgs.Empty);
        }
    }
}
