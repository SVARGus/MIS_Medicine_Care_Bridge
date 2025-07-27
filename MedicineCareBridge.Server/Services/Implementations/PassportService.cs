using MedicineCareBridge.Server.Services.Interfaces;
using MedicineCareBridge.Shared.DTO.Documents;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using AutoMapper;

namespace MedicineCareBridge.Server.Services.Implementations
{
    public class PassportService : IPassportService
    {
        private readonly IPassportRepository _repo;
        private readonly IMapper _mapper;

        public PassportService(IPassportRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<PassportDto?> GetByUserIdAsync(int userId)
        {
            var e = await _repo.GetByUserIdAsync(userId);
            return e == null ? null : _mapper.Map<PassportDto>(e);
        }

        public async Task<PassportDto> CreateOrUpdateAsync(int userId, PassportDto dto)
        {
            var exists = await _repo.ExistsAsync(userId);
            var entity = _mapper.Map<DataAccess.Entities.PassportEntity>(dto);
            entity.UserId = userId;
            if (exists)
                await _repo.UpdateAsync(entity);
            else
                await _repo.AddAsync(entity);
            return dto;
        }

        public Task DeleteAsync(int userId)
            => _repo.DeleteAsync(userId);
    }
}