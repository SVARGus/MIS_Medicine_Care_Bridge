using MedicineCareBridge.Client.Helpers.Auth;
using MedicineCareBridge.Client.TestStubs.Admin;
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
    /// <summary>
    /// ViewModel для панели администратора.
    /// Управляет списком пользователей и действиями над ними.
    /// </summary>
    public class AdminPanelViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Заглушка сервиса для управления пользователями (используется вместо реального бэкенда).
        /// </summary>
        private readonly AdminPanelServiceStub _adminService = new();

        /// <summary>
        /// Коллекция пользователей, отображаемая в UI.
        /// </summary>
        public ObservableCollection<UserDto> Users { get; set; } = new();

        private UserDto _selectedUser;

        /// <summary>
        /// Выбранный в UI пользователь.
        /// </summary>
        public UserDto SelectedUser
        {
            get => _selectedUser;
            set { _selectedUser = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Команда добавления нового пользователя.
        /// </summary>
        public ICommand AddUserCommand { get; }

        /// <summary>
        /// Команда редактирования выбранного пользователя.
        /// </summary>
        public ICommand EditUserCommand { get; }

        /// <summary>
        /// Команда удаления выбранного пользователя.
        /// </summary>
        public ICommand DeleteUserCommand { get; }

        /// <summary>
        /// Команда сброса пароля выбранного пользователя.
        /// </summary>
        public ICommand ResetPasswordCommand { get; }

        /// <summary>
        /// Конструктор ViewModel. Инициализирует команды и генерирует тестовых пользователей.
        /// </summary>
        public AdminPanelViewModel()
        {
            // Генерация 1000 пользователей при инициализации (для демонстрации)
            GenerateUsers(1000);

            AddUserCommand = new RelayCommand(AddUser);
            EditUserCommand = new RelayCommand(EditUser, () => SelectedUser != null);
            DeleteUserCommand = new RelayCommand(DeleteUser, () => SelectedUser != null);
            ResetPasswordCommand = new RelayCommand(ResetPassword, () => SelectedUser != null);
        }

        /// <summary>
        /// Генерирует указанное количество случайных пользователей и загружает их.
        /// </summary>
        /// <param name="count">Количество пользователей для генерации.</param>
        private void GenerateUsers(int count)
        {
            _adminService.GenerateAndLoadUsers(count);
            LoadUsers();
        }

        /// <summary>
        /// Загружает всех пользователей из сервиса и обновляет коллекцию Users.
        /// </summary>
        private void LoadUsers()
        {
            Users.Clear();
            foreach (var user in _adminService.GetAllUsers())
                Users.Add(user);
        }

        /// <summary>
        /// Добавляет нового пользователя (тестовый).
        /// </summary>
        private void AddUser()
        {
            var newUser = new UserDto
            {
                Login = "newuser",
                FullName = "Новый Пользователь",
                Role = "Врач",
                LastLogin = DateTime.Now
            };
            _adminService.AddUser(newUser);
            LoadUsers();
        }

        /// <summary>
        /// Заглушка логики редактирования пользователя.
        /// </summary>
        private void EditUser() { /* логика */ }

        /// <summary>
        /// Заглушка логики удаления пользователя.
        /// </summary>
        private void DeleteUser() { /* логика */ }

        /// <summary>
        /// Заглушка логики сброса пароля пользователя.
        /// </summary>
        private void ResetPassword() { /* логика */ }

        /// <summary>
        /// Событие для уведомления об изменении свойств ViewModel.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод уведомления об изменении свойства.
        /// </summary>
        /// <param name="name">Имя свойства.</param>
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
