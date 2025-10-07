using Microsoft.EntityFrameworkCore;
using TasksApi.Models; // Import the correct model namespace

namespace TasksApi.Data
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options) { }

        // Reference to the TaskItem model
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
