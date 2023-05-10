using Microsoft.AspNetCore.Mvc;
using TodoProject.DATA;
using TodoProject.Models;

namespace TodoProject.Controllers
{
    public class ToDoListItemsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ToDoListItemsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<ToDoListItems> objectToDoListItem = _db.ToDoListItems.ToList();
            return View(objectToDoListItem);
        }
    }
}
