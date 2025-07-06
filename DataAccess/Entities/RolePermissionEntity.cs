namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Промежуточная сущность «Роль–Право» (role_permission)
    /// </summary>
    public class RolePermissionEntity
    {
        /// <summary>Внешний ключ на RoleEntity.Id</summary>
        public int RoleId { get; set; }
        public virtual RoleEntity Role { get; set; } = null!;

        /// <summary>Внешний ключ на PermissionEntity.Id</summary>
        public int PermissionId { get; set; }
        public virtual PermissionEntity Permission { get; set; } = null!;
    }
}
