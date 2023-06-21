using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoProject.Application.Services;
using ToDoProject.Application.ViewModels;

namespace TodoProject.Controllers
{
    public class AccauntController : Controller
    {
        private readonly IUserApplicationService _userService;

        public AccauntController(IUserApplicationService userService)
        {
            _userService = userService;
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
        public ActionResult Register(CreateUserViewModel user)
        {
            _userService.AddUserView(user);
            return RedirectToAction("Login", "Accaunt");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserViewModel user)
        {
            var existingUser = _userService.GetUserForDisplay(user.Id);

            if (existingUser != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, existingUser.UserName),
                    new Claim(ClaimTypes.Role, existingUser.Role.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, existingUser.Id.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                if (existingUser.Role == UserRoles.Manager)
                {
                    return RedirectToAction("Index", "Manager");
                }
                else if (existingUser.Role == UserRoles.User)
                {
                    return RedirectToAction("Index", "User", new { userId = existingUser.Id });
                }
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(user);
        }
    }
}
