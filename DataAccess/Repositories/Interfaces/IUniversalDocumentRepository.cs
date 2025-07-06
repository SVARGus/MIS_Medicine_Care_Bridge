using MedicineCareBridge.DataAccess.Entities;

namespace MedicineCareBridge.DataAccess.Repositories.Interfaces
{
    public interface IUniversalDocumentRepository
    {
        Task<UniversalDocumentEntity?> GetByIdAsync(int id);
        Task<List<UniversalDocumentEntity>> GetAllAsync();
        Task AddAsync(UniversalDocumentEntity entity);
        Task UpdateAsync(UniversalDocumentEntity entity);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);

        Task<List<UniversalDocumentEntity>> GetByUserIdAsync(int userId);
    }
}
