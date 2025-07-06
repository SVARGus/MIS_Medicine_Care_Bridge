using MedicineCareBridge.DataAccess.Entities;

namespace MedicineCareBridge.DataAccess.Repositories.Interfaces
{
    public interface IPersonalDataRepository
    {
        Task<PersonalDataEntity?> GetByUserIdAsync(int userId);
        Task AddAsync(PersonalDataEntity entity);
        Task UpdateAsync(PersonalDataEntity entity);
        Task DeleteAsync(int userId);
        Task<bool> ExistsAsync(int userId);
    }
}
