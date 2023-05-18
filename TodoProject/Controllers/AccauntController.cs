using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoProject.DATA;
using TodoProject.Models;

namespace TodoProject.Controllers
{
    public class AccauntController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AccauntController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            var existingUser = _db.Users.FirstOrDefault(u => u.UserName == user.UserName && u.PassWord == user.PassWord);
            if (existingUser != null)
            {
                if (existingUser.Role == UserRoles.Manager)
                {
                    return RedirectToAction("Index", "Manager");
                }
                else if (existingUser.Role == UserRoles.User)
                {
                    return RedirectToAction("Index", "User");
                }
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(user);
        }
    }
}
