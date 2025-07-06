using MedicineCareBridge.DataAccess.Entities;

namespace MedicineCareBridge.DataAccess.Repositories.Interfaces
{
    public interface ISnilsRepository
    {
        Task<SnilsEntity?> GetByNumAsync(string numSnils);
        Task<List<SnilsEntity>> GetAllAsync();
        Task AddAsync(SnilsEntity entity);
        Task UpdateAsync(SnilsEntity entity);
        Task DeleteAsync(string numSnils);
        Task<bool> ExistsAsync(string numSnils);
    }
}
