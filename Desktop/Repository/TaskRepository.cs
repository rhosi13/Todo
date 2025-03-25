using Desktop.TaskFolder;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Repository
{
    public class TaskRepository
    {
        public delegate void TaskItemsChangedDel();
        public event TaskItemsChangedDel? TaskItemsChanged;

        private List<TaskDictionary> taskItems = new List<TaskDictionary> ();

        private static TaskRepository tasksRepos { get; set; } = new TaskRepository ();
        public static TaskRepository GetTaskRepository() { return tasksRepos; }


        public List<TaskDictionary> GetTaskReposes()
        {
            return taskItems;
        }

        public void AddTaskDictionary(TaskDictionary dict)
        {
            taskItems.Add(dict);
            RefreshTaskItems();
        }

        public void RemoveTaskDictionary(TaskDictionary dict)
        {
            taskItems.Remove(dict);
            RefreshTaskItems();
        }

        public TaskDictionary? GetTaskRepos(int id)
        {
            return taskItems.FirstOrDefault(x => x.Id == id);
        }

        public void RefreshTaskItems()
        {
            TaskItemsChanged?.Invoke();
        }
    }
}
