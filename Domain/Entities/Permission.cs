using Domain.Exceptions;

namespace Domain.Entities
{
    /// <summary>
    /// Права пользователей (например: "Изменение данных пользователя", "изменение расписания" и другие)
    /// </summary>
    public class Permission
    {
        /// <summary>Идентификатор права (назначается БД).</summary>
        public int Id { get; private set; }

        /// <summary>Текс описания права. Например <c>CanViewPatients</c></summary>
        public string Text { get; private set; } = string.Empty;

        /// <summary>Логическое значение: доступно (true) \ недоступно (false)</summary>
        public bool IsAllowed { get; private set; }

        /// <summary>Связь "многие-ко-многим" с ролями через сущность <see cref="RolePermission"/></summary>
        public IReadOnlyCollection<RolePermission> RolePermissions => _rolePermissions;
        public List<RolePermission> _rolePermissions = new List<RolePermission>();

        /// <summary>Конструктор для EF‑фреймворка.</summary>
        private Permission() { }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="Permission"/> с заданным текстом и флагом доступности.
        /// </summary>
        /// <param name="text">Уникальный код или текстовое имя права (например, <c>CanEditSchedule</c>).</param>
        /// <param name="isAllowed">Флаг, указывающий, разрешено ли это право.</param>
        /// <exception cref="DomainException">Если <paramref name="text"/> == <c>null</c> или пустая строка.</exception>
        public Permission(string text, bool isAllowed)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new DomainException("Text права не может быть пустым.");
            }

            Text = text;
            IsAllowed = isAllowed;
        }

        /// <summary>
        /// Выдаёт данное право роли с указанным идентификатором.
        /// </summary>
        /// <param name="roleId">Идентификатор роли, которой выдаётся право.</param>
        /// <exception cref="DomainException">
        /// Если право уже выдано роли <paramref name="roleId"/>, 
        /// содержит информацию о <see cref="Text"/> и текущем значении <see cref="IsAllowed"/>.
        /// </exception>
        public void GrantToRole(int roleId)
        {
            if (_rolePermissions.Any(rp => rp.RoleId == roleId))
            {
                throw new DomainException($"Право '{Text}' уже выдано роли с Id={roleId}. Текущее состояние IsAllowed={IsAllowed}.");
            }

            _rolePermissions.Add(new RolePermission(roleId, this.Id));
        }

        /// <summary>
        /// Изменяет состояние доступности этого права.
        /// </summary>
        /// <param name="isAllowed">Новое значение флага доступности.</param>
        /// <exception cref="DomainException">
        /// Если новое значение совпадает с текущим (<paramref name="isAllowed"/> == <see cref="IsAllowed"/>).
        /// </exception>
        public void SetAllowed(bool isAllowed)
        {
            if (isAllowed == IsAllowed)
            {
                throw new DomainException($"Состояние IsAllowed уже равно {IsAllowed}. Изменение не требуется.");
            }

            IsAllowed = isAllowed;
        }
    }
}
