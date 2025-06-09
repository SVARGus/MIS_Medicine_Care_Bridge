namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Промежуточная сущность «Роль–Право» (role_permission)
    /// </summary>
    //[Table("role_permission")]
    public class RolePermissionEntity
    {
        /// <summary>Внешний ключ на RoleEntity.Id</summary>
        //[Column("role_id"), ForeignKey("roles")]
        public int RoleId { get; set; }
        public virtual RoleEntity Role { get; set; } = null!;

        /// <summary>Внешний ключ на PermissionEntity.Id</summary>
        //[Column("permission_id"), ForeignKey("permissions")]
        public int PermissionId { get; set; }
        public virtual PermissionEntity Permission { get; set; } = null!;
    }
}
