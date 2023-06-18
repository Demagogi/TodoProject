using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Domain.Models;

namespace ToDoProject.Domain.Interfaces
{
    public interface IToDoRepository : IRepository<ToDoList>
    {
        void Update(ToDoList obj);
        void Save();
    }
}
