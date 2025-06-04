using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain.Entities
{
    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Done
    }

    public class TaskItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.ToDo;

        public Guid ProjectId { get; set; }
        public required Project Project { get; set; }

        public Guid? AssigneeId { get; set; }
        public User? Assignee { get; set; }
    }
}
