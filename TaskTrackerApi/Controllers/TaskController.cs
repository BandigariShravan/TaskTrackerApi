using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskTrackerApi.DTOs;
using TaskTrackerApi.Services;

namespace TaskTrackerApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        private int GetUserId() => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetAll([FromQuery] TaskQueryParams query)
        {
            var tasks = await _taskService.GetAllAsync(GetUserId(), query);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDto>> GetById([FromRoute] int id)
        {
            var task = await _taskService.GetByIdAsync(id, GetUserId());
            return task == null ? NotFound() : Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskItemDto>> Create([FromBody] CreateTaskItemRequest dto)
        {
            var task = await _taskService.CreateAsync(dto, GetUserId());
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskItemDto>> Update([FromRoute] int id, [FromBody] UpdateTaskItemRequest dto)
        {
            var task = await _taskService.UpdateAsync(id, dto, GetUserId());
            return task == null ? NotFound() : Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _taskService.DeleteAsync(id, GetUserId());
            return deleted ? NoContent() : NotFound();
        }
    }
}