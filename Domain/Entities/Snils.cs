using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.Entities
{
    /// <summary>
    /// СНИЛС
    /// </summary>
    public class Snils
    {
        /// <summary>Название документа, соответствет типу документа (на русском)</summary>
        public string DocumentName { get; private set; } = string.Empty;

        /// <summary>Номер СНИЛС (11 цифр)</summary>
        public string NumSnils { get; private set; } = string.Empty; // Надо в остальных проектах поправить с int на string

        /// <summary>Внешний ключ на <see cref="User.Id"/></summary>
        public int UserId { get; private set; }
        /// <summary>Навигационное свойство на <see cref="User"/></summary>
        public User User { get; private set; } = default!;

        /// <summary>Внешний ключ на <see cref="DocumentType.Id"/></summary>
        public int DocumentTypeId { get; private set; }
        /// <summary>Навигационное свойство на <see cref="DocumentType"/></summary>
        public DocumentType DocumentType { get; private set; } = default!;

        /// <summary>Конструктор для EF‑фреймворка.</summary>
        private Snils() { }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="Snils"/>.
        /// </summary>
        /// <param name="documentName">Название документа (не может быть пустым).</param>
        /// <param name="numSnils">Номер СНИЛС из 11 цифр.</param>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="documentTypeId">Идентификатор типа документа.</param>
        /// <exception cref="DomainException">Если параметры не корректны</exception>
        public Snils(string documentName, string numSnils, int userId, int documentTypeId)
        {
            if (string.IsNullOrWhiteSpace(documentName))
            {
                throw new DomainException("DocumentName не может быть пустым.");
            }
            if (!Regex.IsMatch(numSnils, "^\\d{11}$"))
            {
                throw new DomainException("Num должен содержать ровно 11 цифр для СНИЛС.");
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
            NumSnils = numSnils;
            UserId = userId;
            DocumentTypeId = documentTypeId;
        }
    }
}
