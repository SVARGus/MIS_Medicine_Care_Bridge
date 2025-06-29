using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineCareBridge.Shared.DTO.Admin
{
    public class UserDto
    {
        public string Login { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
