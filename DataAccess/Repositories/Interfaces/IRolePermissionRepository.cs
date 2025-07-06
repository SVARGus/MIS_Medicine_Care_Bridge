using MedicineCareBridge.DataAccess.Entities;

namespace MedicineCareBridge.DataAccess.Repositories.Interfaces
{
    public interface IRolePermissionRepository
    {
        Task<IEnumerable<RolePermissionEntity>> GetAllAsync();
        Task<RolePermissionEntity?> GetAsync(int roleId, int permissionId);
        Task AddAsync(RolePermissionEntity entity);
        Task DeleteAsync(int roleId, int permissionId);
    }
}
