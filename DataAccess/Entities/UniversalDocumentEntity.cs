namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Таблица UniversalDocument (Универсальный документ пользователя)
    /// </summary>
    public class UniversalDocumentEntity
    {
        public int Id { get; set; }

        /// <summary>Номер или уникальный идентификатор документа</summary>
        public string Num { get; set; } = null!;

        /// <summary>Название документа (например, «Сертификат»)</summary>
        public string DocumentName { get; set; } = null!;

        /// <summary>Описание документа (при необходимости)</summary>
        public string Description { get; set; } = null!;

        /// <summary>Дата выдачи документа</summary>
        public DateTime DateOfIssue { get; set; }

        /// <summary>Внешний ключ на UserEntity.Id</summary>
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; } = null!;

        /// <summary>Внешний ключ на DocumentTypeEntity.Id</summary>
        public int DocumentTypeId { get; set; }
        public virtual DocumentTypeEntity DocumentType { get; set; } = null!;
    }
}
