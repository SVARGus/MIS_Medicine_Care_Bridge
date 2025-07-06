using MedicineCareBridge.DataAccess.Entities;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Repositories.Implementations
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly MedicineCareBridgeDbContext _context;

        public DocumentTypeRepository(MedicineCareBridgeDbContext context)
        {
            _context = context;
        }

        public async Task<DocumentTypeEntity?> GetByIdAsync(int id)
        {
            return await _context.DocumentTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(dt => dt.Id == id);
        }

        public async Task<List<DocumentTypeEntity>> GetAllAsync()
        {
            return await _context.DocumentTypes
                .AsNoTracking()
                .ToListAsync();
        }

        public Task AddAsync(DocumentTypeEntity entity)
        {
            _context.DocumentTypes.AddAsync(entity);
            return _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DocumentTypeEntity entity)
        {
            await _context.DocumentTypes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.DocumentTypes.FindAsync(id);
            if (entity != null)
            {
                _context.DocumentTypes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.DocumentTypes
                .AsNoTracking()
                .AnyAsync(dt => dt.Id == id);
        }

        public async Task<DocumentTypeEntity?> GetByNameTypeAsync(string nameType)
        {
            return await _context.DocumentTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(dt => dt.NameType == nameType);
        }
        public async Task<List<DocumentTypeEntity>> GetPagedAsync(int page, int pageSize)
        {
            if (page < 1)
            {
                page = 1;
            }
            return await _context.DocumentTypes
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
