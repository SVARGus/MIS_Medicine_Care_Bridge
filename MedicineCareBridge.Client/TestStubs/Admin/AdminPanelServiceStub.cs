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
        private static readonly string[] Roles = { "Администратор", "Врач", "Регистратор", "Аналитик" };
        private static readonly Random _random = new();

        public AdminPanelServiceStub()
        {
            _users = new ObservableCollection<UserDto>
        {
            new UserDto { Login = "ivanov", FullName = "Иванов Иван Иванович", Role = "Админ", LastLogin = DateTime.Now.AddDays(-1) },
            new UserDto { Login = "petrova", FullName = "Петрова Мария Сергеевна", Role = "Врач", LastLogin = DateTime.Now.AddDays(-3) },
            new UserDto { Login = "smirnov", FullName = "Смирнов Алексей Юрьевич", Role = "Регистратор", LastLogin = DateTime.Now.AddDays(-10) }
        };
        }

        public static List<UserDto> GenerateRandomUsers(int count)
        {
            var users = new List<UserDto>();

            for (int i = 0; i < count; i++)
            {
                users.Add(new UserDto
                {
                    Login = $"user{i + 1}",
                    FullName = $"{RandomName()} {RandomSurname()}",
                    Role = Roles[_random.Next(Roles.Length)],
                    LastLogin = DateTime.Now.AddDays(-_random.Next(30))
                });
            }

            return users;
        }

        private static string RandomName()
        {
            string[] names = { "Иван", "Анна", "Петр", "Мария", "Алексей", "Ольга" };
            return names[_random.Next(names.Length)];
        }

        private static string RandomSurname()
        {
            string[] surnames = { "Иванов", "Петрова", "Сидоров", "Кузнецова", "Смирнов", "Коваленко" };
            return surnames[_random.Next(surnames.Length)];
        }

        public ObservableCollection<UserDto> GetAllUsers() => _users;

        
        public void GenerateAndLoadUsers(int count)
        {
            var randomUsers = GenerateRandomUsers(count);
            _users.Clear();
            foreach (var user in randomUsers)
                _users.Add(user);
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
            Console.WriteLine($"Сброс пароля для: {login}");
        }
    }
}
