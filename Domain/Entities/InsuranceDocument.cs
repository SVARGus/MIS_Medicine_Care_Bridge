namespace Domain.Entities
{
    /// <summary>
    /// Страховой документ
    /// </summary>
    public class InsuranceDocument
    {
        /// <summary>Название документа, соответствет типу документа (на русском)</summary>
        public string DocumentName { get; private set; } = string.Empty;

        /// <summary>Номер или уникальный идентификатор документа</summary>
        public string Num { get; private set; } = string.Empty;

        /// <summary>Связь на User.Id</summary>
        public int UserId { get; private set; }
        public User User { get; private set; } = default!;

        /// <summary>Тип документа (обычно «Полис ОМС» или аналог)</summary>
        public int DocumentTypeId { get; private set; }
        public DocumentType DocumentType { get; private set; } = default!;
    }

}
