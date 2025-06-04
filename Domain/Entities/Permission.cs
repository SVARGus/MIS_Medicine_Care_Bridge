namespace Domain.Entities
{
    /// <summary>
    /// Права пользователей (например: "Изменение данных пользователя", "изменение расписания" и другие)
    /// </summary>
    public class Permission
    {
        public int Id { get; private set; }

        /// <summary>Текс описания права. Например CanViewPatients</summary>
        public string Text { get; private set; } = string.Empty;

        /// <summary>Логическое значение: доступно \ недоступно</summary>
        public bool IsAllowed { get; private set; }

        /// <summary>Связь с ролями через RolePermission</summary>
        public IReadOnlyCollection<RolePermission> RolePermissions => _rolePermissions;
        public List<RolePermission> _rolePermissions = new List<RolePermission>();
    }
}
