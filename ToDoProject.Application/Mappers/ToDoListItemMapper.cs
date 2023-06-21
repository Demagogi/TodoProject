using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Application.ViewModels;
using TodoProject.Domain.Models;

namespace ToDoProject.Application.Mappers
{
    public static class ToDoListItemMapper
    {
        public static ToDoListItemViewModel MapItemsModelToItemsViewModel(ToDoListItems item)
        {
            var itemViewModel = new ToDoListItemViewModel();
            itemViewModel.Title = item.Title;
            itemViewModel.Description = item.Description;
            itemViewModel.ToDoListId = item.ToDoListId;
            itemViewModel.Condition = (TodoProject.Application.ViewModels.TaskItemCondition)item.Condition;

            return itemViewModel;
        }

        public static ToDoListItems MapItemsViewModelToItemsModel(ToDoListItemViewModel item)
        {
            var itemModel = new ToDoListItems();
            itemModel.Title = item.Title;
            itemModel.Description = item.Description;
            itemModel.ToDoListId = item.ToDoListId;
            itemModel.Condition = (TodoProject.Domain.Models.TaskItemCondition)item.Condition;

            return itemModel;

        }
    }
}
