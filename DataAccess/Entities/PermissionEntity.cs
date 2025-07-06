namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Таблица permissions (права пользователей)
    /// </summary>
    public class PermissionEntity
    {
        /// <summary>Уникальный идентификатор</summary>
        public int Id { get; set; }


        /// <summary>Текст описания права, например: "CanViewPatients"</summary>
        public string Text { get; set; } = string.Empty;


        /// <summary>Логическое значение: доступно/не доступно</summary>
        public bool IsAllowed { get; set; }

        // Навигационные свойства:

        /// <summary>Связь m:n с RoleEntity через RolePermissionEntity</summary>
        public virtual ICollection<RolePermissionEntity> RolePermissions { get; set; } = new List<RolePermissionEntity>();
    }
}
