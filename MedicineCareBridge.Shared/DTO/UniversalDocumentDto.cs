using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineCareBridge.Shared.DTO
{
    public class UniversalDocumentDto
    {
        public int Id { get; set; }

        /// <summary>Номер или уникальный идентификатор документа</summary>
        public string Num { get; set; } = null!;

        /// <summary>Название документа (например, «Сертификат»)</summary>
        public string DocumentName { get; set; } = null!;

        /// <summary>Описание документа (при необходимости)</summary>
        public string Description { get; set; } = null!;

        /// <summary>Дата выдачи документа</summary>
        public DateTime DateOfIssue { get; set; }

        /// <summary>Идентификатор пользователя</summary>
        public int UserId { get; set; }

        /// <summary>Идентификатор типа документа</summary>
        public int DocumentTypeId { get; set; }
    }
}
