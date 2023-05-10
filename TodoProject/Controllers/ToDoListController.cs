using Microsoft.AspNetCore.Mvc;
using TodoProject.DATA;
using TodoProject.Models;

namespace TodoProject.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ToDoListController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<ToDoList> objectToDoList = _db.ToDoList.ToList();
            return View(objectToDoList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ToDoList obj) 
        {
            _db.ToDoList.Add(obj); 
            _db.SaveChanges(); 
            return RedirectToAction("Index", "ToDoList"); 
        }
    }
}
