using MedicineCareBridge.Shared.DTO.Auth;

namespace MedicineCareBridge.Server.Services.Interfaces
{
    /// <summary>
    /// Сервис для аутентификации и регистрации пользователей.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Аутентификация пользователя по логину и паролю.
        /// </summary>
        /// <param name="dto">Данные для входа (логин + пароль).</param>
        /// <returns>
        /// DTO с JWT‑токеном и временем истечения.
        /// </returns>
        Task<LoginResponseDto> AuthenticateAsync(LoginRequestDto dto);

        /// <summary>
        /// Регистрация нового пользователя и инициализация его личных данных.
        /// </summary>
        /// <param name="dto">Данные для регистрации (login, password, personal data).</param>
        /// <returns>Асинхронная задача.</returns>
        Task RegisterAsync(RegisterRequestDto dto);
    }
}
