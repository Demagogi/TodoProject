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

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ToDoList ToDoFromDb = _db.ToDoList.Find(id);
            if (ToDoFromDb == null)
            {
                return NotFound();
            }
            return View(ToDoFromDb);
        }

        [HttpPost]
        public IActionResult Edit(ToDoList obj)
        {
            if (ModelState.IsValid)
            {
                _db.ToDoList.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ToDoList categoryFromDb = _db.ToDoList.Find(id); 
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id) 
        {
            ToDoList obj = _db.ToDoList.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ToDoList.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
