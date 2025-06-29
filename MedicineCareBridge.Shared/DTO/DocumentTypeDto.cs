using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineCareBridge.Shared.DTO
{
    public class DocumentTypeDto
    {
        /// <summary>Идентификатор типа документа</summary>
        public int Id { get; set; }

        /// <summary>Название типа документа</summary>
        public string NameType { get; set; } = string.Empty;
    }
}
