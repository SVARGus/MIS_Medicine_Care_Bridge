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
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginUserModel User { get; } = new();

        private string _errorMessage = "";
        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        private Visibility _errorVisibility = Visibility.Collapsed;
        public Visibility ErrorVisibility
        {
            get => _errorVisibility;
            set { _errorVisibility = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(_ => Login());
        }

        private void Login()
        {

            //заглушка
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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
