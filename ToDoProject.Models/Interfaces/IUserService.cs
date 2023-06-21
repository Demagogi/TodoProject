using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Domain.Models;

namespace ToDoProject.Domain.Interfaces
{
    public interface IUserService
    {
        List<UserModel> GetAllUsers();
        UserModel GetUser();
        void UpdateUser(UserModel user);
        void AddUser(UserModel user);
        void RemoveUser(UserModel user);
    }
}
