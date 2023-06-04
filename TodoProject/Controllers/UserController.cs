using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoProject.DataAccess.Data;
using TodoProject.Models.Models;

namespace TodoProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int? userId)
        {
            UserModel user = _db.Users.Include(t=>t.UserToDos).FirstOrDefault(t=>t.Id == userId);
            return View(user);
        }
    }
}
