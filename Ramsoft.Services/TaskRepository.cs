﻿using Ramsoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramsoft.Services
{
    public class TaskRepository : ITaskRepository
    {
        private List<TaskModel> _tasksList;

        public TaskRepository()
        {
            _tasksList = new List<TaskModel>()
            {
                new TaskModel (){TaskId=1,TaskName="Task12",Description="Description",State=TaskState.InProgress, Deadline=DateTime.Now},
                new TaskModel (){TaskId=2,TaskName="Task13",Description="Description",State=TaskState.InProgress, Deadline=DateTime.Now},
                new TaskModel (){TaskId=3,TaskName="Task14",Description="Description",State=TaskState.InProgress, Deadline=DateTime.Now}
            };
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            return _tasksList;
        }

        public TaskModel GetTaskById(int Id)
        {
           return _tasksList.FirstOrDefault(e=>e.TaskId==Id);
        }

        public TaskModel UpdateTaskDetails(TaskModel updatedTask)
        {
            TaskModel task = _tasksList.FirstOrDefault(e=>e.TaskId == updatedTask.TaskId);

            if(task != null)
            {
                task.TaskName = updatedTask.TaskName;
                task.Description = updatedTask.Description;
                task.State = updatedTask.State;
                task.Deadline = updatedTask.Deadline;
            }
            return task;
        }
        public void AddTask(TaskModel newTask)
        {
            if(newTask.TaskName != null)
            {
                //newTask.TaskId = _tasksList.Max().TaskId+1;
                newTask.TaskId  = _tasksList.Max(e=>e.TaskId)+1;

                _tasksList.Add(newTask);
            }       
          
        }
    }
}
