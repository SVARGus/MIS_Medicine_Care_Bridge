namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Справочник типов документов (document_type)
    /// </summary>
    //[Table("document_type")]
    //[PrimaryKey(nameof(Id))]
    public class DocumentTypeEntity
    {
        /// <summary>Уникальный идентификатор</summary>
        public int Id { get; set; }

        /// <summary>Название типа документа (например: "ИНН", "Диплом", "Паспорт" и т. д.)</summary>
        public string NameType { get; set; } = string.Empty;

        /// <summary>Связь m:n с пользователями через UserDocumentTypeEntity</summary>
        public virtual ICollection<UserDocumentTypeEntity> UserDocumentTypes { get; set; } = new List<UserDocumentTypeEntity>();
    }
}

