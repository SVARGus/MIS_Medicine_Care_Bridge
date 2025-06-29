using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineCareBridge.Shared.DTO
{
    /// <summary>
    /// DTO для представления личных данных пользователя
    /// </summary>
    public class PersonalDataDto
    {
        /// <summary>Идентификатор пользователя (UserId)</summary>
        public int UserId { get; set; }

        /// <summary>Имя</summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>Фамилия</summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>Отчество</summary>
        public string MiddleName { get; set; } = string.Empty;

        /// <summary>Дата рождения</summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>Телефон</summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>Email</summary>
        public string Email { get; set; } = string.Empty;
    }
}
