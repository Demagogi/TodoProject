using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Application.ViewModels;
using TodoProject.Domain.Models;

namespace ToDoProject.Application.Mappers
{
    public static class ToDoListMapper
    {
        public static ToDoList MapToDoListViewModelToToDoListModel(ToDoListViewModel viewModel)
        {
            var todoList = new ToDoList();
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
