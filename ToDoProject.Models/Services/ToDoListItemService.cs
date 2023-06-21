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
    public class ToDoListItemService : IToDoListItemService
    {
        private readonly IToDoListItemsRepository _repository;

        public ToDoListItemService(IToDoListItemsRepository repository)
        {
            _repository = repository;
        }

        public void AddItem(ToDoListItems item)
        {
            _repository.Add(item);
            _repository.Save();
        }

        public List<ToDoListItems> GetAllItems()
        {
            var items = _repository.GetAll();
            return items.ToList();
        }

        public ToDoListItems GetItem(Expression<Func<ToDoListItems, bool>> filter, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(ToDoListItems item)
        {
            _repository.Delete(item);
            _repository.Save();
        }

        public void UpdateItem(ToDoListItems item)
        {
            _repository.Update(item);
            _repository.Save();
        }
    }
}
