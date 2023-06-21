using TodoProject.Domain.Models;
using ToDoProject.Application.ViewModels;

namespace ToDoProject.Application.Mappers
{
    public static class UserMapper
    {

        public static UserModel MapCreateUserModelToUserModel(CreateUserViewModel model)
        {
            var userModel = new UserModel();

            userModel.UserName = model.UserName;
            userModel.PassWord = model.PassWord;
            userModel.Role = (TodoProject.Domain.Models.UserRoles)model.Role;

            userModel.UserToDos = model.UserToDos.Select(todo => ToDoListMapper.MapToDoListViewModelToToDoListModel(todo)).ToList();

            return userModel; 
        }

        public static UserViewModel MapUserModelToUserViewModel(UserModel user)
        {
            var userViewModel = new UserViewModel();

            userViewModel.Id = user.Id;
            userViewModel.UserName = user.UserName;
            userViewModel.PassWord = user.PassWord;
            userViewModel.Role = (ViewModels.UserRoles)user.Role;

            userViewModel.UserToDos = user.UserToDos.Select(todo => ToDoListMapper.MapToToDoListModelToToDoListViewModel(todo)).ToList();

            return userViewModel;
        }

        public static UserModel MapUserViewModelToUserModel(UserViewModel user)
        {
            var userModel = new UserModel();

            userModel.Id = user.Id;
            userModel.UserName = user.UserName;
            userModel.PassWord = user.PassWord;
            userModel.Role = (TodoProject.Domain.Models.UserRoles)user.Role;

            userModel.UserToDos = user.UserToDos.Select(todo => ToDoListMapper.MapToDoListViewModelToToDoListModel(todo)).ToList();

            return userModel;
        }
    }
}
