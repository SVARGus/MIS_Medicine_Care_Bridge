using MedicineCareBridge.DataAccess.Entities;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Repositories.Implementations
{
    public class InsuranceDocumentRepository : IInsuranceDocumentRepository
    {
        private readonly MedicineCareBridgeDbContext _context;

        public InsuranceDocumentRepository(MedicineCareBridgeDbContext context)
        {
            _context = context;
        }

        public async Task<InsuranceDocumentEntity?> GetByIdAsync(int id)
        {
            return await _context.InsuranceDocuments
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.UserId == id);
        }

        public async Task<List<InsuranceDocumentEntity>> GetAllAsync()
        {
            return await _context.InsuranceDocuments
                .AsNoTracking()
                .ToListAsync();
        }

        public Task AddAsync(InsuranceDocumentEntity entity)
        {
            _context.InsuranceDocuments.Add(entity);
            return _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InsuranceDocumentEntity entity)
        {
            _context.InsuranceDocuments.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.InsuranceDocuments.FindAsync(id);
            if (entity != null)
            {
                _context.InsuranceDocuments.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.InsuranceDocuments
                .AsNoTracking()
                .AnyAsync(i => i.UserId == id);
        }

        public async Task<InsuranceDocumentEntity?> GetByNameTypeAsync(string num)
        {
            return await _context.InsuranceDocuments
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Num == num);
        }
    }
}
