namespace Domain.Entities
{
    /// <summary>
    /// Роль пользователя (например Admin, Visitor, Patient)
    /// </summary>
    public class Role
    {
        public int Id { get; private set; }

        /// <summary>Название роли на Русском </summary>
        public string NameRus { get; private set; } = string.Empty;

        /// <summary>Название роли на Английском </summary>
        public string NameEng { get; private set; } = string.Empty;

        /// <summary>Связь с пользователями через UserRole</summary>
        public IReadOnlyCollection<UserRole> UserRoles => _userRoles;
        public readonly List<UserRole> _userRoles = new List<UserRole>();
    }
}
