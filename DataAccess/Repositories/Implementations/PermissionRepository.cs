using MedicineCareBridge.DataAccess.Entities;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Repositories.Implementations
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly MedicineCareBridgeDbContext _context;
        public PermissionRepository(MedicineCareBridgeDbContext context)
        {
            _context = context;
        }

        public async Task<PermissionEntity?> GetByIdAsync(int id)
        {
            return await _context.Permissions
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<PermissionEntity>> GetAllAsync()
        {
            return await _context.Permissions
                .AsNoTracking()
                .ToListAsync();
        }

        public Task AddAsync(PermissionEntity entity)
        {
            _context.Permissions.AddAsync(entity);
            return _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PermissionEntity entity)
        {
            _context.Permissions.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var e = await _context.Permissions.FindAsync(id);
            if (e != null)
            {
                _context.Permissions.Remove(e);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Permissions
                .AsNoTracking()
                .AnyAsync(p => p.Id == id);
        }

        public async Task<PermissionEntity?> GetByTextAsync(string text)
        {
            return await _context.Permissions
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Text == text);
        }
    }
}
