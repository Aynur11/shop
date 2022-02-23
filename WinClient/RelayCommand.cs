using System;
using System.Windows.Input;

namespace WinClient
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool>? _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;

        }

        public RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Проверяет возможность выполнения.
        /// </summary>
        /// <param name="parameter">Делегат.</param>
        /// <returns>Результат проверки.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Запустить выполнение.
        /// </summary>
        /// <param name="parameter">Делегат.</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

    }
}
