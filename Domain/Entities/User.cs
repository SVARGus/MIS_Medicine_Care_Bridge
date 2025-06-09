namespace Domain.Entities
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    public class User
    {
        public int Id { get; private set; }

        /// <summary>Логин (email или телефон)</summary>
        public string Login { get; private set; } = string.Empty;

        /// <summary>Пароль в виде строки (хэшируется) </summary>
        public string Password { get; private set; } = string.Empty;

        /// <summary>Связь с ролями через промежуточную таблицу UserRole</summary>
        public IReadOnlyCollection<UserRole> UserRoles => _userRoles;
        public readonly List<UserRole> _userRoles = new List<UserRole>();

        /// <summary>Личные данные (таблица Data)</summary>
        public PersonalData? PersonalData { get; private set; }

        /// <summary>Все документы пользователя (список UserDocument)</summary>
        public IReadOnlyCollection<UserDocumentType> UserDocuments => _userDocuments;
        private readonly List<UserDocumentType> _userDocuments = new();

        /// <summary>Паспортные данные (если есть)</summary>
        public Passport? Passport { get; private set; }

        /// <summary>СНИЛС (если есть)</summary>
        public Snils? Snils { get; private set; }

        /// <summary>Страховой документ (если есть)</summary>
        public InsuranceDocument? InsuranceDocument { get; private set; }
    }
}
