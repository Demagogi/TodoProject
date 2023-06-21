using TodoProject.Application.ViewModels;

namespace ToDoProject.Application.Services
{
    public interface IToDoListItemApplicationService
    {
        List<ToDoListItemViewModel> GetItemsToView();
        ToDoListItemViewModel GetItemToView(int id);
        void AddItemView(ToDoListItemViewModel item);
        void RemoveItemView(ToDoListItemViewModel item);
        void UpdateItemView(ToDoListItemViewModel item);
    }
}
