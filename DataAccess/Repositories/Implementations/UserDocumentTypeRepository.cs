using MedicineCareBridge.DataAccess.Entities;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Repositories.Implementations
{
    public class UserDocumentTypeRepository : IUserDocumentTypeRepository
    {
        private readonly MedicineCareBridgeDbContext _context;
        public UserDocumentTypeRepository(MedicineCareBridgeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDocumentTypeEntity>> GetAllAsync()
        {
            return await _context.UserDocumentTypes
                .AsNoTracking()
                .Include(udt => udt.DocumentType)
                .ToListAsync();
        }

        public async Task<UserDocumentTypeEntity?> GetAsync(int userId, int documentTypeId)
        {
            return await _context.UserDocumentTypes
                .AsNoTracking()
                .Include(udt => udt.DocumentType)
                .FirstOrDefaultAsync(udt =>
                    udt.UserId == userId && udt.DocumentTypeId == documentTypeId);
        }

        public Task AddAsync(UserDocumentTypeEntity entity)
        {
            _context.UserDocumentTypes.AddAsync(entity);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId, int documentTypeId)
        {
            var e = await _context.UserDocumentTypes.FindAsync(userId, documentTypeId);
            if (e != null)
            {
                _context.UserDocumentTypes.Remove(e);
                await _context.SaveChangesAsync();
            }
        }
    }
}
