using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoProject.DataAccess.Data;
using TodoProject.Hubs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ToDoProject.Application.Services;

namespace TodoProject.Controllers
{
    [Authorize]
    public class ToDoListController : Controller
    {
        private readonly IToDoListApplicationService _listService;
        private readonly IToDoListItemApplicationService _itemService;

        public ToDoListController(IToDoListApplicationService listService, IToDoListItemApplicationService itemService)
        {
            _listService = listService;
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            var toDoLists = _listService.GetAllToDoViews().ToList();
            return View(toDoLists);
        }

        public IActionResult Create(int? id)
        {
            //UserModel user = _Userrepo.Get(t => t.Id == id, "UserToDos");

            //var todo = new CreateToDoListViewModel
            //{
            //    UserModelId = user.Id
            //};
            var todoView = _listService.AddToDoView();
            return View(todoView);
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
            //ToDoList list = _repo.Get(u => u.Id == id, "Items");
            
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
            //ToDoList ToDoFromDb = _repo.Get(u => u.Id == id, "Items");
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

            //ToDoList toDoFromDb = _repo.Get(u => u.Id == id, "Items");
            var todoView = _listService.GetToDoView();

            if (todoView == null)
            {
                return NotFound();
            }

            return View(todoView);
        }
        public  async Task<IActionResult> EditItem(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //ToDoListItems ToDoItemFromDb = _Itemsrepo.Get(x => x.Id == id);
            var item = _itemService.GetItemToView();
      
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult EditItem(ToDoListItems obj) // how to fix this ?
        {
            _itemService.UpdateItemView(obj);
            return RedirectToAction("Index", "ToDoList");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //ToDoList ToDoFromDb = _repo.Get(u => u.Id == id);
            var todoView = _listService.GetToDoView();
            if (todoView == null)
            {
                return NotFound();
            }
            return View(todoView);
        }

        [HttpPost]
        public IActionResult Edit(ToDoList obj) // how to fix this?
        {
            _listService.UpdateToDoView(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //ToDoList ToDoFromDb = _repo.Get(u=>u.Id==id);
            var todoView = _listService.GetToDoView();
            if (todoView == null)
            {
                return NotFound();
            }
            return View(todoView);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id) 
        {
            //ToDoList obj = _repo.Get(u => u.Id == id);
            var obj = _listService.GetToDoView();
            if (obj == null)
            {
                return NotFound();
            }
            _listService.RemoveToDoView(obj);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteItem(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //ToDoListItems ItemFromDb = _Itemsrepo.Get(x => x.Id == id);
            var itemView = _itemService.GetItemToView();
            if (itemView == null)
            {
                return NotFound();
            }
            return View(itemView);
        }

        [HttpPost, ActionName("DeleteItem")]
        public IActionResult DeleteItemPost(int? id)
        {
            //ToDoListItems obj = _Itemsrepo.Get(x => x.Id == id);
            var obj = _itemService.GetItemToView();
            if (obj == null)
            {
                return NotFound();
            }
            _itemService.RemoveItemView(obj);
            return RedirectToAction("Index");
        }
    }
}
