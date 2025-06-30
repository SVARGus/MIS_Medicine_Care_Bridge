using Domain.Exceptions;

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

        /// <summary>Внешний ключ на <see cref="User.Id"/></summary>
        public int UserId { get; private set; }
        /// <summary>Навигационное свойство на <see cref="User"/></summary>
        public User User { get; private set; } = default!;

        /// <summary>Внешний ключ на <see cref="DocumentType.Id"/></summary>
        public int DocumentTypeId { get; private set; }
        /// <summary>Навигационное свойство на <see cref="DocumentType"/></summary>
        public DocumentType DocumentType { get; private set; } = default!;

        /// <summary>Конструктор для EF‑фреймворка.</summary>
        private InsuranceDocument() { }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="InsuranceDocument"/>.
        /// </summary>
        /// <param name="documentName">Название документа (не может быть пустым).</param>
        /// <param name="num">Номер документа (не может быть пустым).</param>
        /// <param name="userId">Идентификатор пользователя (должен быть положительным).</param>
        /// <param name="documentTypeId">Идентификатор типа документа (должен быть положительным).</param>
        /// <exception cref="DomainException">
        /// Если параметры некорректны:
        /// <list type="bullet">
        ///   <item><description><paramref name="documentName"/> пуст или состоит из пробелов.</description></item>
        ///   <item><description><paramref name="num"/> &lt;= 0.</description></item>
        ///   <item><description><paramref name="userId"/> или <paramref name="documentTypeId"/> &lt;= 0.</description></item>
        /// </list>
        /// </exception>
        public InsuranceDocument(string documentName, string num, int userId, int documentTypeId)
        {
            if (string.IsNullOrWhiteSpace(documentName))
            {
                throw new DomainException("DocumentName не может быть пустым.");
            }
            if (string.IsNullOrWhiteSpace(num))
            {
                throw new DomainException("Num не может быть пустым.");
            }
            if (userId <= 0)
            {
                throw new DomainException("UserId должен быть положительным числом.");
            }
            if (documentTypeId <= 0)
            {
                throw new DomainException("DocumentTypeId должен быть положительным числом.");
            }

            DocumentName = documentName;
            Num = num;
            UserId = userId;
            DocumentTypeId = documentTypeId;
        }

        /// <summary>
        /// Обновляет номер документа.
        /// </summary>
        /// <param name="num">Новый номер (должен быть положительным).</param>
        public void UpdateNum(string num)
        {
            if (string.IsNullOrWhiteSpace(num))
            {
                throw new DomainException("Num не может быть пустым.");
            }

            Num = num;
        }

        /// <summary>
        /// Обновляет название документа.
        /// </summary>
        /// <param name="documentName">Новое название (не может быть пустым).</param>
        public void UpdateDocumentName(string documentName)
        {
            if (string.IsNullOrWhiteSpace(documentName))
            {
                throw new DomainException("DocumentName не может быть пустым.");
            }

            DocumentName = documentName;
        }

        /// <summary>
        /// Изменяет тип документа.
        /// </summary>
        /// <param name="documentTypeId">Новый идентификатор типа документа (должен быть положительным).</param>
        public void ChangeDocumentType(int documentTypeId)
        {
            if (documentTypeId <= 0)
            {
                throw new DomainException("DocumentTypeId должен быть положительным числом.");
            }

            DocumentTypeId = documentTypeId;
        }
    }

}
