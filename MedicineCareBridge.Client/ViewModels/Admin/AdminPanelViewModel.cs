using MedicineCareBridge.Client.Helpers.Auth;
using MedicineCareBridge.Shared.DTO.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicineCareBridge.Client.ViewModels.Admin
{
    public class AdminPanelViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<UserDto> Users { get; set; } = new();

        private UserDto _selectedUser;
        public UserDto SelectedUser
        {
            get => _selectedUser;
            set { _selectedUser = value; OnPropertyChanged(); }
        }

        public ICommand AddUserCommand { get; }
        public ICommand EditUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand ResetPasswordCommand { get; }

        public AdminPanelViewModel()
        {
            // В будущем заменить на загрузку из API
            Users.Add(new UserDto { Login = "admin", FullName = "Иван Иванов", Role = "Администратор", LastLogin = DateTime.Now });

            AddUserCommand = new RelayCommand(AddUser);
            EditUserCommand = new RelayCommand(EditUser, () => SelectedUser != null);
            DeleteUserCommand = new RelayCommand(DeleteUser, () => SelectedUser != null);
            ResetPasswordCommand = new RelayCommand(ResetPassword, () => SelectedUser != null);
        }

        private void AddUser() { /* логика */ }
        private void EditUser() { /* логика */ }
        private void DeleteUser() { /* логика */ }
        private void ResetPassword() { /* логика */ }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
