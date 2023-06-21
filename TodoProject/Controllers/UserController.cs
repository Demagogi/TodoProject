using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoProject.DataAccess.Data;
using ToDoProject.Application.Services;

namespace TodoProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApplicationService _userService;

        public UserController(IUserApplicationService userService)
        {
            _userService = userService;
        }
        public IActionResult Index(int? userId)
        {
            //UserModel user = _Userrepo.Get(t=>t.Id == userId, "UserToDos");
            var userView = _userService.GetUserForDisplay();
            return View(userView);
        }
    }
}
