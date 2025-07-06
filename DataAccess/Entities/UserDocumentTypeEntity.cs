namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Промежуточная сущность «Пользователь–Тип документа»
    /// </summary>
    public class UserDocumentTypeEntity
    {
        /// <summary>Внешний ключ на UserEntity.Id</summary>
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; } = null!;

        /// <summary>Внешний ключ на DocumentTypeEntity.Id</summary>
        public int DocumentTypeId { get; set; }
        public virtual DocumentTypeEntity DocumentType { get; set; } = null!;
    }
}
