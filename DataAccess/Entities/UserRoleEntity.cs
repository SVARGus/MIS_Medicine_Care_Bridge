namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Промежуточная сущность «Пользователь–Роль» (user_role)
    /// </summary>
    public class UserRoleEntity
    {
        /// <summary>Внешний ключ на UserEntity.Id</summary>
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; } = null!;

        /// <summary>Внешний ключ на RoleEntity.Id</summary>
        public int RoleId { get; set; }
        public virtual RoleEntity Role { get; set; } = null!;
    }
}
