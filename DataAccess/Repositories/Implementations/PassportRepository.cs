using MedicineCareBridge.DataAccess.Entities;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Repositories.Implementations
{
    public class PassportRepository : IPassportRepository
    {
        private readonly MedicineCareBridgeDbContext _context;
        public PassportRepository(MedicineCareBridgeDbContext context)
        {
            _context = context;
        }

        public async Task<PassportEntity?> GetByUserIdAsync(int userId)
        {
            return await _context.Passports
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.UserId == userId);
        }

        public async Task<List<PassportEntity>> GetAllAsync()
        {
            return await _context.Passports
                .AsNoTracking()
                .ToListAsync();
        }

        public Task AddAsync(PassportEntity entity)
        {
            _context.Passports.AddAsync(entity);
            return _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PassportEntity entity)
        {
            _context.Passports.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId)
        {
            var e = await _context.Passports.FindAsync(userId);
            if (e != null)
            {
                _context.Passports.Remove(e);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int userId)
        {
            return await _context.Passports
                .AsNoTracking()
                .AnyAsync(p => p.UserId == userId);
        }
    }
}
