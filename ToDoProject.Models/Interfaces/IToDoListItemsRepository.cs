using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Domain.Models;

namespace ToDoProject.Domain.Interfaces
{
    public interface IToDoListItemsRepository : IRepository<ToDoListItems>
    {
        void Update(ToDoListItems obj);
        void Save();
    }
}
