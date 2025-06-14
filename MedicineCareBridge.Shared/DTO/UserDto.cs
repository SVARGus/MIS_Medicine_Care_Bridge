using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineCareBridge.Shared.DTO
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Login { get; set; } = null!;

        // Обычно пароль не передаём в DTO для UI/клиента, 
        // но если нужно, можно добавить (например, для передачи на сервер)
         public string Password { get; set; } = null!;

        // Роли пользователя — можно передавать список строк или DTO ролей
        public List<RoleDto> Roles { get; set; } = new();

        // Личные данные — отдельный DTO
        public PersonalDataDto? PersonalData { get; set; }

        // Типы документов — передача ID или DTO
        public List<int> UserDocumentTypeIds { get; set; } = new();

        // Паспортные данные
        public PassportDto? Passport { get; set; }

        // СНИЛС
        public SnilsDto? Snils { get; set; }

        // Страховой документ
        public InsuranceDocumentDto? InsuranceDocument { get; set; }

        // Универсальные документы
        public List<UniversalDocumentDto> UniversalDocuments { get; set; } = new();
    }
}
