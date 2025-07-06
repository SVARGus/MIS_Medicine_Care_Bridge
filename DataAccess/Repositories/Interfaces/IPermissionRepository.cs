using MedicineCareBridge.DataAccess.Entities;

namespace MedicineCareBridge.DataAccess.Repositories.Interfaces
{
    public interface IPermissionRepository
    {
        Task<PermissionEntity?> GetByIdAsync(int id);
        Task<List<PermissionEntity>> GetAllAsync();
        Task AddAsync(PermissionEntity entity);
        Task UpdateAsync(PermissionEntity entity);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);

        // поиск по тексту
        Task<PermissionEntity?> GetByTextAsync(string text);
    }
}
