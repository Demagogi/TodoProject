using TodoProject.Application.ViewModels;
using TodoProject.Domain.Models;
using ToDoProject.Application.ViewModels;

namespace ToDoProject.Application.Mappers
{
    public static class ToDoListItemMapper
    {
        public static ToDoListItems MapCreateItemViewModelToItemModel(CreateToDoListItemViewModel model)
        {
            var itemModel = new ToDoListItems();

            itemModel.Title = model.Title;
            itemModel.Description = model.Description;
            itemModel.ToDoListId = model.ToDoListId;

            itemModel.Condition = (TodoProject.Domain.Models.TaskItemCondition)model.Condition;

            return itemModel;
        }

        public static ToDoListItemViewModel MapItemsModelToItemsViewModel(ToDoListItems item)
        {
            var itemViewModel = new ToDoListItemViewModel();

            itemViewModel.Id= item.Id;
            itemViewModel.Title = item.Title;
            itemViewModel.Description = item.Description;
            itemViewModel.ToDoListId = item.ToDoListId;

            itemViewModel.Condition = (TodoProject.Application.ViewModels.TaskItemCondition)item.Condition;

            return itemViewModel;
        }

        public static ToDoListItems MapItemsViewModelToItemsModel(ToDoListItemViewModel item)
        {
            var itemModel = new ToDoListItems();

            itemModel.Id = item.Id;
            itemModel.Title = item.Title;
            itemModel.Description = item.Description;
            itemModel.ToDoListId = item.ToDoListId;

            itemModel.Condition = (TodoProject.Domain.Models.TaskItemCondition)item.Condition;

            return itemModel;

        }
    }
}
