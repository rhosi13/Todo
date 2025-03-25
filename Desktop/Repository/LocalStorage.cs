using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Entities;

namespace Desktop.Repository
{
    public static class LocalStorage
    {
        private static readonly string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TodoApp", "guestTasks.json");

        static LocalStorage()
        {
            var directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public static List<TaskDictionary> LoadTasks()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<TaskDictionary>>(json);
            }
            return new List<TaskDictionary>();
        }

        public static void SaveTasks(List<TaskDictionary> tasks)
        {
            var json = JsonSerializer.Serialize(tasks);
            File.WriteAllText(filePath, json);
        }

        public static void ClearTasks()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}