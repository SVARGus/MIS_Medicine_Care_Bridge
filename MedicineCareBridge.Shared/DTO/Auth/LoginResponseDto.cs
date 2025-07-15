namespace MedicineCareBridge.Shared.DTO.Auth
{
    /// <summary>
    /// Модель ответа при успешной аутентификации.
    /// </summary>
    public class LoginResponseDto
    {
        /// <summary>
        /// JWT-токен для доступа к защищенным ресурсам.
        /// </summary>
        public string Token { get; set; } = null!;
        /// <summary>
        /// Дата и время (UTC), когда токен перестанет быть действительным.
        /// </summary>
        public DateTime ExpiresAt { get; set; }
    }
}
