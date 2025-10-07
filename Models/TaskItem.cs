namespace TasksApi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }  // Unique identifier
        public string Title { get; set; } = string.Empty;  // Task title
        public string? Description { get; set; }  // Optional details
        public bool IsCompleted { get; set; } = false;  // Status flag
    }
}
