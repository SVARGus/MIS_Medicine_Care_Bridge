using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Entities
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    public class User
    {
        public int Id { get; private set; }

        /// <summary>Логин (email или телефон)</summary>
        public string Login { get; private set; } = string.Empty;

        /// <summary>Пароль в виде одельной сущности Password с валидацией (позже будет добавлено хеширование) </summary>
        public Password? Password { get; private set; }

        /// <summary>Связь "многие-ко-многим" с пользователями через сущность <see cref="UserRole"/></summary>
        public IReadOnlyCollection<UserRole> UserRoles => _userRoles;
        public readonly List<UserRole> _userRoles = new List<UserRole>();

        /// <summary>Личные данные (таблица Data)</summary>
        public PersonalData? PersonalData { get; private set; }

        /// <summary>Связь "многие-ко-многим" с пользователем через сущность <see cref="UserDocumentType"/></summary>
        public IReadOnlyCollection<UserDocumentType> UserDocuments => _userDocuments;
        private readonly List<UserDocumentType> _userDocuments = new();

        /// <summary>Паспортные данные (если есть)</summary>
        public Passport? Passport { get; private set; }

        /// <summary>СНИЛС (если есть)</summary>
        public Snils? Snils { get; private set; }

        /// <summary>Страховой документ (если есть)</summary>
        public InsuranceDocument? InsuranceDocument { get; private set; }

        /// <summary>Конструктор для EF‑фреймворка.</summary>
        private User() { }

        /// <summary>
        /// Инициализирует нового пользователя с логином и паролем.
        /// </summary>
        /// <param name="login">Email или телефон в корректном формате.</param>
        /// <param name="password">Объект пароля (<see cref="Password"/>).</param>
        /// <exception cref="DomainException">
        /// Если <paramref name="login"/> пуст или не соответствует формату email/телефона,
        /// или <paramref name="password"/> == null.
        /// </exception>
        public User(string login, Password password)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new DomainException("Login не может быть пустым.");
            }

            // Валидация: либо email, либо телефон
            var isEmail = Email.IsValid(login);
            var isPhone = PhoneNumber.IsValid(login);
            if (!isEmail && !isPhone)
            {
                throw new DomainException("Login должен быть корректным email или номером телефона.");
            }

            Login = login;
            Password = password ?? throw new DomainException("Password не может быть null.");
        }

        /// <summary>
        /// Изменяет логин пользователя.
        /// </summary>
        /// <param name="newLogin">Новый логин — должен быть email или телефон.</param>
        public void ChangeLogin(string newLogin)
        {
            if (string.IsNullOrWhiteSpace(newLogin))
            {
                throw new DomainException("Login не может быть пустым.");
            }
            if (!Email.IsValid(newLogin) && !PhoneNumber.IsValid(newLogin))
            {
                throw new DomainException("Login должен быть корректным email или номером телефона.");
            }

            Login = newLogin;
        }

        /// <summary>
        /// Обновляет пароль пользователя.
        /// </summary>
        /// <param name="newPassword">Новый пароль (value object <see cref="Password"/>).</param>
        public void ChangePassword(Password newPassword)
        {
            Password = newPassword ?? throw new DomainException("Password не может быть null.");
        }

        /// <summary>
        /// Назначает пользователю роль.
        /// </summary>
        /// <param name="roleId">Идентификатор роли.</param>
        /// <exception cref="DomainException">Если роль уже назначена.</exception>
        public void AssignRole(int roleId)
        {
            if (_userRoles.Any(ur => ur.RoleId == roleId))
            {
                throw new DomainException($"Роль с Id={roleId} уже назначена пользователю {Id}.");
            }

            _userRoles.Add(new UserRole(this.Id, roleId));
        }

        /// <summary>
        /// Снимает роль с пользователя.
        /// </summary>
        /// <param name="roleId">Идентификатор роли.</param>
        public void RemoveRole(int roleId)
        {
            var link = _userRoles.FirstOrDefault(ur => ur.RoleId == roleId);
            if (link != null)
            {
                _userRoles.Remove(link);
            }
        }

        /// <summary>
        /// Устанавливает личные данные пользователя.
        /// </summary>
        /// <param name="data">Объект личных данных <see cref="PersonalData"/>.</param>
        public void SetPersonalData(PersonalData data)
        {
            PersonalData = data ?? throw new DomainException("PersonalData не может быть null.");
        }

        /// <summary>
        /// Добавляет связь между пользователем и типом документа.
        /// </summary>
        /// <param name="documentTypeId">Идентификатор типа документа.</param>
        public void AddDocumentType(int documentTypeId)
        {
            if (_userDocuments.Any(ud => ud.DocumentTypeId == documentTypeId))
            {
                return;
            }
            _userDocuments.Add(new UserDocumentType(this.Id, documentTypeId));
        }

        /// <summary>
        /// Удаляет связь пользователя с типом документа.
        /// </summary>
        /// <param name="documentTypeId">Идентификатор типа документа.</param>
        public void RemoveDocumentType(int documentTypeId)
        {
            var link = _userDocuments.FirstOrDefault(ud => ud.DocumentTypeId == documentTypeId);
            if (link != null)
            {
                _userDocuments.Remove(link);
            }
        }

        /// <summary>
        /// Устанавливает паспортные данные пользователя.
        /// </summary>
        /// <param name="passport">Объект <see cref="Passport"/>.</param>
        public void SetPassport(Passport passport)
        {
            Passport = passport ?? throw new DomainException("Passport не может быть null.");
        }

        /// <summary>
        /// Устанавливает СНИЛС пользователя.
        /// </summary>
        /// <param name="snils">Объект <see cref="Snils"/>.</param>
        public void SetSnils(Snils snils)
        {
            Snils = snils ?? throw new DomainException("Snils не может быть null.");
        }

        /// <summary>
        /// Устанавливает страховой документ пользователя.
        /// </summary>
        /// <param name="doc">Объект <see cref="InsuranceDocument"/>.</param>
        public void SetInsuranceDocument(InsuranceDocument doc)
        {
            InsuranceDocument = doc ?? throw new DomainException("InsuranceDocument не может быть null.");
        }
    }
}
