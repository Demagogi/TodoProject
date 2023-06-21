using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoProject.DataAccess.Data;
using TodoProject.Domain.Models;
using ToDoProject.Domain.Interfaces;

namespace ToDoProject.DataAccess.Repository
{
    public class ToDoRepository : Repository<ToDoList>, IToDoRepository
    {
        private readonly ApplicationDbContext _db;
        public ToDoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ToDoList obj)
        {
            _db.ToDoList.Update(obj);
        }
    }
}
