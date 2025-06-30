namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Таблица personal_data («Личные данные» пользователя)
    /// </summary>
    public class PersonalDataEntity
    {
        /// <summary>Внешний ключ на UserEntity.Id (PRIMARY KEY)</summary>
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; } = null!;

        /// <summary>Имя</summary>
        public string FirstName { get; set; } = null!;

        /// <summary>Фамилия</summary>
        public string LastName { get; set; } = null!;

        /// <summary>Отчество</summary>
        public string MiddleName { get; set; } = null!;

        /// <summary>Дата рождения</summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>Телефон</summary>
        public string Phone { get; set; } = null!;

        /// <summary>Email</summary>
        public string Email { get; set; } = null!;
    }
}
