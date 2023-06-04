using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoProject.DataAccess.Data;
using TodoProject.Models.Models;
using ToDoProject.DataAccess.Repository.IRepository;

namespace TodoProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _Userrepo;

        public UserController(IUserRepository Userrepo)
        {
            _Userrepo = Userrepo;
        }
        public IActionResult Index(int? userId)
        {
            UserModel user = _Userrepo.Get(t=>t.Id == userId, "UserToDos");
            return View(user);
        }
    }
}
