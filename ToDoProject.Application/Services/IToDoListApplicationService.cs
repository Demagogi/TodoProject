using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Application.ViewModels;

namespace ToDoProject.Application.Services
{
    public interface IToDoListApplicationService
    {
        List<ToDoListViewModel> GetAllToDoViews();
        ToDoListViewModel GetToDoView(Expression<Func<ToDoListViewModel, bool>> filter, string includeProperties = null);

        void AddToDoView(ToDoListViewModel todoView);
        void RemoveToDoView(ToDoListViewModel todoView);
        void UpdateToDoView(ToDoListViewModel todoView);
    }
}
