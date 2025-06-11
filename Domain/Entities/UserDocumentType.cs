namespace Domain.Entities
{
    /// <summary>
    /// Промежуточная сущность «Пользователь–Документ» (UserId, DocumentTypeId)
    /// </summary>
    public class UserDocumentType
    {
        /// <summary>Внешний ключ на <see cref="User.Id"/></summary>
        public int UserId { get; private set; }
        /// <summary>Навигационное свойство на <see cref="User"/></summary>
        public User User { get; private set; } = default!;

        /// <summary>Внешний ключ на <see cref="DocumentType.Id"/></summary>
        public int DocumentTypeId { get; private set; }
        /// <summary>Навигационное свойство на <see cref="DocumentType"/></summary>
        public DocumentType DocumentType { get; private set; } = default!;

        /// <summary>Конструктор для EF‑фреймворка.</summary>
        private UserDocumentType() { }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="UserDocumentType"/>
        /// для связи Пользователь и документ.
        /// </summary>
        /// <param name="userId">Индификатор пользователя.</param>
        /// <param name="docTypeId">Индификатор документа.</param>
        public UserDocumentType(int userId, int docTypeId)
        {
            UserId = userId;
            DocumentTypeId = docTypeId;
        }
    }
}
