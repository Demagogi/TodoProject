using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoProject.DATA;
using TodoProject.Hubs;
using TodoProject.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace TodoProject.Controllers
{
    [Authorize]
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

        public IActionResult Create(int? id)
        {
            UserModel user = _db.Users.Include(t => t.UserToDos).FirstOrDefault(t => t.Id == id);
            var todo = new CreateToDoListViewModel
            {
                UserModelId = user.Id
            };
            return View(todo);
        }

        [HttpPost]
        public IActionResult Create(CreateToDoListViewModel obj) 
        {
            ToDoList list = new ToDoList
            {
                Name = obj.Name,
                Description = obj.Description,
                UserModelId = obj.UserModelId
            };

            _db.ToDoList.Add(list);
            _db.SaveChanges();
            return RedirectToAction("Index", "User", new { userId = obj.UserModelId });

        }

        public IActionResult CreateItem(int? id)
        {
            ToDoList list = _db.ToDoList.Include(t => t.Items).FirstOrDefault(t => t.Id == id);
            
            var model = new CreateToDoListItemViewModel
            {
                ToDoListId = list.Id
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateItem(CreateToDoListItemViewModel obj)
        {
            ToDoListItems item = new ToDoListItems
            {
                Title = obj.Title,
                Description = obj.Description,
                ToDoListId = obj.ToDoListId
            };

            _db.ToDoListItems.Add(item);
            _db.SaveChanges();
            return RedirectToAction("Index", "ToDoList");
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ToDoList ToDoFromDb = _db.ToDoList.Include(t => t.Items).FirstOrDefault(t => t.Id == id);
            if (ToDoFromDb == null)
            {
                return NotFound();
            }
            return View(ToDoFromDb);
        }

        public IActionResult Items(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
      
            ToDoList toDoFromDb = _db.ToDoList.Include(x => x.Items).FirstOrDefault(x => x.Id == id);

            if (toDoFromDb == null)
            {
                return NotFound();
            }

            var model = new ToDoListItemsViewModel
            {
                ToDoListId = toDoFromDb.Id,
                Items = toDoFromDb.Items
            };

            return View(model);
        }
        public  async Task<IActionResult> EditItem(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ToDoListItems ToDoFromDb = _db.ToDoListItems.FirstOrDefault(x => x.Id == id); //todolist item bazidan
      
            if (ToDoFromDb == null)
            {
                return NotFound();
            }
            return View(ToDoFromDb);
        }

        [HttpPost]
        public IActionResult EditItem(ToDoListItems obj)
        {
            _db.ToDoListItems.Update(obj);
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
            _db.ToDoList.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
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

        public IActionResult DeleteItem(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ToDoListItems ItemFromDb = _db.ToDoListItems.Find(id);
            if (ItemFromDb == null)
            {
                return NotFound();
            }
            return View(ItemFromDb);
        }

        [HttpPost, ActionName("DeleteItem")]
        public IActionResult DeleteItemPost(int? id)
        {
            ToDoListItems obj = _db.ToDoListItems.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ToDoListItems.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
