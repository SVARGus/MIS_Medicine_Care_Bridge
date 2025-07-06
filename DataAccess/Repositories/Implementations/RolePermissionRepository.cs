using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicineCareBridge.DataAccess.Entities;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Repositories.Implementations
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly MedicineCareBridgeDbContext _context;
        public RolePermissionRepository(MedicineCareBridgeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RolePermissionEntity>> GetAllAsync()
        {
            return await _context.RolePermissions
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<RolePermissionEntity?> GetAsync(int roleId, int permissionId)
        {
            return await _context.RolePermissions
                .AsNoTracking()
                .FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);
        }

        public Task AddAsync(RolePermissionEntity entity)
        {
            _context.RolePermissions.AddAsync(entity);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int roleId, int permissionId)
        {
            var e = await _context.RolePermissions.FindAsync(roleId, permissionId);
            if (e != null)
            {
                _context.RolePermissions.Remove(e);
                await _context.SaveChangesAsync();
            }
        }
    }
}
