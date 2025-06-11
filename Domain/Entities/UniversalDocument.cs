using Domain.Exceptions;

namespace Domain.Entities
{
    /// <summary>
    /// Универсальный документ (таблица UniversalDocument)
    /// </summary>
    public class UniversalDocument
    {
        /// <summary>Название документа (например, "Сертификат", "Справка" и т.д.), пока не присвоен отдельный тип документа</summary>
        public string DocumentName { get; private set; } = string.Empty;

        /// <summary>Идентификатор документа (назначается БД).</summary>
        public int Id { get; private set; }

        /// <summary>Номер или уникальный идентификатор документа</summary>
        public string Num { get; private set; } = string.Empty;

        /// <summary>Описание документа (при необходимости)</summary>
        public string Description { get; private set; } = string.Empty;

        /// <summary>Дата выдачи документа</summary>
        public DateTime DateOfIssue { get; private set; }

        /// <summary>Внешний ключ на <see cref="User.Id"/></summary>
        public int UserId { get; private set; }
        /// <summary>Навигационное свойство на <see cref="User"/></summary>
        public User User { get; private set; } = default!;

        /// <summary>Внешний ключ на <see cref="DocumentType.Id"/></summary>
        public int DocumentTypeId { get; private set; }
        /// <summary>Навигационное свойство на <see cref="DocumentType"/></summary>
        public DocumentType DocumentType { get; private set; } = default!;

        /// <summary>Конструктор для EF‑фреймворка.</summary>
        private UniversalDocument() { }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="UniversalDocument"/> с переданными данными.
        /// </summary>
        /// <param name="documentName">Название документа (не может быть пустым).</param>
        /// <param name="num">Номер или уникальный идентификатор документа (не может быть пустым).</param>
        /// <param name="description">Описание документа (может быть пустым).</param>
        /// <param name="dateOfIssue">Дата выдачи документа (должна быть задана).</param>
        /// <param name="userId">Идентификатор пользователя (должен быть положительным).</param>
        /// <param name="documentTypeId">Идентификатор типа документа (должен быть положительным).</param>
        /// <exception cref="DomainException">
        /// Выбрасывается, если обязательные поля пусты или некорректны:
        /// <list type="bullet">
        ///   <item><description><paramref name="documentName"/> или <paramref name="num"/> пусты.</description></item>
        ///   <item><description><paramref name="dateOfIssue"/> равно значению по умолчанию.</description></item>
        ///   <item><description><paramref name="userId"/> или <paramref name="documentTypeId"/> не положительны.</description></item>
        /// </list>
        /// </exception>
        public UniversalDocument(string documentName, string num, string description, DateTime dateOfIssue, int userId, int documentTypeId)
        {
            if (string.IsNullOrWhiteSpace(documentName))
            {
                throw new DomainException("DocumentName не может быть пустым.");
            }
            if (string.IsNullOrWhiteSpace(num))
            {
                throw new DomainException("Num не может быть пустым.");
            }
            if (dateOfIssue == default)
            {
                throw new DomainException("DateOfIssue должен быть задан.");
            }
            if (userId <= 0)
            {
                throw new DomainException("UserId должен быть положительным.");
            }
            if (documentTypeId <= 0)
            {
                throw new DomainException("DocumentTypeId должен быть положительным.");
            }

            DocumentName = documentName;
            Num = num;
            Description = description;
            DateOfIssue = dateOfIssue;
            UserId = userId;
            DocumentTypeId = documentTypeId;
        }

        /// <summary>
        /// Обновляет описание документа.
        /// </summary>
        /// <param name="description">Новое описание (может быть пустым).</param>
        public void UpdateDescription(string description)
        {
            Description = description;
        }

        /// <summary>
        /// Обновляет дату выдачи документа.
        /// </summary>
        /// <param name="dateOfIssue">Новая дата выдачи (не может быть значением по умолчанию).</param>
        /// <exception cref="DomainException">Если <paramref name="dateOfIssue"/> равно значению по умолчанию.</exception>
        public void UpdateDateOfIssue(DateTime dateOfIssue)
        {
            if (dateOfIssue == default)
            {
                throw new DomainException("DateOfIssue должен быть задан.");
            }

            DateOfIssue = dateOfIssue;
        }

        /// <summary>
        /// Изменяет название документа.
        /// </summary>
        /// <param name="documentName">Новое название (не может быть пустым).</param>
        /// <exception cref="DomainException">Если <paramref name="documentName"/> пусто.</exception>
        public void UpdateDocumentName(string documentName)
        {
            if (string.IsNullOrWhiteSpace(documentName))
            {
                throw new DomainException("DocumentName не может быть пустым.");
            }

            DocumentName = documentName;
        }

        /// <summary>
        /// Изменяет номер документа.
        /// </summary>
        /// <param name="num">Новый номер (не может быть пустым).</param>
        /// <exception cref="DomainException">Если <paramref name="num"/> пусто.</exception>
        public void UpdateNum(string num)
        {
            if (string.IsNullOrWhiteSpace(num))
            {
                throw new DomainException("Num не может быть пустым.");
            }

            Num = num;
        }

        /// <summary>
        /// Изменяет тип документа.
        /// </summary>
        /// <param name="documentTypeId">Новый идентификатор типа документа (должен быть положительным).</param>
        /// <exception cref="DomainException">Если <paramref name="documentTypeId"/> не положителен.</exception>
        public void ChangeDocumentType(int documentTypeId)
        {
            if (documentTypeId <= 0)
            {
                throw new DomainException("DocumentTypeId должен быть положительным.");
            }

            DocumentTypeId = documentTypeId;
        }
    }
}
