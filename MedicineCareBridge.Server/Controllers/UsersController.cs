using AutoMapper;
using MedicineCareBridge.Server.Services.Interfaces;
using MedicineCareBridge.Shared.DTO.Shared;
using MedicineCareBridge.Shared.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicineCareBridge.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _srv;
        private readonly IMapper _mapper;
        public UsersController(IUserService srv, IMapper mapper)
        {
            _srv = srv;
            _mapper = mapper;
        }

        /// <summary>Постраничный список пользователей.</summary>
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<UserReadDto>>> GetAll(int page = 1, int pageSize = 20)
        {
            var result = await _srv.GetAllAsync(page, pageSize);
            return Ok(result);
        }

        /// <summary>Получить одного пользователя по ID.</summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserReadDto>> Get(int id)
        {
            var dto = await _srv.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        /// <summary>Создать пользователя (только логин/пароль/роль).</summary>
        [HttpPost]
        public async Task<ActionResult<UserReadDto>> Create([FromBody] UserCreateDto dto)
        {
            var created = await _srv.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        /// <summary>Обновить пароль и/или роли пользователя.</summary>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserReadDto>> Update(int id, [FromBody] UserUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var updated = await _srv.UpdateAsync(dto);
            return Ok(updated);
        }

        /// <summary>Удалить пользователя.</summary>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _srv.DeleteAsync(id);
            return NoContent();
        }
    }
}
