namespace MedicineCareBridge.Shared.DTO.User
{
    /// <summary>
    /// DTO для обновления данных пользователя.
    /// </summary>
    public class UserUpdateDto
    {
        /// <summary>
        /// Уникальный идентификатор пользователя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Новый пароль пользователя (если требуется смена).
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Список идентификаторов новых ролей пользователя. Полностью заменяет текущие роли.
        /// </summary>
        public List<int>? RoleIds { get; set; }
    }
}
