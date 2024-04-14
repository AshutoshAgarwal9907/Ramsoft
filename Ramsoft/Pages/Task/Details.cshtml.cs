using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ramsoft.Models;
using Ramsoft.Services;

namespace Ramsoft.Pages.Task
{
    public class DetailsModel : PageModel
    {
        private readonly ITaskRepository _taskRepository;
        public DetailsModel(ITaskRepository taskRepository) {
            _taskRepository = taskRepository;
        }

        public TaskModel TaskDetails { get; private set; }
        public IActionResult OnGet(int Id)
        {
            TaskDetails = _taskRepository.GetTaskById(Id);

            if(TaskDetails == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();

        }
    }
}
