using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineCareBridge.Shared.DTO
{
    /// <summary>
    /// DTO для представления прав доступа (Permission)
    /// </summary>
    public class PermissionDto
    {
        /// <summary>Уникальный идентификатор права</summary>
        public int Id { get; set; }

        /// <summary>Описание права, например "CanViewPatients"</summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>Разрешено ли это право</summary>
        public bool IsAllowed { get; set; }
    }
}
