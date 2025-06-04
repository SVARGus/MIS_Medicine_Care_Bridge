namespace Domain.Entities
{
    /// <summary>
    /// Тип документов (например, «ИНН», «Диплом», «СНИЛС» и т.п.)
    /// </summary>
    public class DocumentType
    {
        public int Id { get; private set; }

        /// <summary>Название типа документа (например: ИНН, Диплом, паспорт и другие)</summary>
        public string NameType { get; private set; } = string.Empty;

        /// <summary>Связь с пользователем через UserDocumentType</summary>
        public IReadOnlyCollection<UserDocumentType> UserDocuments => _userDocuments;
        public List<UserDocumentType> _userDocuments = new List<UserDocumentType>();
    }
}
