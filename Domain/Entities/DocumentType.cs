using Domain.Exceptions;

namespace Domain.Entities
{
    /// <summary>
    /// Тип документов (например, «ИНН», «Диплом», «СНИЛС» и т.п.)
    /// </summary>
    public class DocumentType
    {
        /// <summary>Идентификатор Документа (назначается БД).</summary>
        public int Id { get; private set; }

        /// <summary>Название типа документа (например: ИНН, Диплом, паспорт и другие)</summary>
        public string NameType { get; private set; } = string.Empty;

        /// <summary>Связь "многие-ко-многим" с пользователем через сущность <see cref="UserDocumentType"/></summary>
        public IReadOnlyCollection<UserDocumentType> UserDocuments => _userDocuments;
        public List<UserDocumentType> _userDocuments = new List<UserDocumentType>();

        /// <summary>Конструктор для EF‑фреймворка.</summary>
        private DocumentType() { }

        /// <summary>
        /// Инициализирует новый тип документов
        /// </summary>
        /// <param name="nameType">Название типа документов</param>
        /// <exception cref="DomainException">Если название типа пустое или состоит только из пробелов.</exception>
        public DocumentType(string nameType)
        {
            if (string.IsNullOrEmpty(nameType))
            {
                throw new DomainException("Название типа документа обязательно.");
            }
            NameType = nameType;
        }
    }
}
