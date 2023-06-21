using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoProject.Application.Mappers;
using ToDoProject.Application.ViewModels;
using ToDoProject.Domain.Interfaces;

namespace ToDoProject.Application.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserService _userService;

        public UserApplicationService(IUserService userService)
        {
            _userService = userService;
        }

        public void AddUserView(UserViewModel userView)
        {
            _userService.AddUser(UserMapper.MapUserViewModelToUserModel(userView));
        }

        public UserViewModel GetUserForDisplay()
        {
            throw new NotImplementedException();
        }

        public List<UserViewModel> GetUsersForDisplay()
        {
            var users = _userService.GetAllUsers();
            var userViews = users.Select(user => UserMapper.MapUserModelToUserViewModel(user)).ToList();
            return userViews;
        }

        public void RemoveUserView(UserViewModel userView)
        {
            _userService.RemoveUser(UserMapper.MapUserViewModelToUserModel(userView));
        }

        public void UpdateUserView(UserViewModel userView)
        {
            _userService.UpdateUser(UserMapper.MapUserViewModelToUserModel(userView));
        }
    }
}
