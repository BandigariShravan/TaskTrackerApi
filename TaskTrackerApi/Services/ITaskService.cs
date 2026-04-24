using TaskTrackerApi.DTOs;

namespace TaskTrackerApi.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItemDto>> GetAllAsync(int userId, TaskQueryParams query);
        Task<TaskItemDto?> GetByIdAsync(int id, int userId);
        Task<TaskItemDto> CreateAsync(CreateTaskItemRequest dto, int userId);
        Task<TaskItemDto?> UpdateAsync(int id, UpdateTaskItemRequest dto, int userId);
        Task<bool> DeleteAsync(int id, int userId);
    }
}
