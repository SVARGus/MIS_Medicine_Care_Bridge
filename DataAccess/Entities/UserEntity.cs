namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Таблица users (пользователи)
    /// </summary>
    //[Table("users")]
    //[PrimaryKey(nameof(Id))]
    public class UserEntity
    {
        /// <summary>Уникальный идентификатор</summary>
        //[Column("id")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>Логин (email или телефон)</summary>
        //[Column("login")]
        //[Required]
        public string Login { get; set; } = null!;

        /// <summary>Пароль (хранится хешированной строкой)</summary>
        //[Column("password")]
        //[Required]
        public string Password { get; set; } = null!;

        // Навигационные свойства:

        /// <summary>Связь m:n с ролями</summary>
        public virtual ICollection<UserRoleEntity> UserRoles { get; set; } = new List<UserRoleEntity>();

        /// <summary>«Личные данные» (1:1)</summary>
        public virtual PersonalDataEntity? PersonalData { get; set; }

        /// <summary>Связь m:n с типами документов</summary>
        public virtual ICollection<UserDocumentTypeEntity> UserDocumentTypes { get; set; } = new List<UserDocumentTypeEntity>();

        /// <summary>Паспортные данные (1:0..1)</summary>
        public virtual PassportEntity? Passport { get; set; }

        /// <summary>СНИЛС (1:0..1)</summary>
        public virtual SnilsEntity? Snils { get; set; }

        /// <summary>Страховой документ (1:0..1)</summary>
        public virtual InsuranceDocumentEntity? InsuranceDocument { get; set; }

        /// <summary>Универсальные документы (1:N)</summary>
        public virtual ICollection<UniversalDocumentEntity> UniversalDocuments { get; set; } = new List<UniversalDocumentEntity>();
    }
}
