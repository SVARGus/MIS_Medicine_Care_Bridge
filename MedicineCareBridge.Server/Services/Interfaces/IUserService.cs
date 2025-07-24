using MedicineCareBridge.Shared.DTO.User;
using MedicineCareBridge.Shared.DTO.Shared;

namespace MedicineCareBridge.Server.Services.Interfaces
{
    /// <summary>
    /// Сервис управления основными данными пользователей: создание, чтение, обновление, удаление, постраничный вывод.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Получить данные пользователя по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>DTO с данными пользователя.</returns>
        Task<UserReadDto> GetByIdAsync(int id);

        /// <summary>
        /// Получить список пользователей с пагинацией.
        /// </summary>
        /// <param name="page">Номер страницы (начиная с 1).</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns>Постраничный результат с DTO пользователей.</returns>
        Task<PaginatedResult<UserReadDto>> GetAllAsync(int page, int pageSize);

        /// <summary>
        /// Создать нового пользователя с указанием ролей.
        /// </summary>
        /// <param name="dto">DTO с данными для создания.</param>
        /// <returns>DTO созданного пользователя.</returns>
        Task<UserReadDto> CreateAsync(UserCreateDto dto);

        /// <summary>
        /// Обновить существующего пользователя (пароль, роли и т.п.).
        /// </summary>
        /// <param name="dto">DTO с новыми данными пользователя.</param>
        /// <returns>DTO обновлённого пользователя.</returns>
        Task<UserReadDto> UpdateAsync(UserUpdateDto dto);

        /// <summary>
        /// Удалить пользователя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Асинхронная задача.</returns>
        Task DeleteAsync(int id);
    }
}
