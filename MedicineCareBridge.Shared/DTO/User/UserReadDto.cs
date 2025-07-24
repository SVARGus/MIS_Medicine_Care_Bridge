namespace MedicineCareBridge.Shared.DTO.User
{
    /// <summary>
    /// DTO для чтения данных пользователя.
    /// </summary>
    public class UserReadDto
    {
        /// <summary>
        /// Уникальный идентификатор пользователя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public string Login { get; set; } = null!;

        /// <summary>
        /// Список ролей, назначенных пользователю.
        /// </summary>
        public IEnumerable<string> Roles { get; set; } = Array.Empty<string>();
    }
}
