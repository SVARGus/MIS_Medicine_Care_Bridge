namespace MedicineCareBridge.Shared.DTO.Auth
{
    /// <summary>
    /// Модель запроса для аутентификации пользователя.
    /// </summary>
    public class LoginRequestDto
    {
        /// <summary>
        /// Email или телефон
        /// </summary>
        public string Login { get; set; } = null!;
        /// <summary>
        /// Пароль в открытом виде
        /// </summary>
        public string Password { get; set; } = null!;
    }
}
