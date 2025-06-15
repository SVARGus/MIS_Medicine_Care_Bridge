using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineCareBridge.Shared.DTO
{
    /// <summary>
    /// DTO для паспортных данных пользователя
    /// </summary>
    public class PassportDto
    {
        /// <summary>Номер паспорта</summary>
        public int PassportNum { get; set; }

        /// <summary>ID пользователя</summary>
        public int UserId { get; set; }

        /// <summary>Информация о паспорте (где выдан)</summary>
        public string Info { get; set; } = string.Empty;

        /// <summary>Дата выдачи паспорта</summary>
        public DateTime DateOfIssue { get; set; }

        /// <summary>ID типа документа</summary>
        public int DocumentTypeId { get; set; }

        /// <summary>Название типа документа (например, "Паспорт")</summary>
        public string? DocumentTypeName { get; set; }

        /// <summary>ФИО пользователя (опционально)</summary>
        public string? UserFullName { get; set; }
    }
}
