using Ramsoft.Models;
using Ramsoft.Services;

namespace Ramsoft.nUnitTest
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        private TaskRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new TaskRepository();
        }

        [Test]
        public void DeleteTask_ValidId_RemovesTask()
        {
            // Arrange
            int taskIdToDelete = 2; 
            int initialCount = _repository.GetAllTasks().Count();

            // Act
            TaskModel deletedTask = _repository.DeleteTask(taskIdToDelete);

            // Assert
            Assert.IsNotNull(deletedTask); 
            Assert.AreEqual(taskIdToDelete, deletedTask.TaskId); 

          
            Assert.AreEqual(initialCount - 1, _repository.GetAllTasks().Count());
            Assert.IsNull(_repository.GetTaskById(taskIdToDelete)); 
        }

        [Test]
        public void DeleteTask_InvalidId_ReturnsNull()
        {
            // Arrange
            int taskIdToDelete = 100; 

            // Act
            TaskModel deletedTask = _repository.DeleteTask(taskIdToDelete);

            // Assert
            Assert.IsNull(deletedTask); 
        }
        [Test]
        public void DeleteTask_ExistingId_RemovesTaskAndReturnsTaskModel()
        {
            // Arrange
            int taskIdToDelete = 2;
            int initialCount = _repository.GetAllTasks().Count(); 

            // Act
            TaskModel deletedTask = _repository.DeleteTask(taskIdToDelete);

            // Assert
            Assert.IsNotNull(deletedTask); 
            Assert.AreEqual(taskIdToDelete, deletedTask.TaskId);

            Assert.AreEqual(initialCount - 1, _repository.GetAllTasks().Count());
            Assert.IsNull(_repository.GetTaskById(taskIdToDelete)); 
        }
        [Test]
        public void AddTask_ValidTask_AddsTask()
        {
            // Arrange
            TaskModel newTask = new TaskModel
            {
                TaskName = "New Task",
                Description = "New Task Description",
                State = TaskState.ToDo,
                Deadline = DateTime.Now.AddDays(7)
            };
            int initialCount = _repository.GetAllTasks().Count();

            // Act
            _repository.AddTask(newTask);

            // Assert
            Assert.AreEqual(initialCount + 1, _repository.GetAllTasks().Count());
            Assert.IsNotNull(_repository.GetTaskById(newTask.TaskId)); 
        }

        [Test]
        public void UpdateTaskDetails_ExistingTask_UpdatesTask()
        {
            // Arrange
            TaskModel existingTask = _repository.GetTaskById(1);
            TaskModel updatedTask = new TaskModel
            {
                TaskId = existingTask.TaskId,
                TaskName = "Updated Task Name",
                Description = "Updated Description",
                State = TaskState.InProgress,
                Deadline = DateTime.Now.AddDays(14)
            };

            // Act
            _repository.UpdateTaskDetails(updatedTask);

            // Assert
            TaskModel retrievedTask = _repository.GetTaskById(existingTask.TaskId);
            Assert.AreEqual(updatedTask.TaskName, retrievedTask.TaskName); 
            Assert.AreEqual(updatedTask.Description, retrievedTask.Description);
            Assert.AreEqual(updatedTask.State, retrievedTask.State);
            Assert.AreEqual(updatedTask.Deadline, retrievedTask.Deadline);
        }

        [Test]
        public void GetTaskById_ExistingId_ReturnsTaskModel()
        {
            // Arrange
            int existingId = 1; 

            // Act
            TaskModel task = _repository.GetTaskById(existingId);

            // Assert
            Assert.AreEqual(existingId, task.TaskId); 
        }

        [Test]
        public void GetTaskById_NonExistingId_ReturnsNull()
        {
            // Arrange
            int nonExistingId = 100; 

            // Act
            TaskModel task = _repository.GetTaskById(nonExistingId);

            // Assert
            Assert.IsNull(task); 
        }
    }
}