namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Таблица permissions (права пользователей)
    /// </summary>
    //[Table("permissions")]
    //[PrimaryKey(nameof(Id))]
    public class PermissionEntity
    {
        /// <summary>Уникальный идентификатор</summary>
        //[Column("id")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        /// <summary>Текст описания права, например: "CanViewPatients"</summary>
        //[Column("text")]
        //[Required]
        public string Text { get; set; } = string.Empty;


        /// <summary>Логическое значение: доступно/не доступно</summary>
        //[Column("allowed")]
        public bool IsAllowed { get; set; }

        // Навигационные свойства:

        /// <summary>Связь m:n с RoleEntity через RolePermissionEntity</summary>
        public virtual ICollection<RolePermissionEntity> RolePermissions { get; set; } = new List<RolePermissionEntity>();
    }
}
