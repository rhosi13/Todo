using Desktop.TaskFolder;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Desktop.Repository
{
    public class TaskRepository
    {
        public delegate void TaskItemsChangedDel();
        public event TaskItemsChangedDel? TaskItemsChanged;

        private static List<TaskDictionary> taskItems = new List<TaskDictionary>();
        private static readonly string filePath = "tasks.json";

        private static TaskRepository tasksRepos = new TaskRepository();
        public static TaskRepository GetTaskRepository() => tasksRepos;

        static TaskRepository()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                taskItems = JsonConvert.DeserializeObject<List<TaskDictionary>>(json);
            }
        }

        public List<TaskDictionary> GetTaskReposes() => taskItems;

        public static void AddTaskDictionary(TaskDictionary dict)
        {
            taskItems.Add(dict);
            SaveTasks();
            tasksRepos.RefreshTaskItems();
        }

        public static void RemoveTaskDictionary(TaskDictionary dict)
        {
            taskItems.Remove(dict);
            SaveTasks();
            tasksRepos.RefreshTaskItems();
        }

        public TaskDictionary? GetTaskRepos(int id) => taskItems.FirstOrDefault(x => x.Id == id);

        public static void SaveTasks()
        {
            var json = JsonConvert.SerializeObject(taskItems, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void RefreshTaskItems()
        {
            TaskItemsChanged?.Invoke();
        }
    }
}
