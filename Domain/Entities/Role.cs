using Domain.Exceptions;

namespace Domain.Entities
{
    /// <summary>
    /// Роль пользователя (например <c>Admin</c>, <c>Visitor</c>, <c>Patient</c>)
    /// </summary>
    public class Role
    {
        /// <summary>Идентификатор роли (назначается БД).</summary>
        public int Id { get; private set; }

        /// <summary>Название роли на Русском языке </summary>
        public string NameRus { get; private set; } = string.Empty;

        /// <summary>Название роли на Английском языке </summary>
        public string NameEng { get; private set; } = string.Empty;

        /// <summary>Связь "многие-ко-многим" с пользователями через сущность <see cref="UserRole"/></summary>
        public IReadOnlyCollection<UserRole> UserRoles => _userRoles;
        private readonly List<UserRole> _userRoles = new List<UserRole>();

        /// <summary>Связь "многие-ко-многим" с правами через <see cref="RolePermission"/></summary>
        public IReadOnlyCollection<RolePermission> RolePermissions => _rolePermissions;
        private readonly List<RolePermission> _rolePermissions = new();

        /// <summary>Конструктор для EF‑фреймворка.</summary>
        private Role() { }

        /// <summary>
        /// Инициализирует новую роль с заданными именами на русском и английском.
        /// </summary>
        /// <param name="nameRus">Название роли на русском.</param>
        /// <param name="nameEng">Название роли на английском.</param>
        /// <exception cref="DomainException">Если одно из названий пустое или состоит только из пробелов.</exception>
        public Role(string nameRus, string nameEng)
        {
            if (string.IsNullOrWhiteSpace(nameRus))
            {
                throw new DomainException("Название роли на русском языке не может быть пустым.");
            }
            if (string.IsNullOrWhiteSpace(nameEng))
            {
                throw new DomainException("Название роли на английском языке не может быть пустым.");
            }

            NameRus = nameRus;
            NameEng = nameEng;
        }

        /// <summary>
        /// Добавляет право к этой роли, если оно ещё не добавлено.
        /// </summary>
        /// <param name="permissionId">Идентификатор права.</param>
        public void AddPermission(int permissionId)
        {
            if (Id == 0)
            {
                throw new DomainException("Нельзя назначать права до присвоения роли идентификатора.");
            }

            if (_rolePermissions.Any(rp => rp.PermissionId == permissionId))
            {
                return;
            }

            _rolePermissions.Add(new RolePermission(this.Id, permissionId));
        }

        /// <summary>
        /// Назначает эту роль пользователю.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <exception cref="DomainException">Если эта роль уже назначена пользователю.</exception>
        public void AssignToUser(int userId)
        {
            if (Id == 0)
            {
                throw new DomainException("Нельзя назначать права до присвоения роли идентификатора.");
            }

            if (_userRoles.Any(ur => ur.UserId == userId))
            {
                throw new DomainException($"Роль '{NameEng}' уже назначена пользователю с ID {userId}.");
            }

            _userRoles.Add(new UserRole(userId, this.Id));
        }
    }
}
