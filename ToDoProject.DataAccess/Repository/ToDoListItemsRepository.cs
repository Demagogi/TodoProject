using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoProject.DataAccess.Repository.IRepository;
using TodoProject.Models.Models;
using TodoProject.DataAccess.Data;

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
