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

        public ToDoListItems GetItem(int id) => _repository.Get(x => x.Id == id);

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
