using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Models.Models;

namespace ToDoProject.DataAccess.Repository.IRepository
{
    public interface IUserRepository : IRepository<UserModel>
    {
        void Update(UserModel obj);
        void Save();
        IQueryable<UserModel> Include();
    }
}
