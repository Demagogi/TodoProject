using Microsoft.AspNetCore.Mvc;

namespace TodoProject.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
