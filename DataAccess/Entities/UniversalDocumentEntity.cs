namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Таблица UniversalDocument (Универсальный документ пользователя)
    /// </summary>
    //[Table("universal_document")]
    //[PrimaryKey(nameof(Id))]
    public class UniversalDocumentEntity
    {
        //[Column("id")]
        public int Id { get; set; }

        /// <summary>Номер или уникальный идентификатор документа</summary>
        //[Column("num")]
        public string Num { get; set; } = null!;

        /// <summary>Название документа (например, «Сертификат»)</summary>
        //[Column("document_name")]
        public string DocumentName { get; set; } = null!;

        /// <summary>Описание документа (при необходимости)</summary>
        //[Column("description")]
        public string Description { get; set; } = null!;

        /// <summary>Дата выдачи документа</summary>
        //[Column("date_of_issue")]
        public DateTime DateOfIssue { get; set; }

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
