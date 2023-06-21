using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Application.ViewModels;
using ToDoProject.Application.Mappers;
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

        public void AddToDoView(ToDoListViewModel todoView)
        {
            var todoModel = ToDoListMapper.MapToDoListViewModelToToDoListModel(todoView);
            _service.AddToDo(todoModel);
        }

        public List<ToDoListViewModel> GetAllToDoViews()
        {
            var todos = _service.GetAllToDos();
            var todoViewModels = todos.Select(todo => ToDoListMapper.MapToToDoListModelToToDoListViewModel(todo)).ToList();

            return todoViewModels;
        }

        public ToDoListViewModel GetToDoView(Expression<Func<ToDoListViewModel, bool>> filter, string includeProperties = null)
        {
            throw new NotImplementedException();
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
