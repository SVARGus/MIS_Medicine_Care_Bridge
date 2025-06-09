namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Таблица InsuranceDocument (Страховой документ)
    /// </summary>
    //[Table("insurance_documents")]
    //[PrimaryKey(nameof(Num))]
    public class InsuranceDocumentEntity
    {
        /// <summary>Номер страхового полиса (PRIMARY KEY или составной с UserId)</summary>
        //[Column("num")]
        public int Num { get; set; }

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
