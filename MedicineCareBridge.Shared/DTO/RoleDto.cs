using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineCareBridge.Shared.DTO
{
    /// <summary>
    /// DTO для представления роли пользователя
    /// </summary>
    public class RoleDto
    {
        /// <summary>Уникальный идентификатор роли</summary>
        public int Id { get; set; }

        /// <summary>Название роли (на русском языке)</summary>
        public string NameRus { get; set; } = string.Empty;

        /// <summary>Название роли (на английском языке)</summary>
        public string NameEng { get; set; } = string.Empty;

        /// <summary>Список разрешений, привязанных к роли (опционально)</summary>
        public List<PermissionDto>? Permissions { get; set; }
    }
}
