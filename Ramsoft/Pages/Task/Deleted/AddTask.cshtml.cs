using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ramsoft.Models;
using Ramsoft.Services;

namespace Ramsoft.Pages.Task
{
    public class AddTaskModel : PageModel
    {
        private readonly ITaskRepository _taskRepository;
        public AddTaskModel(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public TaskModel Task { get; set; }
       
        public void OnGet()
        {
        }
        public IActionResult OnPost(TaskModel task)
        {
            _taskRepository.AddTask(task);
            return RedirectToPage("Index");
        }
    }
}
