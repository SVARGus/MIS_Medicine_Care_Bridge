namespace Domain.Entities
{
    /// <summary>
    /// Промежуточная сущность Пользователь - Роль
    /// </summary>
    public class UserRole
    {
        /// <summary>Внешний ключ на <see cref="User.Id"/></summary>
        public int UserId { get; private set; }
        /// <summary>Навигационное свойство на <see cref="User"/></summary>
        public User User { get; private set; } = default!;

        /// <summary>Внешний ключ на <see cref="Role.Id"/></summary>
        public int RoleId { get; private set; }
        /// <summary>Навигационное свойство на <see cref="Role"/></summary>
        public Role Role { get; private set; } = default!;

        /// <summary>Конструктор для EF‑фреймворка.</summary>
        private UserRole() { }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="UserRole"/>
        /// для связи Пользователь и роль.
        /// </summary>
        /// <param name="userId">Индификатор пользователя.</param>
        /// <param name="roleId">Идентификатор роли.</param>
        public UserRole(int userId, int roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
