using MedicineCareBridge.Shared.DTO.Documents;

namespace MedicineCareBridge.Server.Services.Interfaces
{
    /// <summary>
    /// Сервис работы с паспортными данными пользователя (связь 1:1).
    /// </summary>
    public interface IPassportService
    {
        /// <summary>
        /// Получить паспортные данные пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>DTO паспортных данных, или null если нет.</returns>
        Task<PassportDto?> GetByUserIdAsync(int userId);

        /// <summary>
        /// Создать или обновить паспорт пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="dto">DTO новых паспортных данных.</param>
        /// <returns>DTO сохранённых паспортных данных.</returns>
        Task<PassportDto> CreateOrUpdateAsync(int userId, PassportDto dto);

        /// <summary>
        /// Удалить паспортные данные пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Асинхронная задача.</returns>
        Task DeleteAsync(int userId);
    }
}
