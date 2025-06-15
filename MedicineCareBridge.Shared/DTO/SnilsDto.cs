using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineCareBridge.Shared.DTO
{
    /// <summary>
    /// DTO для СНИЛС пользователя
    /// </summary>
    public class SnilsDto
    {
        /// <summary>Номер СНИЛС</summary>
        public int NumSnils { get; set; }

        /// <summary>Идентификатор пользователя</summary>
        public int UserId { get; set; }

        /// <summary>Идентификатор типа документа (обычно "СНИЛС")</summary>
        public int DocumentTypeId { get; set; }
    }
}
