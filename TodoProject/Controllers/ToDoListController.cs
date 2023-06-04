using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoProject.DataAccess.Data;
using TodoProject.Models.Models;
using TodoProject.Hubs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ToDoProject.DataAccess.Repository.IRepository;

namespace TodoProject.Controllers
{
    [Authorize]
    public class ToDoListController : Controller
    {
        private readonly IToDoRepository _repo;
        private readonly IToDoListItemsRepository _Itemsrepo;
        private readonly IUserRepository _Userrepo;

        public ToDoListController(IToDoRepository repo, IToDoListItemsRepository itemsrepo, IUserRepository userrepo)
        {
            _repo = repo;
            _Itemsrepo = itemsrepo;
            _Userrepo = userrepo;
        }

        public IActionResult Index()
        {
            List<ToDoList> objectToDoList = _repo.GetAll().ToList();
            return View(objectToDoList);
        }

        public IActionResult Create(int? id)
        {
            UserModel user = _Userrepo.Get(t => t.Id == id, "UserToDos");
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

            _repo.Add(list);
            _repo.Save();
            return RedirectToAction("Index", "User", new { userId = obj.UserModelId });

        }

        public IActionResult CreateItem(int? id)
        {
            ToDoList list = _repo.Get(u => u.Id == id, "Items");
            
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

            _Itemsrepo.Add(item);
            _Itemsrepo.Save();
            return RedirectToAction("Index", "ToDoList");
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ToDoList ToDoFromDb = _repo.Get(u => u.Id == id, "Items");
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
      
            ToDoList toDoFromDb = _repo.Get(u => u.Id == id, "Items");

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

            ToDoListItems ToDoItemFromDb = _Itemsrepo.Get(x => x.Id == id);
      
            if (ToDoItemFromDb == null)
            {
                return NotFound();
            }
            return View(ToDoItemFromDb);
        }

        [HttpPost]
        public IActionResult EditItem(ToDoListItems obj)
        {
            _Itemsrepo.Update(obj);
            _Itemsrepo.Save();
    
            return RedirectToAction("Index", "ToDoList");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ToDoList ToDoFromDb = _repo.Get(u => u.Id == id);
            if (ToDoFromDb == null)
            {
                return NotFound();
            }
            return View(ToDoFromDb);
        }

        [HttpPost]
        public IActionResult Edit(ToDoList obj)
        {
            _repo.Update(obj);
            _repo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ToDoList ToDoFromDb = _repo.Get(u=>u.Id==id); 
            if (ToDoFromDb == null)
            {
                return NotFound();
            }
            return View(ToDoFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id) 
        {
            ToDoList obj = _repo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _repo.Delete(obj);
            _repo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteItem(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ToDoListItems ItemFromDb = _Itemsrepo.Get(x => x.Id == id);
            if (ItemFromDb == null)
            {
                return NotFound();
            }
            return View(ItemFromDb);
        }

        [HttpPost, ActionName("DeleteItem")]
        public IActionResult DeleteItemPost(int? id)
        {
            ToDoListItems obj = _Itemsrepo.Get(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _Itemsrepo.Delete(obj);
            _Itemsrepo.Save();
            return RedirectToAction("Index");
        }
    }
}
