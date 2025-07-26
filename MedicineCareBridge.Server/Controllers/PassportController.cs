using AutoMapper;
using MedicineCareBridge.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MedicineCareBridge.Shared.DTO.Documents;

namespace MedicineCareBridge.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/users/{userId:int}/[controller]")]
    public class PassportController : ControllerBase
    {
        private readonly IPassportService _srv;
        private readonly IMapper _mapper;
        public PassportController(IPassportService srv, IMapper mapper)
        {
            _srv = srv;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PassportDto?>> Get(int userId)
        {
            var dto = await _srv.GetByUserIdAsync(userId);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<PassportDto>> CreateOrUpdate(int userId, [FromBody] PassportDto dto)
        {
            var saved = await _srv.CreateOrUpdateAsync(userId, dto);
            return Ok(saved);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int userId)
        {
            await _srv.DeleteAsync(userId);
            return NoContent();
        }
    }
}
