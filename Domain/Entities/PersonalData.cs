namespace Domain.Entities
{
    /// <summary>
    /// «Личные данные» пользователя (таблица Data)
    /// </summary>
    public class PersonalData
    {
        /// <summary>Внешний ключ на User.Id</summary>
        public int UserId { get; private set; }
        public User User { get; private set; } = default!;

        /// <summary>Имя</summary>
        public string FirstName { get; private set; } = string.Empty;

        /// <summary>Фамилия</summary>
        public string LastName { get; private set; } = string.Empty;

        /// <summary>Отчество</summary>
        public string MiddleName { get; private set; } = string.Empty;

        /// <summary>Дата рождения</summary>
        public DateTime DateOfBirth { get; private set; }

        /// <summary>Телефон</summary>
        public string Phone { get; private set; } = string.Empty; 
         
        /// <summary>Email</summary>
        public string Email { get; private set; } = string.Empty;
    }
}
