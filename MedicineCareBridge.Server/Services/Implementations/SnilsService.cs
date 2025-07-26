using AutoMapper;
using MedicineCareBridge.DataAccess.Entities;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using MedicineCareBridge.Server.Services.Interfaces;
using MedicineCareBridge.Shared.DTO.Documents;

namespace MedicineCareBridge.Server.Services.Implementations
{
    public class SnilsService : ISnilsService
    {
        private readonly ISnilsRepository _repo;
        private readonly IMapper _mapper;

        public SnilsService(ISnilsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<SnilsDto?> GetByUserIdAsync(int userId)
        {
            var entity = await _repo.GetByUserIdAsync(userId);
            if (entity == null) return null;
            return _mapper.Map<SnilsDto>(entity);
        }

        public async Task<SnilsDto> CreateOrUpdateAsync(int userId, SnilsDto dto)
        {
            var existing = await _repo.GetByUserIdAsync(userId);

            var entity = _mapper.Map<SnilsEntity>(dto);
            entity.UserId = userId;

            if (existing != null)
            {
                entity.NumSnils = existing.NumSnils;
                await _repo.UpdateAsync(entity);
            }
            else
            {
                await _repo.AddAsync(entity);
            }

            return _mapper.Map<SnilsDto>(entity);
        }

        public async Task DeleteAsync(int userId)
        {
            var existing = await _repo.GetByUserIdAsync(userId);
            if (existing != null)
            {
                await _repo.DeleteAsync(existing.NumSnils);
            }
        }
    }
}