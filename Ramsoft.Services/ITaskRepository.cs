using Ramsoft.Models;

namespace Ramsoft.Services
{
    public interface ITaskRepository
    {
        IEnumerable<TaskModel> GetAllTasks();
        TaskModel GetTaskById(int Id);

        TaskModel UpdateTaskDetails(TaskModel updatedTask);

        void AddTask(TaskModel task);

        TaskModel DeleteTask(int id);
    }
}