using Microsoft.EntityFrameworkCore;
using TasksApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Register PostgreSQL DbContext
builder.Services.AddDbContext<TasksDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger in development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ----------------------
// CRUD Endpoints
// ----------------------

// Get all tasks
app.MapGet("/tasks", async (TasksDbContext db) =>
    await db.Tasks.ToListAsync());

// Get a single task by ID
app.MapGet("/tasks/{id}", async (int id, TasksDbContext db) =>
    await db.Tasks.FindAsync(id) is TasksApi.Models.TaskItem task ? Results.Ok(task) : Results.NotFound());

// Create a new task
app.MapPost("/tasks", async (TasksApi.Models.TaskItem task, TasksDbContext db) =>
{
    db.Tasks.Add(task);
    await db.SaveChangesAsync();
    return Results.Created($"/tasks/{task.Id}", task);
});

// Update an existing task
app.MapPut("/tasks/{id}", async (int id, TasksApi.Models.TaskItem updatedTask, TasksDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);
    if (task is null) return Results.NotFound();

    task.Title = updatedTask.Title;
    task.Description = updatedTask.Description;
    task.IsCompleted = updatedTask.IsCompleted;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Delete a task
app.MapDelete("/tasks/{id}", async (int id, TasksDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);
    if (task is null) return Results.NotFound();

    db.Tasks.Remove(task);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
