using TodoProject.Application.ViewModels;

namespace ToDoProject.Application.Services
{
    public interface IToDoListApplicationService
    {
        List<ToDoListViewModel> GetAllToDoViews();
        ToDoListViewModel GetToDoView(int id);
        void AddToDoView(ToDoListViewModel todoView);
        void RemoveToDoView(ToDoListViewModel todoView);
        void UpdateToDoView(ToDoListViewModel todoView);
    }
}
