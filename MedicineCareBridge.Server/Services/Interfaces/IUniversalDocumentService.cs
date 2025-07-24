using MedicineCareBridge.Shared.DTO.Documents;

namespace MedicineCareBridge.Server.Services.Interfaces
{
    /// <summary>
    /// Сервис работы с универсальными документами пользователя (связь 1:N).
    /// </summary>
    public interface IUniversalDocumentService
    {
        /// <summary>
        /// Получить все универсальные документы пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Список DTO документов.</returns>
        Task<IEnumerable<UniversalDocumentDto>> GetByUserIdAsync(int userId);

        /// <summary>
        /// Добавить новый универсальный документ пользователю.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="dto">DTO новых данных документа.</param>
        /// <returns>DTO сохранённого документа.</returns>
        Task<UniversalDocumentDto> AddAsync(int userId, UniversalDocumentDto dto);

        /// <summary>
        /// Обновить существующий универсальный документ пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="dto">DTO обновлённых данных (Id обязан быть заполнен).</param>
        /// <returns>DTO обновлённого документа.</returns>
        Task<UniversalDocumentDto> UpdateAsync(int userId, UniversalDocumentDto dto);

        /// <summary>
        /// Удалить универсальный документ пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="documentId">Идентификатор документа.</param>
        /// <returns>Асинхронная задача.</returns>
        Task DeleteAsync(int userId, int documentId);
    }
}
