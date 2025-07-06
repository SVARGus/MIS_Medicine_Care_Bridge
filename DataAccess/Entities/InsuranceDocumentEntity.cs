namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Таблица InsuranceDocument (Страховой документ)
    /// </summary>
    public class InsuranceDocumentEntity
    {
        /// <summary>Название документа, соответствующее типу документа</summary>
        public string DocumentName { get; set; } = string.Empty;

        /// <summary>Номер страхового полиса (PRIMARY KEY или составной с UserId)</summary>
        public string Num { get; set; } = string.Empty;

        /// <summary>Внешний ключ на UserEntity.Id</summary>
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; } = null!;

        /// <summary>Внешний ключ на DocumentTypeEntity.Id (обычно «Полис»)</summary>
        public int DocumentTypeId { get; set; }
        public virtual DocumentTypeEntity DocumentType { get; set; } = null!;
    }
}
