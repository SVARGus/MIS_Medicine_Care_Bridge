using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineCareBridge.Shared.DTO
{
    /// <summary>
    /// DTO для страхового документа
    /// </summary>
    public class InsuranceDocumentDto
    {
        /// <summary>Номер страхового полиса</summary>
        public int Num { get; set; }

        /// <summary>ID пользователя, которому принадлежит документ</summary>
        public int UserId { get; set; }

        /// <summary>ID типа документа</summary>
        public int DocumentTypeId { get; set; }

        /// <summary>Название типа документа (опционально, для отображения)</summary>
        public string? DocumentTypeName { get; set; }

        /// <summary>ФИО пользователя (опционально, для отображения)</summary>
        public string? UserFullName { get; set; }
    }
}
