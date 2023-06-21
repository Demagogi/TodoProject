using TodoProject.Application.ViewModels;
using TodoProject.Domain.Models;
using ToDoProject.Application.ViewModels;

namespace ToDoProject.Application.Mappers
{
    public static class ToDoListMapper
    {
        public static ToDoList MapCreateListViewModelToListModel(CreateToDoListViewModel model)
        {
            var todoList = new ToDoList();

            todoList.Name = model.Name;
            todoList.UserModelId = model.UserModelId;
            todoList.Description = model.Description;
            todoList.Items = new List<ToDoListItems>();

            foreach (var item in model.Items)
            {
                var itemModel = ToDoListItemMapper.MapItemsViewModelToItemsModel(item);
                todoList.Items.Add(itemModel);
            }

            return todoList;
        }
        public static ToDoList MapToDoListViewModelToToDoListModel(ToDoListViewModel viewModel)
        {
            var todoList = new ToDoList();

            todoList.Id = viewModel.Id;
            todoList.Name = viewModel.Name;
            todoList.UserModelId = viewModel.UserModelId;
            todoList.Description = viewModel.Description;
            todoList.Items = new List<ToDoListItems>();

            foreach (var item in viewModel.Items)
            {
                var itemModel = ToDoListItemMapper.MapItemsViewModelToItemsModel(item);
                todoList.Items.Add(itemModel);
            }

            return todoList;

        }

        public static ToDoListViewModel MapToToDoListModelToToDoListViewModel(ToDoList list)
        {
            var todoListViewModel = new ToDoListViewModel();

            todoListViewModel.Id = list.Id;
            todoListViewModel.Name = list.Name;
            todoListViewModel.UserModelId = list.UserModelId;
            todoListViewModel.Description = list.Description;
            todoListViewModel.Items = new List<ToDoListItemViewModel>();

            foreach (var item in list.Items)
            {
                var itemViewModel = ToDoListItemMapper.MapItemsModelToItemsViewModel(item);
                todoListViewModel.Items.Add(itemViewModel);
            }
            return todoListViewModel;
 
        }
    }
}
