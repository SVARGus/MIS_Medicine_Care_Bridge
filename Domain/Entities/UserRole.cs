namespace Domain.Entities
{
    /// <summary>
    /// Промежуточная сущность Пользователь - Роль
    /// </summary>
    public class UserRole
    {
        /// <summary>Внешний ключ на User.Id</summary>
        public int UserId { get; private set; }
        public User User { get; private set; } = default!;

        /// <summary>Внешний ключ на Role.Id</summary>
        public int RoleId { get; private set; }
        public Role Role { get; private set; } = default!;

    }
}
