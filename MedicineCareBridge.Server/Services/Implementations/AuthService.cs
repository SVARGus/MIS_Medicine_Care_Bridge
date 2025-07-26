using MedicineCareBridge.Server.Services.Interfaces;
using MedicineCareBridge.Shared.DTO.Auth;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using MedicineCareBridge.Domain.Entities;
using AutoMapper;
using MedicineCareBridge.Server.Configuration; // класс с настройками JWT
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace MedicineCareBridge.Server.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IPersonalDataRepository _pdRepo;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwt;

        public AuthService(
            IUserRepository userRepo,
            IPersonalDataRepository pdRepo,
            IMapper mapper,
            JwtSettings jwt)
        {
            _userRepo = userRepo;
            _pdRepo = pdRepo;
            _mapper = mapper;
            _jwt = jwt;
        }

        public async Task<LoginResponseDto> AuthenticateAsync(LoginRequestDto dto)
        {
            var user = await _userRepo.GetByLoginAsync(dto.Login)
                        ?? throw new UnauthorizedAccessException("Неверный логин или пароль");

            // упрощенная проверка пароля
            if (user.Password != dto.Password)
                throw new UnauthorizedAccessException("Неверный логин или пароль");

            // создаем JWT
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Login)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(_jwt.LifetimeMinutes);

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds);

            return new LoginResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresAt = expires
            };
        }

        public async Task RegisterAsync(RegisterRequestDto dto)
        {
            // создаем доменный User
            var userDomain = _mapper.Map<User>(dto);
            // сохраняем в БД
            var userEntity = _mapper.Map<DataAccess.Entities.UserEntity>(userDomain);
            await _userRepo.AddAsync(userEntity);

            // сразу личные данные
            var pdEntity = _mapper.Map<DataAccess.Entities.PersonalDataEntity>(dto);
            pdEntity.UserId = userEntity.Id;
            await _pdRepo.AddAsync(pdEntity);
        }
    }
}
