using MedicineCareBridge.DataAccess.Entities;

namespace MedicineCareBridge.DataAccess.Repositories.Interfaces
{
    public interface IPassportRepository
    {
        Task<PassportEntity?> GetByUserIdAsync(int userId);
        Task<List<PassportEntity>> GetAllAsync();
        Task AddAsync(PassportEntity entity);
        Task UpdateAsync(PassportEntity entity);
        Task DeleteAsync(int userId);
        Task<bool> ExistsAsync(int userId);
    }
}
