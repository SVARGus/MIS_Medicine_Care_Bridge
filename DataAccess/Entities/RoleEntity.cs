namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Таблица roles (Роли пользователей)
    /// </summary>
    public class RoleEntity
    {
        /// <summary>Уникальный идентификатор</summary>
        public int Id { get; set; }

        /// <summary>Название роли на русском</summary>
        public string NameRus { get; set; } = null!;

        /// <summary>Название роли на английском</summary>
        public string NameEng {  get; set; } = null!;

        // Навигационные свойства:

        /// <summary>Связь m:n с PermissionEntity через RolePermissionEntity</summary>
        public virtual ICollection<RolePermissionEntity> RolePermissions { get; set; } = new List<RolePermissionEntity>();

        /// <summary>Связь m:n с UserEntity через UserRoleEntity</summary>
        public virtual ICollection<UserRoleEntity> UserRoles { get; set; } = new List<UserRoleEntity>();
    }
}
