using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ramsoft.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        [Required]
        [DisplayName("Task Name")]
        public string? TaskName  { get; set; }
        public string? Description { get; set; }
        public TaskState? State { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsFavourite { get; set; }

        
    }
}