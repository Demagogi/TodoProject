using TodoProject.Application.ViewModels;
using ToDoProject.Application.Mappers;
using ToDoProject.Application.ViewModels;
using ToDoProject.Domain.Interfaces;

namespace ToDoProject.Application.Services
{
    public class ToDoListApplicationService : IToDoListApplicationService
    {
        private readonly IToDoListService _service;
        public ToDoListApplicationService(IToDoListService service)
        {
            _service = service;
        }

        public void AddToDoView(CreateToDoListViewModel todoView)
        {
            var todoModel = ToDoListMapper.MapCreateListViewModelToListModel(todoView);
            _service.AddToDo(todoModel);
        }

        public List<ToDoListViewModel> GetAllToDoViews()
        {
            var todos = _service.GetAllToDos();
            var todoViewModels = todos.Select(todo => ToDoListMapper.MapToToDoListModelToToDoListViewModel(todo)).ToList();

            return todoViewModels;
        }

        public ToDoListViewModel GetToDoView(int id)
        {
            var listView = _service.GetToDo(id);
            return ToDoListMapper.MapToToDoListModelToToDoListViewModel(listView);
        }

        public void RemoveToDoView(ToDoListViewModel todoView)
        {
            _service.RemoveToDo(ToDoListMapper.MapToDoListViewModelToToDoListModel(todoView));
        }

        public void UpdateToDoView(ToDoListViewModel todoView)
        {
            _service.UpdateToDo(ToDoListMapper.MapToDoListViewModelToToDoListModel(todoView));
        }
    }
}
