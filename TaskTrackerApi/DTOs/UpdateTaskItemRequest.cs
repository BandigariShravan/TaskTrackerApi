namespace TaskTrackerApi.DTOs
{
    public class UpdateTaskItemRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
