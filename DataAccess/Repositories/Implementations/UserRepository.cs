using MedicineCareBridge.DataAccess.Entities;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        public readonly MedicineCareBridgeDbContext _context;

        public UserRepository(MedicineCareBridgeDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> GetByIdAsync(int id)
        {
            return await _context.Users
                .AsNoTracking()
                .Include(u => u.PersonalData)
                .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                .Include(u => u.UserDocumentTypes).ThenInclude(ud => ud.DocumentType)
                .Include(u => u.Passport)
                .Include(u => u.Snils)
                .Include(u => u.InsuranceDocument)
                .Include(u => u.UniversalDocuments)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<UserEntity>> GetAllAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public Task AddAsync(UserEntity user)
        {
            _context.Users.Add(user);
            return _context.SaveChangesAsync();
        }

        public Task UpdateAsync(UserEntity user)
        {
            _context.Update(user);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Users
                .AsNoTracking()
                .AnyAsync(u => u.Id == id);
        }

        public async Task<UserEntity?> GetByLoginAsync(string login)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u =>u.Login == login);
        }

        public async Task<List<UserEntity>> GetPagedAsync(int page, int pageSize)
        {
            if (page < 1)
            {
                page = 1;
            }
            return await _context.Users
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task AssignRoleAsync(int userId, int roleId)
        {
            if (!await ExistsAsync(userId))
                throw new KeyNotFoundException($"User {userId} not found");

            var link = new UserRoleEntity { UserId = userId, RoleId = roleId };
            _context.UserRoles.Add(link);
            await _context.SaveChangesAsync();
        }

        public async Task ReplaceRolesAsync(int userId, IEnumerable<int> roleIds)
        {
            var old = _context.UserRoles.Where(ur => ur.UserId == userId);
            _context.UserRoles.RemoveRange(old);

            var links = roleIds.Select(rid => new UserRoleEntity { UserId = userId, RoleId = rid });
            await _context.UserRoles.AddRangeAsync(links);

            await _context.SaveChangesAsync();
        }
    }
}
