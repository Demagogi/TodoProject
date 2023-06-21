using TodoProject.Application.ViewModels;
using ToDoProject.Application.ViewModels;

namespace ToDoProject.Application.Services
{
    public interface IToDoListApplicationService
    {
        List<ToDoListViewModel> GetAllToDoViews();
        ToDoListViewModel GetToDoView(int id);
        void AddToDoView(CreateToDoListViewModel todoView);
        void RemoveToDoView(ToDoListViewModel todoView);
        void UpdateToDoView(ToDoListViewModel todoView);
    }
}
