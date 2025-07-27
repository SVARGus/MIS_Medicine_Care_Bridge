using MedicineCareBridge.DataAccess.Entities;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Repositories.Implementations
{
    public class SnilsRepository : ISnilsRepository
    {
        private readonly MedicineCareBridgeDbContext _context;
        public SnilsRepository(MedicineCareBridgeDbContext context)
        {
            _context = context;
        }

        public async Task<SnilsEntity?> GetByNumAsync(string numSnils)
        {
            return await _context.Snils
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.NumSnils == numSnils);
        }

        public Task<SnilsEntity?> GetByUserIdAsync(int userId)
        => _context.Snils
                   .AsNoTracking()
                   .FirstOrDefaultAsync(x => x.UserId == userId);

        public async Task<List<SnilsEntity>> GetAllAsync()
        {
            return await _context.Snils
                .AsNoTracking()
                .ToListAsync();
        }

        public Task AddAsync(SnilsEntity entity)
        {
            _context.Snils.AddAsync(entity);
            return _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SnilsEntity entity)
        {
            _context.Snils.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string numSnils)
        {
            var e = await _context.Snils.FindAsync(numSnils);
            if (e != null)
            {
                _context.Snils.Remove(e);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(string numSnils)
        {
            return await _context.Snils
                .AsNoTracking()
                .AnyAsync(s => s.NumSnils == numSnils);
        }
    }
}
