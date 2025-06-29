namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Таблица InsuranceDocument (Страховой документ)
    /// </summary>
    //[Table("insurance_documents")]
    //[PrimaryKey(nameof(Num))]
    public class InsuranceDocumentEntity
    {
        /// <summary>Название документа, соответствующее типу документа</summary>
        //[Column("document_name")]
        public string DocumentName { get; set; } = string.Empty;

        /// <summary>Номер страхового полиса (PRIMARY KEY или составной с UserId)</summary>
        //[Column("num")]
        public string Num { get; set; } = string.Empty;

        /// <summary>Внешний ключ на UserEntity.Id</summary>
        //[Column("user_id"), ForeignKey("users")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; } = null!;

        /// <summary>Внешний ключ на DocumentTypeEntity.Id (обычно «Полис»)</summary>
        //[Column("document_type_id"), ForeignKey("document_type")]
        public int DocumentTypeId { get; set; }
        public virtual DocumentTypeEntity DocumentType { get; set; } = null!;
    }
}
