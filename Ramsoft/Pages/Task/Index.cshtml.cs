using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ramsoft.Models;
using Ramsoft.Services;

namespace Ramsoft.Pages.Task
{
    public class IndexModel : PageModel
    {
        private readonly ITaskRepository taskRepository;
        public IEnumerable<TaskModel> Tasks { get; set; }
        public IndexModel(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public void OnGet()
        {
            Tasks = taskRepository.GetAllTasks();
        }
    }
}
