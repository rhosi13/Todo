using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Desktop.Repository
{
    public class UserRepository
    {
        private static List<UserModel> userModels = new List<UserModel>
        {
            new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "admin",
                Email = "admin@mail.ru",
                Password = "adminpass"
            }
        };

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
            return true;
        }

        public static UserModel AuthorizeUser(string mail, string password)
        {
            var userModel = userModels.FirstOrDefault(use => (use.Email == mail && use.Password == password));

            return userModel;
        }
    }
}
