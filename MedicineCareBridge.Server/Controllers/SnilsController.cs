using MedicineCareBridge.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MedicineCareBridge.Shared.DTO.Documents;

namespace MedicineCareBridge.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/users/{userId:int}/[controller]")]
    public class SnilsController : ControllerBase
    {
        private readonly ISnilsService _srv;
        public SnilsController(ISnilsService srv) => _srv = srv;

        [HttpGet]
        public async Task<ActionResult<SnilsDto?>> Get(int userId)
        {
            var dto = await _srv.GetByUserIdAsync(userId);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<SnilsDto>> CreateOrUpdate(int userId, [FromBody] SnilsDto dto)
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
