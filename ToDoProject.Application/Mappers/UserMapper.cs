using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Domain.Models;
using ToDoProject.Application.ViewModels;

namespace ToDoProject.Application.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel MapUserModelToUserViewModel(UserModel user)
        {
            var userViewModel = new UserViewModel();
            userViewModel.UserName = user.UserName;
            userViewModel.PassWord = user.PassWord;
            userViewModel.Role = (ViewModels.UserRoles)user.Role;
            userViewModel.UserToDos = user.UserToDos.Select(todo => ToDoListMapper.MapToToDoListModelToToDoListViewModel(todo)).ToList();

            return userViewModel;
        }

        public static UserModel MapUserViewModelToUserModel(UserViewModel user)
        {
            var userModel = new UserModel();
            userModel.UserName = user.UserName;
            userModel.PassWord = user.PassWord;
            userModel.Role = (TodoProject.Domain.Models.UserRoles)user.Role;
            userModel.UserToDos = user.UserToDos.Select(todo => ToDoListMapper.MapToDoListViewModelToToDoListModel(todo)).ToList();
            return userModel;
        }
    }
}
