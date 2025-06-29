using Domain.Exceptions;

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

        /// <summary>Внешний ключ на <see cref="User.Id"/></summary>
        public int UserId { get; private set; }
        /// <summary>Навигационное свойство на <see cref="User"/></summary>
        public User User { get; private set; } = default!;

        /// <summary>Дополнительная информация о паспорте (например, где выдан)</summary>
        public string Info { get; private set; } = string.Empty;

        /// <summary>Дата выдачи документа</summary>
        public DateTime DateOfIssue { get; private set; }

        /// <summary>Внешний ключ на <see cref="DocumentType.Id"/></summary>
        public int DocumentTypeId { get; private set; }
        /// <summary>Навигационное свойство на <see cref="DocumentType"/></summary>
        public DocumentType DocumentType { get; private set; } = default!;

        /// <summary>Конструктор для EF‑фреймворка.</summary>
        private Passport() { }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="Passport"/>.
        /// </summary>
        /// <param name="documentName">Название документа (не может быть пустым).</param>
        /// <param name="num">Номер паспорта (не может быть пустым).</param>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="info">Дополнительная информация (не обязательна).</param>
        /// <param name="dateOfIssue">Дата выдачи (не позже текущей даты).</param>
        /// <param name="documentTypeId">Идентификатор типа документа</param>
        public Passport(string documentName, string passportNum, int userId, string info, DateTime dateOfIssue, int documentTypeId)
        {
            if (string.IsNullOrWhiteSpace(documentName))
            {
                throw new DomainException("DocumentName не может быть пустым.");
            }
            if (string.IsNullOrWhiteSpace(passportNum))
            {
                throw new DomainException("PassportNum не может быть пустым.");
            }
            if (dateOfIssue > DateTime.Now)
            {
                throw new DomainException("DateOfIssue не может быть позже текущей даты.");
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
            PassportNum = passportNum;
            UserId = userId;
            Info = info;
            DateOfIssue = dateOfIssue;
            DocumentTypeId = documentTypeId;
        }
    }
}
