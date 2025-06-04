using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users {get; set;}
        public DbSet<Project> Projects {get; set;}
        public DbSet<TaskItem> TaskItems {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relacja 1:N User -> Projects
            modelBuilder.Entity<Project>().HasOne(project => project.Owner).WithMany(user => user.Projects).HasForeignKey(project => project.OwnerId).OnDelete(DeleteBehavior.Restrict);
            //Relacja 1:N Project -> TaskItem
            modelBuilder.Entity<TaskItem>().HasOne(taskitem => taskitem.Project).WithMany(project => project.Tasks).HasForeignKey(taskitem => taskitem.ProjectId);
            //Relacja  TaskItem -> User, jeżeli istnieje Assignee do zadania.
            modelBuilder.Entity<TaskItem>().HasOne(taskitem => taskitem.Assignee).WithMany(user => user.AssignedTasks).HasForeignKey(taskitem => taskitem.AssigneeId).OnDelete(DeleteBehavior.SetNull);
        }

    }
}
