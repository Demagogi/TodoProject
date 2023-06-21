using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Domain.Models;

namespace ToDoProject.Domain.Interfaces
{
    public interface IToDoListService
    {
        List<ToDoList> GetAllToDos();
        ToDoList GetToDo(int id);
        void AddToDo(ToDoList todo);
        void RemoveToDo(ToDoList todo);
        void UpdateToDo(ToDoList todo);
    }
}
