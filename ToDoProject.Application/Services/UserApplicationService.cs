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

        public UserViewModel GetUserForDisplay(int id)
        {
            var user = _userService.GetUser(id);
            return UserMapper.MapUserModelToUserViewModel(user);
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
