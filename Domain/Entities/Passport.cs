namespace Domain.Entities
{
    /// <summary>
    /// Паспортные данные
    /// </summary>
    public class Passport
    {
        /// <summary>Название документа, соответствет типу документа (на русском)</summary>
        public string DocumentName { get; private set; } = string.Empty;

        /// <summary>Номер или уникальный идентификатор документа</summary>
        public string PassportNum { get; private set; } = string.Empty;

        /// <summary>Связь на User.Id</summary>
        public int UserId { get; private set; }
        public User User { get; private set; } = default!;

        /// <summary>Дополнительная информация о паспорте (например, где выдан)</summary>
        public string Info { get; private set; } = string.Empty;

        /// <summary>Дата выдачи документа</summary>
        public DateTime DateOfIssue { get; private set; }

        /// <summary>Тип документа (обычно это тот же тип «Паспорт» из DocumentType)</summary>
        public int DocumentTypeId { get; private set; }
        public DocumentType DocumentType { get; private set; } = default!;
    }
}
