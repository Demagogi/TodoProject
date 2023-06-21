using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoProject.DataAccess.Data;
using TodoProject.Domain.Models;
using ToDoProject.Domain.Interfaces;

namespace ToDoProject.DataAccess.Repository
{
    public class ToDoListItemsRepository : Repository<ToDoListItems>, IToDoListItemsRepository
    {
        private readonly ApplicationDbContext _db;
        public ToDoListItemsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ToDoListItems obj)
        {
            _db.ToDoListItems.Update(obj);
        }
    }
}
