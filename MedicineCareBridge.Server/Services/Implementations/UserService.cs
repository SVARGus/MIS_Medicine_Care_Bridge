using MedicineCareBridge.Server.Services.Interfaces;
using MedicineCareBridge.Shared.DTO.User;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using AutoMapper;
using MedicineCareBridge.Shared.DTO.Shared;

namespace MedicineCareBridge.Server.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<UserReadDto> GetByIdAsync(int id)
        {
            var entity = await _userRepo.GetByIdAsync(id)
                         ?? throw new KeyNotFoundException($"User {id} not found");
            return _mapper.Map<UserReadDto>(entity);
        }

        public async Task<PaginatedResult<UserReadDto>> GetAllAsync(int page, int pageSize)
        {
            var all = await _userRepo.GetAllAsync();
            var total = all.Count;
            var paged = all.Skip((page - 1) * pageSize).Take(pageSize);
            var dtos = paged.Select(u => _mapper.Map<UserReadDto>(u));
            return new PaginatedResult<UserReadDto>(dtos, total, page, pageSize);
        }

        public async Task<UserReadDto> CreateAsync(UserCreateDto dto)
        {
            var entity = _mapper.Map<DataAccess.Entities.UserEntity>(dto);
            // пароль и роли — в сервисе
            entity.Password = dto.Password; // TODO: хешировать
            await _userRepo.AddAsync(entity);

            // сразу привязать роль
            await _userRepo.AssignRoleAsync(entity.Id, dto.RoleId);
            var created = await _userRepo.GetByIdAsync(entity.Id)!;
            return _mapper.Map<UserReadDto>(created);
        }

        public async Task<UserReadDto> UpdateAsync(UserUpdateDto dto)
        {
            var existing = await _userRepo.GetByIdAsync(dto.Id)
                           ?? throw new KeyNotFoundException($"User {dto.Id} not found");

            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                existing.Password = dto.Password; // TODO: хешировать
            }

            if (dto.RoleIds != null)
            {
                await _userRepo.ReplaceRolesAsync(dto.Id, dto.RoleIds);
            }

            await _userRepo.UpdateAsync(existing);
            return _mapper.Map<UserReadDto>(existing);
        }

        public async Task DeleteAsync(int id)
        {
            if (!await _userRepo.ExistsAsync(id))
                throw new KeyNotFoundException($"User {id} not found");
            await _userRepo.DeleteAsync(id);
        }
    }
}