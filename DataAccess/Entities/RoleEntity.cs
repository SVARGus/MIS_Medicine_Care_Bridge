namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Таблица roles (Роли пользователей)
    /// </summary>
    //[Table("roles")]
    //[PrimaryKey(nameof(Id))]
    public class RoleEntity
    {
        /// <summary>Уникальный идентификатор</summary>
        //[Column("id")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>Название роли на русском</summary>
        //[Column("name_rus")]
        //[Required]
        public string NameRus { get; set; } = null!;

        /// <summary>Название роли на английском</summary>
        //[Column("name_eng")]
        //[Required]
        public string NameEng {  get; set; } = null!;

        // Навигационные свойства:

        /// <summary>Связь m:n с PermissionEntity через RolePermissionEntity</summary>
        public virtual ICollection<RolePermissionEntity> RolePermissions { get; set; } = new List<RolePermissionEntity>();

        /// <summary>Связь m:n с UserEntity через UserRoleEntity</summary>
        public virtual ICollection<UserRoleEntity> UserRoles { get; set; } = new List<UserRoleEntity>();
    }
}
