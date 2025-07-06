using MedicineCareBridge.DataAccess.Entities;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Repositories.Implementations
{
    public class UserRoleRepository : IUserRoleRepository
    {
        public readonly MedicineCareBridgeDbContext _context;

        public UserRoleRepository(MedicineCareBridgeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserRoleEntity>> GetAllAsync()
        {
            return await _context.UserRoles
                .AsNoTracking()
                .Include(ur => ur.User)
                .Include(ur => ur.Role)
                .ToListAsync();
        }

        public async Task<UserRoleEntity?> GetAsync(int userId, int roleId)
        {
            return await _context.UserRoles
                .AsNoTracking()
                .Include(ur => ur.User)
                .Include(ur => ur.Role)
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
        }

        public  Task AddAsync(UserRoleEntity entity)
        {
            _context.UserRoles.AddAsync(entity);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId, int roleId)
        {
            var entity = await _context.UserRoles.FindAsync(userId, roleId);
            if (entity != null)
            {
                _context.UserRoles.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
