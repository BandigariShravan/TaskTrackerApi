using TaskTrackerApi.Models;

namespace TaskTrackerApi.DTOs
{
    public class TaskQueryParams
    {
        public bool? IsCompleted { get; set; }
        public TaskPriority? Priority { get; set; }
    }
}
