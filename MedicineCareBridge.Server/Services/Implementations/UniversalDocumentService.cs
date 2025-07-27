using MedicineCareBridge.Server.Services.Interfaces;
using MedicineCareBridge.Shared.DTO.Documents;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using AutoMapper;

namespace MedicineCareBridge.Server.Services.Implementations
{
    public class UniversalDocumentService : IUniversalDocumentService
    {
        private readonly IUniversalDocumentRepository _repo;
        private readonly IMapper _mapper;

        public UniversalDocumentService(IUniversalDocumentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UniversalDocumentDto>> GetByUserIdAsync(int userId)
        {
            var list = await _repo.GetByUserIdAsync(userId);
            return list.Select(e => _mapper.Map<UniversalDocumentDto>(e));
        }

        public async Task<UniversalDocumentDto> AddAsync(int userId, UniversalDocumentDto dto)
        {
            var en = _mapper.Map<DataAccess.Entities.UniversalDocumentEntity>(dto);
            en.UserId = userId;
            await _repo.AddAsync(en);
            var created = en;
            return _mapper.Map<UniversalDocumentDto>(created);
        }

        public async Task<UniversalDocumentDto> UpdateAsync(int userId, UniversalDocumentDto dto)
        {
            var en = _mapper.Map<DataAccess.Entities.UniversalDocumentEntity>(dto);
            en.UserId = userId;
            await _repo.UpdateAsync(en);
            return dto;
        }

        public async Task DeleteAsync(int userId, int documentId)
        {
            var entity = await _repo.GetByIdAsync(documentId)
                         ?? throw new KeyNotFoundException($"Документ с Id={documentId} не найден.");

            if (entity.UserId != userId)
                throw new UnauthorizedAccessException("Нельзя удалять документ другого пользователя.");

            await _repo.DeleteAsync(documentId);
        }
    }
}