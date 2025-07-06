using MedicineCareBridge.DataAccess.Entities;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Repositories.Implementations
{
    public class UniversalDocumentRepository : IUniversalDocumentRepository
    {
        private readonly MedicineCareBridgeDbContext _context;
        public UniversalDocumentRepository(MedicineCareBridgeDbContext context)
        {
            _context = context;
        }

        public async Task<UniversalDocumentEntity?> GetByIdAsync(int id)
        {
            return await _context.UniversalDocuments
                .AsNoTracking()
                .FirstOrDefaultAsync(ud => ud.Id == id);
        }

        public async Task<List<UniversalDocumentEntity>> GetAllAsync()
        {
            return await _context.UniversalDocuments
                .AsNoTracking()
                .ToListAsync();
        }

        public Task AddAsync(UniversalDocumentEntity entity)
        {
            _context.UniversalDocuments.AddAsync(entity);
            return _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UniversalDocumentEntity entity)
        {
            _context.UniversalDocuments.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var e = await _context.UniversalDocuments.FindAsync(id);
            if (e != null)
            {
                _context.UniversalDocuments.Remove(e);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.UniversalDocuments
                .AsNoTracking()
                .AnyAsync(ud => ud.Id == id);
        }

        public async Task<List<UniversalDocumentEntity>> GetByUserIdAsync(int userId)
        {
            return await _context.UniversalDocuments
                .AsNoTracking()
                .Where(ud => ud.UserId == userId)
                .ToListAsync();
        }
    }
}
