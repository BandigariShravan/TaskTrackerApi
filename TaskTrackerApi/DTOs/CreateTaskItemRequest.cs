using System.ComponentModel.DataAnnotations;
using TaskTrackerApi.Models;

namespace TaskTrackerApi.DTOs
{
    public class CreateTaskItemRequest
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Title { get; set; } = string.Empty;

        [StringLength(2000)]
        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        public DateTime? DueDate { get; set; }
    }
}
