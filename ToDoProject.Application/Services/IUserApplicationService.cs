using ToDoProject.Application.ViewModels;

namespace ToDoProject.Application.Services
{
    public interface IUserApplicationService
    {
        List<UserViewModel> GetUsersForDisplay();
        UserViewModel GetUserForDisplay(int id);
        void UpdateUserView(UserViewModel userView);
        void AddUserView(CreateUserViewModel userView);
        void RemoveUserView(UserViewModel userView);
    }
}
