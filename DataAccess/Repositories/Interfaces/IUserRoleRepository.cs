using MedicineCareBridge.DataAccess.Entities;

namespace MedicineCareBridge.DataAccess.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<UserRoleEntity>> GetAllAsync();
        Task<UserRoleEntity?> GetAsync(int userId, int roleId);
        Task AddAsync(UserRoleEntity entity);
        Task DeleteAsync(int userId, int roleId);
    }
}
