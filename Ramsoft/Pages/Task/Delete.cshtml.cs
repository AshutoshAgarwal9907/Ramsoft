using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ramsoft.Models;
using Ramsoft.Services;

namespace Ramsoft.Pages.Task
{
    public class DeleteModel : PageModel
    {
        private readonly ITaskRepository _taskRepository;
        public DeleteModel(ITaskRepository taskRepository) {
            _taskRepository = taskRepository;
        }
        [BindProperty]
        public TaskModel Task { get; set; }
        public IActionResult OnGet(int id)
        {
            Task = _taskRepository.GetTaskById(id);
            if(Task == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            TaskModel deletedTask = _taskRepository.DeleteTask(id);
            if(deletedTask == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("Index");
        }
    }
}
