using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Repository
{
    public class UserRepository
    {
        private static List<UserModel> userModels = new List<UserModel>
        {
            new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "root",
                Email = "root@mail.ru",
                Password = "rootpassword1"
            }
        };
    }
}
