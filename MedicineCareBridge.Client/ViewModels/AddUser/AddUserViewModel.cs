using MedicineCareBridge.Client.Helpers.Auth;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicineCareBridge.Client.ViewModels.AddUser
{
    public class AddUserViewModel : INotifyPropertyChanged
    {
        private string _lastName = "";
        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(); }
        }

        private string _firstName = "";
        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChanged(); }
        }

        private string _middleName = "";
        public string MiddleName
        {
            get => _middleName;
            set { _middleName = value; OnPropertyChanged(); }
        }

        private string _login = "";
        public string Login
        {
            get => _login;
            set { _login = value; OnPropertyChanged(); }
        }

        private string _password = "";
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> Roles { get; } = new ObservableCollection<string>
        {
            "Администратор",
            "Врач",
            "Регистратор",
            "Аналитик"
        };

        private string _selectedRole = "Врач";
        public string SelectedRole
        {
            get => _selectedRole;
            set { _selectedRole = value; OnPropertyChanged(); }
        }

        private bool _canRead;
        public bool CanRead
        {
            get => _canRead;
            set { _canRead = value; OnPropertyChanged(); }
        }

        private bool _canWrite;
        public bool CanWrite
        {
            get => _canWrite;
            set { _canWrite = value; OnPropertyChanged(); }
        }

        private bool _canDelete;
        public bool CanDelete
        {
            get => _canDelete;
            set { _canDelete = value; OnPropertyChanged(); }
        }

        public ICommand FillDocumentsCommand { get; }

        public AddUserViewModel()
        {
            FillDocumentsCommand = new RelayCommand(FillDocuments);
        }

        private void FillDocuments()
        {
            // Здесь можно открыть диалог или реализовать логику заполнения документов
            System.Windows.MessageBox.Show("Функция заполнения документов пока не реализована.");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
