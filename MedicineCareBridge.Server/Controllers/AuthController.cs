using MedicineCareBridge.Server.Services.Interfaces;
using MedicineCareBridge.Shared.DTO.Auth;
using Microsoft.AspNetCore.Mvc;

namespace MedicineCareBridge.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth) => _auth = auth;

        /// <summary>Войти по логину и паролю, получить JWT.</summary>
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto dto)
        {
            var result = await _auth.AuthenticateAsync(dto);
            return Ok(result);
        }

        /// <summary>Зарегистрировать нового пользователя вместе с личными данными.</summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            await _auth.RegisterAsync(dto);
            return StatusCode(201);
        }
    }
}
