namespace MedicineCareBridge.Shared.DTO.User
{
    /// <summary>
    /// DTO для создания нового пользователя.
    /// </summary>
    public class UserCreateDto
    {
        /// <summary>
        /// Уникальный логин пользователя (email или телефон).
        /// </summary>
        public string Login { get; set; } = null!;

        /// <summary>
        /// Пароль пользователя в открытом виде.
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// Идентификатор роли пользователя.
        /// </summary>
        public int RoleId { get; set; }
    }
}
