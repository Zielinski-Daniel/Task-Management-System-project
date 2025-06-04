using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        public Guid OwnerId { get; set; }
        public required User Owner { get; set; }


        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
