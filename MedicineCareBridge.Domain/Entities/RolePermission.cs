using MedicineCareBridge.Domain.Exceptions;

namespace MedicineCareBridge.Domain.Entities
{
    /// <summary>
    /// Промежуточная сущность «Роль–Право»
    /// </summary>
    public class RolePermission
    {
        /// <summary>Внешний ключ на <see cref="Role.Id"/></summary>
        public int RoleId { get; private set; }
        /// <summary>Навигационное свойство на <see cref="Role"/></summary>
        public Role Role { get; private set; } = default!;

        /// <summary>Внешний ключ на <see cref="Permission.Id"/></summary>
        public int PermissionId { get; private set; }
        /// <summary>Навигационное свойство на <see cref="Permission"/></summary>
        public Permission Permission { get; private set; } = default!;

        /// <summary>Конструктор для EF‑фреймворка.</summary>
        private RolePermission() { }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="RolePermission"/>
        /// для связи роли и права.
        /// </summary>
        /// <param name="roleId">Идентификатор роли.</param>
        /// <param name="permissionId">Идентификатор права.</param>
        public RolePermission(int roleId, int permissionId)
        {
            if (roleId <= 0)
            {
                throw new DomainException("RoleId должен быть положительным.");
            }
            if (permissionId <= 0)
            {
                throw new DomainException("PermissionId должен быть положительным.");
            }

            RoleId = roleId;
            PermissionId = permissionId;
        }
    }
}
