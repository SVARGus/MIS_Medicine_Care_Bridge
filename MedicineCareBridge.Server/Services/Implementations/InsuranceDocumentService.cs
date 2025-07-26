using MedicineCareBridge.Server.Services.Interfaces;
using MedicineCareBridge.Shared.DTO.Documents;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using AutoMapper;

namespace MedicineCareBridge.Server.Services.Implementations
{
    public class InsuranceDocumentService : IInsuranceDocumentService
    {
        private readonly IInsuranceDocumentRepository _repo;
        private readonly IMapper _mapper;

        public InsuranceDocumentService(IInsuranceDocumentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<InsuranceDocumentDto?> GetByUserIdAsync(int userId)
        {
            var e = await _repo.GetByIdAsync(userId);
            return e == null ? null : _mapper.Map<InsuranceDocumentDto>(e);
        }

        public async Task<InsuranceDocumentDto> CreateOrUpdateAsync(int userId, InsuranceDocumentDto dto)
        {
            var exist = await _repo.ExistsAsync(userId);
            var en = _mapper.Map<DataAccess.Entities.InsuranceDocumentEntity>(dto);
            en.UserId = userId;
            if (exist) await _repo.UpdateAsync(en);
            else await _repo.AddAsync(en);
            return dto;
        }

        public Task DeleteAsync(int userId)
            => _repo.DeleteAsync(userId);
    }
}