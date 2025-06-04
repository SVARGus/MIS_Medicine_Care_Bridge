namespace Domain.Entities
{
    /// <summary>
    /// Промежуточная сущность «Пользователь–Документ» (UserId, DocumentTypeId)
    /// </summary>
    public class UserDocumentType
    {
        /// <summary>Внешний ключ на User.Id</summary>
        public int UserId { get; private set; }
        public User User { get; private set; } = default!;

        /// <summary>Внешний ключ на DocumentType.Id</summary>
        public int DocumentTypeId { get; private set; }
        public DocumentType DocumentType { get; private set; } = default!;
    }
}
