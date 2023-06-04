using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoProject.DataAccess.Data;
using ToDoProject.DataAccess.Repository.IRepository;
using TodoProject.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoProject.DataAccess.Repository
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(UserModel obj)
        {
            _db.Users.Update(obj);
        }

        public IQueryable<UserModel> Include()
        {
            return _db.Users.Include(u => u.UserToDos);
        }
    }
}
