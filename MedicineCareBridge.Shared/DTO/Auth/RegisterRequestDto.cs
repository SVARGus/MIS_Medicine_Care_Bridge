namespace MedicineCareBridge.Shared.DTO.Auth
{
    /// <summary>
    /// Модель запроса для регистрации нового пользователя.
    /// </summary>
    public class RegisterRequestDto
    {
        /// <summary>
        /// Email или номер телефона пользователя для логина.
        /// </summary>
        
        public string Login { get; set; } = null!;

        /// <summary>
        /// Пароль пользователя в открытом виде.
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Отчество пользователя.
        /// </summary>
        public string MiddleName { get; set; } = null!;

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Контактный телефон пользователя.
        /// </summary>
        public string Phone { get; set; } = null!;

        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        public string Email { get; set; } = null!;
    }
}
