using MedicineCareBridge.Shared.DTO.Documents;

namespace MedicineCareBridge.Server.Services.Interfaces
{
    /// <summary>
    /// Сервис работы со страховым документом пользователя (связь 1:1).
    /// </summary>
    public interface IInsuranceDocumentService
    {
        /// <summary>
        /// Получить страховой документ пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>DTO страхового документа, или null если нет.</returns>
        Task<InsuranceDocumentDto?> GetByUserIdAsync(int userId);

        /// <summary>
        /// Создать или обновить страховой документ пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="dto">DTO новых данных документа.</param>
        /// <returns>DTO сохранённого документа.</returns>
        Task<InsuranceDocumentDto> CreateOrUpdateAsync(int userId, InsuranceDocumentDto dto);

        /// <summary>
        /// Удалить страховой документ пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Асинхронная задача.</returns>
        Task DeleteAsync(int userId);
    }
}
