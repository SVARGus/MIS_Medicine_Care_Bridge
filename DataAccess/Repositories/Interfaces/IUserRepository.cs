using MedicineCareBridge.DataAccess.Entities;

namespace MedicineCareBridge.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity?> GetByIdAsync(int id);
        Task<List<UserEntity>> GetAllAsync();
        Task AddAsync(UserEntity user);
        Task UpdateAsync(UserEntity user);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);

        // Дополнительные методы
        Task<UserEntity?> GetByLoginAsync(string login);
        Task<List<UserEntity>> GetPagedAsync (int page, int pageSize);
        Task AssignRoleAsync(int userId, int roleId);
        Task ReplaceRolesAsync(int userId, IEnumerable<int> roleIds);
    }
}
