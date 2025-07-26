using MedicineCareBridge.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MedicineCareBridge.Shared.DTO.Documents;

namespace MedicineCareBridge.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/users/{userId:int}/[controller]")]
    public class UniversalDocumentsController : ControllerBase
    {
        private readonly IUniversalDocumentService _srv;
        public UniversalDocumentsController(IUniversalDocumentService srv) => _srv = srv;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UniversalDocumentDto>>> GetAll(int userId)
        {
            var list = await _srv.GetByUserIdAsync(userId);
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult<UniversalDocumentDto>> Add(int userId, [FromBody] UniversalDocumentDto dto)
        {
            var added = await _srv.AddAsync(userId, dto);
            return CreatedAtAction(nameof(Update), new { userId, documentId = added.Id }, added);
        }

        [HttpPut]
        public async Task<ActionResult<UniversalDocumentDto>> Update(int userId, [FromBody] UniversalDocumentDto dto)
        {
            var updated = await _srv.UpdateAsync(userId, dto);
            return Ok(updated);
        }

        [HttpDelete("{documentId:int}")]
        public async Task<IActionResult> Delete(int userId, int documentId)
        {
            await _srv.DeleteAsync(userId, documentId);
            return NoContent();
        }
    }
}
