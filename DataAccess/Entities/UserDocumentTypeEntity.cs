namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Промежуточная сущность «Пользователь–Тип документа»
    /// </summary>
    //[Table("user_document_types")]
    public class UserDocumentTypeEntity
    {
        /// <summary>Внешний ключ на UserEntity.Id</summary>
        //[Column("user_id"), ForeignKey("users")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; } = null!;

        /// <summary>Внешний ключ на DocumentTypeEntity.Id</summary>
        //[Column("document_type_id"), ForeignKey("document_type")]
        public int DocumentTypeId { get; set; }
        public virtual DocumentTypeEntity DocumentType { get; set; } = null!;
    }
}
