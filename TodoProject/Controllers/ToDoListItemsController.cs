using Microsoft.AspNetCore.Mvc;

namespace TodoProject.Controllers
{
    public class ToDoListItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
