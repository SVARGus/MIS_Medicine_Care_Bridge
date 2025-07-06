using MedicineCareBridge.DataAccess.Entities;

namespace MedicineCareBridge.DataAccess.Repositories.Interfaces
{
    public interface IUserDocumentTypeRepository
    {
        Task<IEnumerable<UserDocumentTypeEntity>> GetAllAsync();
        Task<UserDocumentTypeEntity?> GetAsync(int userId, int documentTypeId);
        Task AddAsync(UserDocumentTypeEntity entity);
        Task DeleteAsync(int userId, int documentTypeId);
    }
}
