using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicineCareBridge.Client.Helpers.Auth
{
    /// <summary>
    /// Универсальная реализация интерфейса <see cref="ICommand"/> для привязки действий в MVVM.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Predicate<object?>? _canExecute;

        /// <summary>
        /// Создает команду с параметром.
        /// </summary>
        /// <param name="execute">Делегат, выполняющий действие.</param>
        /// <param name="canExecute">Делегат, определяющий, доступна ли команда. По умолчанию — всегда доступна.</param>
        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Создает команду без параметров.
        /// </summary>
        /// <param name="execute">Делегат, выполняющий действие.</param>
        /// <param name="canExecute">Функция, определяющая доступность команды. По умолчанию — всегда доступна.</param>
        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = _ => execute();
            if (canExecute != null)
                _canExecute = _ => canExecute();
        }

        /// <summary>
        /// Событие, вызываемое при изменении условий выполнения команды.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Определяет, может ли команда быть выполнена.
        /// </summary>
        /// <param name="parameter">Параметр команды.</param>
        /// <returns>True, если выполнение разрешено, иначе false.</returns>
        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

        /// <summary>
        /// Выполняет команду.
        /// </summary>
        /// <param name="parameter">Параметр команды.</param>
        public void Execute(object? parameter) => _execute(parameter);
    }
}
