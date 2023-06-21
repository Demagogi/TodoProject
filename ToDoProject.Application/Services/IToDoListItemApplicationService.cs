using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Application.ViewModels;
using TodoProject.Domain.Models;

namespace ToDoProject.Application.Services
{
    public interface IToDoListItemApplicationService
    {
        List<ToDoListItemViewModel> GetItemsToView();
        ToDoListItemViewModel GetItemToView();

        void AddItemView(ToDoListItemViewModel item);
        void RemoveItemView(ToDoListItemViewModel item);
        void UpdateItemView(ToDoListItemViewModel item);
    }
}
