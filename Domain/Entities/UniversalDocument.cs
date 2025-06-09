namespace Domain.Entities
{
    /// <summary>
    /// Универсальный документ (таблица UniversalDocument)
    /// </summary>
    public class UniversalDocument
    {
        /// <summary>Название документа (например, "Сертификат", "Справка" и т.д.), пока не присвоен отдельный тип документа</summary>
        public string DocumentName { get; private set; } = string.Empty;

        public int Id { get; private set; }

        /// <summary>Номер или уникальный идентификатор документа</summary>
        public string Num { get; private set; } = string.Empty;

        /// <summary>Описание документа (при необходимости)</summary>
        public string Description { get; private set; } = string.Empty;

        /// <summary>Дата выдачи документа</summary>
        public DateTime DateOfIssue { get; private set; }

        /// <summary>ID пользователя (внешний ключ на User.Id)</summary>
        public int UserId { get; private set; }
        public User User { get; private set; } = default!;

        /// <summary>ID типа документа (универсально привязан к записи в DocumentType)</summary>
        public int DocumentTypeId { get; private set; }
        public DocumentType DocumentType { get; private set; } = default!;
    }
}
