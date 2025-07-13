using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskTrackerApi.Data;
using TaskTrackerApi.DTOs;
using TaskTrackerApi.Models;

namespace TaskTrackerApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        private int GetUserId() => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        [HttpGet]
        public async Task<ActionResult<List<CreateTaskItemResponse>>> GetAll()
        {
            var userId = GetUserId();
            var tasks = await _context.Tasks.Include(a => a.User).Where(t => t.UserId == userId).ToListAsync();
            var responseList = new List<CreateTaskItemResponse>();
            foreach (var task in tasks)
            {
                var response = new CreateTaskItemResponse
                {
                    Id=task.Id,
                    Title=task.Title,
                    Description=task.Description,
                    IsCompleted=task.IsCompleted,
                    UserId=task.UserId,
                    UserName=task.User.Username
                };
                responseList.Add(response);
            }
            return Ok(responseList);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTaskItemRequest dto)
        {
            var userId = GetUserId();
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = dto.IsCompleted,
                UserId = userId
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateTaskItemRequest updated)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null || task.UserId != GetUserId()) return NotFound();

            task.Title = updated.Title;
            task.Description = updated.Description;
            task.IsCompleted = updated.IsCompleted;
            await _context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null || task.UserId != GetUserId()) return NotFound();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}