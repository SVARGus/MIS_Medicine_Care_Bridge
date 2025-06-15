using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineCareBridge.Client.Models.Auth
{
    /// <summary>
    /// Модель пользователя для авторизации.
    /// </summary>
    public class LoginUserModel
    {
        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
