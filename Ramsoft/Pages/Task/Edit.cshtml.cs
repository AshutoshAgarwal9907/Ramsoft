using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ramsoft.Models;
using Ramsoft.Services;

namespace Ramsoft.Pages.Task
{
    public class EditModel : PageModel
    {
        private readonly ITaskRepository _taskRepository;
        public EditModel(ITaskRepository taskRepository) {
            _taskRepository = taskRepository;
        }
        [BindProperty]
        public TaskModel Task { get; set; }
        public IActionResult OnGet(int Id)
        {
            if (Id>0)
            { 
                Task = _taskRepository.GetTaskById(Id);
            }
            else
            {
                 Task = new TaskModel();
            }
            if(Task == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page(); 
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Task.TaskId > 0)
                {
                    TaskModel task = _taskRepository.UpdateTaskDetails(Task);
                }
                else
                {
                    _taskRepository.AddTask(Task);
                }
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
