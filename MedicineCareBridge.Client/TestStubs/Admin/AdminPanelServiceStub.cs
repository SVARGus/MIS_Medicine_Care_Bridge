using MedicineCareBridge.Shared.DTO.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineCareBridge.Client.TestStubs.Admin
{
    public class AdminPanelServiceStub
    {
        private readonly ObservableCollection<UserDto> _users;

        public AdminPanelServiceStub()
        {
            _users = new ObservableCollection<UserDto>
            {
                new UserDto { Login = "ivanov", FullName = "Иванов Иван Иванович", Role = "Админ", LastLogin = DateTime.Now.AddDays(-1) },
                new UserDto { Login = "petrova", FullName = "Петрова Мария Сергеевна", Role = "Врач", LastLogin = DateTime.Now.AddDays(-3) },
                new UserDto { Login = "smirnov", FullName = "Смирнов Алексей Юрьевич", Role = "Регистратор", LastLogin = DateTime.Now.AddDays(-10) }
            };
        }

        public ObservableCollection<UserDto> GetAllUsers()
        {
            return _users;
        }

        public void AddUser(UserDto user)
        {
            user.LastLogin = DateTime.Now;
            _users.Add(user);
        }

        public void UpdateUser(UserDto updatedUser)
        {
            var existing = _users.FirstOrDefault(u => u.Login == updatedUser.Login);
            if (existing != null)
            {
                existing.FullName = updatedUser.FullName;
                existing.Role = updatedUser.Role;
                existing.LastLogin = updatedUser.LastLogin;
            }
        }

        public void DeleteUser(string login)
        {
            var user = _users.FirstOrDefault(u => u.Login == login);
            if (user != null)
                _users.Remove(user);
        }

        public void ResetPassword(string login)
        {
            // Просто заглушка. Можно добавить лог или MessageBox.
            Console.WriteLine($"Сброс пароля для: {login}");
        }
    }
}
