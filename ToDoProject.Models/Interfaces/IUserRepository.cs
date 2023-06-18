using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Domain.Models;

namespace ToDoProject.Domain.Interfaces
{
    public interface IUserRepository : IRepository<UserModel>
    {
        void Update(UserModel obj);
        void Save();
        IQueryable<UserModel> Include();
    }
}
