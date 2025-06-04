using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.Persistance;

namespace TaskManagementSystem.Infrastructure.Seeders
{
    public class TaskManagementSystemSeeder
    {
        private readonly AppDbContext _dbContext;

        public TaskManagementSystemSeeder(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Users.Any())
                {
                    var user = new Domain.Entities.User()
                    {
                        Username = "admin",
                        Email = "admin@example.com"
                    };

                    var project = new Domain.Entities.Project()
                    {
                        Name = "Start project",
                        Owner = user
                    };

                    var task = new Domain.Entities.TaskItem()
                    {
                        Title = "Test task",
                        Status = Domain.Entities.TaskStatus.ToDo,
                        Project = project,
                        Assignee = user
                    };

                    _dbContext.Users.Add(user);
                    _dbContext.Projects.Add(project);
                    _dbContext.TaskItems.Add(task);
                    await _dbContext.SaveChangesAsync();
                }

            }
        }
    }
}
