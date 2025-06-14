using MedicineCareBridge.Client.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using MedicineCareBridge.Client.Helpers.Auth;

namespace MedicineCareBridge.Client.ViewModels.Auth
{
    /// <summary>
    /// ViewModel для окна авторизации.
    /// Содержит логику ввода логина и пароля, а также проверку авторизации.
    /// </summary>
    public class LoginViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Модель данных пользователя, содержащая логин и пароль.
        /// </summary>
        public LoginUserModel User { get; } = new();

        private string _errorMessage = "";

        /// <summary>
        /// Сообщение об ошибке, отображаемое при неудачной авторизации.
        /// </summary>
        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        private Visibility _errorVisibility = Visibility.Collapsed;

        /// <summary>
        /// Видимость блока ошибки. По умолчанию скрыт.
        /// </summary>
        public Visibility ErrorVisibility
        {
            get => _errorVisibility;
            set { _errorVisibility = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Команда, вызывающая попытку входа в систему.
        /// </summary>
        public ICommand LoginCommand { get; }

        /// <summary>
        /// Конструктор. Инициализирует команду входа.
        /// </summary>
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(_ => Login());
        }

        /// <summary>
        /// Метод, выполняющий проверку введённых логина и пароля.
        /// Заглушка: разрешён вход только при логине "admin" и пароле "1234".
        /// </summary>
        private void Login()
        {
            // Заглушка: проверка логина и пароля
            if (User.Login == "admin" && User.Password == "1234")
            {
                ErrorVisibility = Visibility.Collapsed;
                MessageBox.Show("Успешный вход!", "Авторизация");
            }
            else
            {
                ErrorMessage = "Ошибка входа: неверный логин или пароль";
                ErrorVisibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Событие, уведомляющее об изменении свойства.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Метод уведомления об изменении значения свойства.
        /// </summary>
        /// <param name="name">Имя изменённого свойства.</param>
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}