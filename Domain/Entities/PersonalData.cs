using Domain.ValueObjects;
using Domain.Exceptions;

namespace Domain.Entities
{
    /// <summary>
    /// «Личные данные» пользователя (таблица Data)
    /// </summary>
    public class PersonalData
    {
        /// <summary>Внешний ключ на <see cref="User.Id"/></summary>
        public int UserId { get; private set; }
        /// <summary>Навигационное свойство на <see cref="User"/></summary>
        public User User { get; private set; } = default!;

        /// <summary>Имя</summary>
        public string FirstName { get; private set; } = string.Empty;

        /// <summary>Фамилия</summary>
        public string LastName { get; private set; } = string.Empty;

        /// <summary>Отчество</summary>
        public string MiddleName { get; private set; } = string.Empty;

        /// <summary>Дата рождения</summary>
        public DateTime DateOfBirth { get; private set; }

        /// <summary>Телефон</summary>
        public PhoneNumber Phone { get; private set; }
         
        /// <summary>Email</summary>
        public Email? Email { get; private set; }

        /// <summary>Конструктор для EF‑фреймворка.</summary>
        private PersonalData() { }

        /// <summary>
        /// Инициализирует новые личные данные пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя (должен быть положительным).</param>
        /// <param name="firstName">Имя пользователя (обязательное, не может быть пустым или состоять только из пробелов).</param>
        /// <param name="lastName">Фамилия пользователя (обязательная, не может быть пустой или состоять только из пробелов).</param>
        /// <param name="middleName">Отчество пользователя (может быть пустым или null; в этом случае будет заменено на пустую строку).</param>
        /// <param name="dateOfBirth">Дата рождения пользователя (должна быть строго в прошлом).</param>
        /// <param name="phone">Номер телефона пользователя (может быть null; если указан, должен быть в корректном формате).</param>
        /// <param name="email">Email пользователя (может быть null или пустым; если указан, должен быть в корректном формате).</param>
        /// <exception cref="DomainException">
        /// Выбрасывается в следующих случаях:
        /// <list type="bullet">
        ///   <item><description><paramref name="userId"/> меньше или равен 0.</description></item>
        ///   <item><description><paramref name="firstName"/> пустое или содержит только пробелы.</description></item>
        ///   <item><description><paramref name="lastName"/> пустое или содержит только пробелы.</description></item>
        ///   <item><description><paramref name="dateOfBirth"/> — сегодняшняя дата или дата из будущего.</description></item>
        ///   <item><description><paramref name="phone"/> задан и не проходит валидацию.</description></item>
        ///   <item><description><paramref name="email"/> задан и не проходит валидацию.</description></item>
        /// </list>
        /// </exception>
        public PersonalData(int userId, string firstName, string lastName, string middleName, DateTime dateOfBirth, string phone, string? email)
        {
            if (userId <= 0)
            {
                throw new DomainException("UserId должен быть положительным.");
            }
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new DomainException("FirstName не может быть пустым.");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new DomainException("LastName не может быть пустым.");
            }
            if (dateOfBirth.Date >= DateTime.Today)
            {
                throw new DomainException("DateOfBirth должна быть в прошлом.");
            }
            if (!PhoneNumber.IsValid(phone))
                throw new DomainException("Неверный формат номера телефона.");

            if (!string.IsNullOrWhiteSpace(email) && !Email.IsValid(email))
                throw new DomainException("Неверный формат email.");

            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName?.Trim() ?? string.Empty;
            DateOfBirth = dateOfBirth;
            Phone = new PhoneNumber(phone);
            Email = string.IsNullOrWhiteSpace(email) ? null : new Email(email);
        }

        /// <summary>
        /// Обновляет имя пользователя.
        /// </summary>
        /// <param name="firstName">Новое имя (не пустое).</param>
        public void UpdateFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new DomainException("FirstName не может быть пустым.");
            FirstName = firstName.Trim();
        }

        /// <summary>
        /// Обновляет фамилию пользователя.
        /// </summary>
        /// <param name="lastName">Новая фамилия (не пустая).</param>
        public void UpdateLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new DomainException("LastName не может быть пустым.");
            LastName = lastName.Trim();
        }

        /// <summary>
        /// Обновляет отчество пользователя.
        /// </summary>
        /// <param name="middleName">Новое отчество (может быть пустым).</param>
        public void UpdateMiddleName(string middleName)
        {
            MiddleName = middleName?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Обновляет дату рождения.
        /// </summary>
        /// <param name="dateOfBirth">Новая дата рождения (должна быть в прошлом).</param>
        public void UpdateDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth.Date >= DateTime.Today)
                throw new DomainException("DateOfBirth должна быть в прошлом.");
            DateOfBirth = dateOfBirth.Date;
        }

        /// <summary>
        /// Устанавливает или обновляет номер телефона.
        /// </summary>
        /// <param name="phone">Новый номер телефона.</param>
        public void UpdatePhone(string phone)
        {
            if (!PhoneNumber.IsValid(phone))
            {
                throw new DomainException("Неверный формат номера телефона.");
            }
            Phone = new PhoneNumber(phone);
        }

        /// <summary>
        /// Устанавливает или обновляет email.
        /// </summary>
        /// <param name="email">Новый email.</param>
        public void UpdateEmail(string? email)
        {
            if (!string.IsNullOrWhiteSpace(email) && !Email.IsValid(email))
            {
                throw new DomainException("Неверный формат email.");
            }
            Email = string.IsNullOrWhiteSpace(email) ? null : new Email(email);
        }
    }
}
