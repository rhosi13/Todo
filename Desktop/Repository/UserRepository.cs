using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Desktop.Repository
{
    public class UserRepository
    {
        private static List<UserModel> userModels;
        private static readonly string filePath = "users.json";

        static UserRepository()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                userModels = JsonConvert.DeserializeObject<List<UserModel>>(json);
            }
            else
            {
                userModels = new List<UserModel>
                {
                    new UserModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "admin",
                        Email = "admin@mail.ru",
                        Password = "adminpass"
                    }
                };
            }
        }

        public static bool RegisterUser(string name, string mail, string password)
        {
            if (userModels.Any(use => use.Name == name || use.Email == mail))
            {
                return false;
            }

            var newUserModel = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = mail,
                Password = password
            };

            userModels.Add(newUserModel);
            SaveUsers();
            return true;
        }

        public static UserModel? AuthorizeUser(string mail, string password) =>
            userModels.FirstOrDefault(use => use.Email == mail && use.Password == password);

        public static UserModel? GetUserByName(string name) =>
            userModels.FirstOrDefault(user => user.Name == name);

        public static void SaveUserTasks(UserModel user)
        {
            var userFilePath = $"{user.Name}_tasks.json";
            var json = JsonConvert.SerializeObject(user.Tasks, Formatting.Indented);
            File.WriteAllText(userFilePath, json);
        }

        public static List<TaskDictionary> LoadUserTasks(string userName)
        {
            var userFilePath = $"{userName}_tasks.json";
            if (File.Exists(userFilePath))
            {
                var json = File.ReadAllText(userFilePath);
                return JsonConvert.DeserializeObject<List<TaskDictionary>>(json);
            }
            return new List<TaskDictionary>();
        }

        private static void SaveUsers()
        {
            var json = JsonConvert.SerializeObject(userModels, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
