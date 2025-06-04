namespace Domain.Entities
{
    /// <summary>
    /// Промежуточная сущность «Роль–Право»
    /// </summary>
    public class RolePermission
    {
        /// <summary>Внешний ключ на Role.Id</summary>
        public int RoleId { get; private set; }
        public Role Role { get; private set; } = default!;

        /// <summary>Внешний ключ на Permission.Id</summary>
        public int PermissionId { get; private set; }
        public Permission Permission { get; private set; } = default!;
    }
}
