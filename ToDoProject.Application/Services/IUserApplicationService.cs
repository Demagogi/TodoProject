using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoProject.Application.ViewModels;

namespace ToDoProject.Application.Services
{
    public interface IUserApplicationService
    {
        List<UserViewModel> GetUsersForDisplay();
        UserViewModel GetUserForDisplay();
        void UpdateUserView(UserViewModel userView);
        void AddUserView(UserViewModel userView);
        void RemoveUserView(UserViewModel userView);
    }
}
