using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Domain.Models;
using ToDoProject.Domain.Interfaces;

namespace ToDoProject.Domain.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IToDoRepository _repository;

        public ToDoListService(IToDoRepository repository)
        {
            _repository = repository;
        }

        public void AddToDo(ToDoList todo)
        {
            _repository.Add(todo);
            _repository.Save();
        }

        public List<ToDoList> GetAllToDos()
        {
            var todos = _repository.GetAll();
            return todos.ToList();
        }

        public ToDoList GetToDo(Expression<Func<ToDoList, bool>> filter, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void RemoveToDo(ToDoList todo)
        {
            _repository.Delete(todo);
            _repository.Save();
        }

        public void UpdateToDo(ToDoList todo)
        {
            _repository.Update(todo);
            _repository.Save();
        }
    }
}
