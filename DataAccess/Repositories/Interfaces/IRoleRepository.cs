using MedicineCareBridge.DataAccess.Entities;

namespace MedicineCareBridge.DataAccess.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<RoleEntity?> GetByIdAsync(int id);
        Task<List<RoleEntity>> GetAllAsync();
        Task AddAsync(RoleEntity entity);
        Task UpdateAsync(RoleEntity entity);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);

        // по названию
        Task<RoleEntity?> GetByNameEngAsync(string nameEng);
        Task<RoleEntity?> GetByNameRuAsync(string nameRu);
    }
}
