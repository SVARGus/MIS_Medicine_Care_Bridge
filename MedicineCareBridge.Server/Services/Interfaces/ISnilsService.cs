using MedicineCareBridge.Shared.DTO.Documents;

namespace MedicineCareBridge.Server.Services.Interfaces
{
    /// <summary>
    /// Сервис работы с СНИЛС пользователя (связь 1:1).
    /// </summary>
    public interface ISnilsService
    {
        /// <summary>
        /// Получить СНИЛС пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>DTO СНИЛС, или null если нет.</returns>
        Task<SnilsDto?> GetByUserIdAsync(int userId);

        /// <summary>
        /// Создать или обновить СНИЛС пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="dto">DTO новых данных СНИЛС.</param>
        /// <returns>DTO сохранённых данных СНИЛС.</returns>
        Task<SnilsDto> CreateOrUpdateAsync(int userId, SnilsDto dto);

        /// <summary>
        /// Удалить СНИЛС пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Асинхронная задача.</returns>
        Task DeleteAsync(int userId);
    }
}
