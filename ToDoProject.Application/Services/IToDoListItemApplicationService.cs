using TodoProject.Application.ViewModels;
using ToDoProject.Application.ViewModels;

namespace ToDoProject.Application.Services
{
    public interface IToDoListItemApplicationService
    {
        List<ToDoListItemViewModel> GetItemsToView();
        ToDoListItemViewModel GetItemToView(int id);
        void AddItemView(CreateToDoListItemViewModel item);
        void RemoveItemView(ToDoListItemViewModel item);
        void UpdateItemView(ToDoListItemViewModel item);
    }
}
