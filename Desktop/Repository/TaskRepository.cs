using Desktop.TaskFolder;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desktop.Repository
{
    public class TaskRepository
    {
        public delegate void TaskItemsChangedDel();
        public event TaskItemsChangedDel? TaskItemsChanged;

        private static List<TaskDictionary> taskItems = new List<TaskDictionary>();
        private static readonly TaskRepository tasksRepos = new TaskRepository();

        public static TaskRepository GetTaskRepository() => tasksRepos;

        public List<TaskDictionary> GetTaskReposes() => taskItems;

        public static void AddTaskDictionary(TaskDictionary dict)
        {
            taskItems.Add(dict);
            RefreshTaskItems();
        }

        public static void RemoveTaskDictionary(TaskDictionary dict)
        {
            taskItems.Remove(dict);
            RefreshTaskItems();
        }

        public TaskDictionary? GetTaskRepos(int id) => taskItems.FirstOrDefault(x => x.Id == id);

        public static void RefreshTaskItems()
        {
            tasksRepos.TaskItemsChanged?.Invoke();
        }
    }
}
