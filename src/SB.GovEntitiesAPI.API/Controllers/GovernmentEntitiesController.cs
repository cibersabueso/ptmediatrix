using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SB.GovEntitiesAPI.Application.DTOs;
using SB.GovEntitiesAPI.Application.Interfaces;

namespace SB.GovEntitiesAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GovernmentEntitiesController : ControllerBase
    {
        private readonly IGovernmentEntityService _entityService;
        private readonly ILogger<GovernmentEntitiesController> _logger;

        public GovernmentEntitiesController(IGovernmentEntityService entityService, ILogger<GovernmentEntitiesController> logger)
        {
            _entityService = entityService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GovernmentEntityDto>>> GetAll()
        {
            try
            {
                var entities = await _entityService.GetAllAsync();
                return Ok(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all entities");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GovernmentEntityDto>> GetById(int id)
        {
            try
            {
                var entity = await _entityService.GetByIdAsync(id);
                return Ok(entity);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting entity with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(GovernmentEntityDto entityDto)
        {
            try
            {
                var id = await _entityService.CreateAsync(entityDto);
                return CreatedAtAction(nameof(GetById), new { id }, id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating entity");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GovernmentEntityDto entityDto)
        {
            try
            {
                await _entityService.UpdateAsync(id, entityDto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating entity with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _entityService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting entity with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}