using MedicineCareBridge.DataAccess.Entities;

namespace MedicineCareBridge.DataAccess.Repositories.Interfaces
{
    public interface IInsuranceDocumentRepository
    {
        Task<InsuranceDocumentEntity?> GetByIdAsync(int id);
        Task<List<InsuranceDocumentEntity>> GetAllAsync();
        Task AddAsync(InsuranceDocumentEntity entity);
        Task UpdateAsync(InsuranceDocumentEntity entity);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);

        // Дополнительные методы
        Task<InsuranceDocumentEntity?> GetByNameTypeAsync(string num);
    }
}
