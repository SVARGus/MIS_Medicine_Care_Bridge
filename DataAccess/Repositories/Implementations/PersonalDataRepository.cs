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
    public class PersonalDataRepository : IPersonalDataRepository
    {
        private readonly MedicineCareBridgeDbContext _context;
        public PersonalDataRepository(MedicineCareBridgeDbContext context)
        {
            _context = context;
        }

        public async Task<PersonalDataEntity?> GetByUserIdAsync(int userId)
        {
            return await _context.PersonalData
                .AsNoTracking()
                .FirstOrDefaultAsync(pd => pd.UserId == userId);
        }

        public Task AddAsync(PersonalDataEntity entity)
        {
            _context.PersonalData.AddAsync(entity);
            return _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PersonalDataEntity entity)
        {
            _context.PersonalData.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId)
        {
            var e = await _context.PersonalData.FindAsync(userId);
            if (e != null)
            {
                _context.PersonalData.Remove(e);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int userId)
        {
            return await _context.PersonalData
                .AsNoTracking()
                .AnyAsync(pd => pd.UserId == userId);
        }
    }
}
