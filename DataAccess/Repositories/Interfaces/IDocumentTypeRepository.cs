using MedicineCareBridge.DataAccess.Entities;

namespace MedicineCareBridge.DataAccess.Repositories.Interfaces
{
    public interface IDocumentTypeRepository
    {
        Task<DocumentTypeEntity?> GetByIdAsync(int id);
        Task<List<DocumentTypeEntity>> GetAllAsync();
        Task AddAsync(DocumentTypeEntity entity);
        Task UpdateAsync(DocumentTypeEntity entity);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);

        // Дополнительные методы
        Task<DocumentTypeEntity?> GetByNameTypeAsync(string login);
        Task<List<DocumentTypeEntity>> GetPagedAsync(int page, int pageSize);
    }
}
