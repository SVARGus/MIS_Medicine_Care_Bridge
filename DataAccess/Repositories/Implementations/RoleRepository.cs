using MedicineCareBridge.DataAccess.Entities;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Repositories.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MedicineCareBridgeDbContext _context;
        public RoleRepository(MedicineCareBridgeDbContext context)
        {
            _context = context;
        }

        public async Task<RoleEntity?> GetByIdAsync(int id)
        {
            return await _context.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<RoleEntity>> GetAllAsync()
        {
            return await _context.Roles
                .AsNoTracking()
                .ToListAsync();
        }

        public Task AddAsync(RoleEntity entity)
        {
            _context.Roles.AddAsync(entity);
            return _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RoleEntity entity)
        {
            _context.Roles.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var e = await _context.Roles.FindAsync(id);
            if (e != null)
            {
                _context.Roles.Remove(e);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Roles
                .AsNoTracking()
                .AnyAsync(r => r.Id == id);
        }

        public async Task<RoleEntity?> GetByNameEngAsync(string nameEng)
        {
            return await _context.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.NameEng == nameEng);
        }
        public async Task<RoleEntity?> GetByNameRuAsync(string nameRu)
        {
            return await _context.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.NameRus == nameRu);
        }
    }
}
