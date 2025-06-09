namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Таблица personal_data («Личные данные» пользователя)
    /// </summary>
    //[Table("personal_data")]
    //[PrimaryKey(nameof(UserId))]
    public class PersonalDataEntity
    {
        /// <summary>Внешний ключ на UserEntity.Id (PRIMARY KEY)</summary>
        //[Column("user_id"), ForeignKey("users")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; } = null!;

        /// <summary>Имя</summary>
        //[Column("first_name")]
        public string FirstName { get; set; } = null!;

        /// <summary>Фамилия</summary>
        //[Column("last_name")]
        public string LastName { get; set; } = null!;

        /// <summary>Отчество</summary>
        //[Column("meddle_name")]
        public string MiddleName { get; set; } = null!;

        /// <summary>Дата рождения</summary>
        //[Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>Телефон</summary>
        //[Column("phone")]
        public string Phone { get; set; } = null!;

        /// <summary>Email</summary>
        //[Column("email")]
        public string Email { get; set; } = null!;
    }
}
