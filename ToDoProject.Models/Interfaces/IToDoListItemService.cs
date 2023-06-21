using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Domain.Models;

namespace ToDoProject.Domain.Interfaces
{
    public interface IToDoListItemService
    {
        List<ToDoListItems> GetAllItems();
        ToDoListItems GetItem(Expression<Func<ToDoListItems, bool>> filter, string includeProperties = null);

        void AddItem(ToDoListItems item);
        void RemoveItem(ToDoListItems item);
        void UpdateItem(ToDoListItems item);
    }
}
