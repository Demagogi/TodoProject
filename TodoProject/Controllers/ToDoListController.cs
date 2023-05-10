using Microsoft.AspNetCore.Mvc;

namespace TodoProject.Controllers
{
    public class ToDoListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
