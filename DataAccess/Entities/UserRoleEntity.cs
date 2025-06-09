namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Промежуточная сущность «Пользователь–Роль» (user_role)
    /// </summary>
    //[Table("user_roles")]
    public class UserRoleEntity
    {
        /// <summary>Внешний ключ на UserEntity.Id</summary>
        //[Column("user_id"), ForeignKey("users")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; } = null!;

        /// <summary>Внешний ключ на RoleEntity.Id</summary>
        //[Column("role_id"), ForeignKey("roles")]
        public int RoleId { get; set; }
        public virtual RoleEntity Role { get; set; } = null!;
    }
}
