using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TodoProject.DataAccess.Data;
using TodoProject.Models.Models;
using TodoProject.Hubs;
using ToDoProject.DataAccess.Repository.IRepository;

namespace TodoProject.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IUserRepository _Userrepo;
        private readonly IToDoRepository _repo;
        private readonly IToDoListItemsRepository _Itemsrepo;

        private readonly IHubContext<UserHub> _hubContext;

        public ManagerController(IUserRepository Userrepo, IToDoRepository repo, IToDoListItemsRepository Itemsrepo, IHubContext<UserHub> hubContext)
        {
            _Userrepo = Userrepo;
            _repo = repo;
            _Itemsrepo = Itemsrepo;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            List<UserModel> users = _Userrepo.GetAll().ToList();
            return View(users);
        }

        public IActionResult UserDetails(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ToDoList list = _repo.Get(x => x.Id == id);
            UserModel user = _Userrepo.Get(x => x.Id == list.UserModelId, "UserToDos");
            return View(user.UserToDos);
        }

        public IActionResult ToDoDetails(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ToDoList ToDoFromDb = _repo.Get(t => t.Id == id, "Items");
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

            ToDoList toDoFromDb = _repo.Get(x => x.Id == id, "Items");

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

        public IActionResult EditItem(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ToDoListItems ToDoFromDb = _Itemsrepo.Get(x => x.Id == id); //todolist item bazidan

            if (ToDoFromDb == null)
            {
                return NotFound();
            }
            return View(ToDoFromDb);
        }

        [HttpPost]
        public async Task<IActionResult> EditItem(ToDoListItems obj)
        {
            _Itemsrepo.Update(obj);
            _Itemsrepo.Save();

            ToDoListItems ToDoFromDb = _Itemsrepo.Get(x => x.Id == obj.Id); //todolist item bazidan
            ToDoList list = _repo.Get(x => x.Id == ToDoFromDb.ToDoListId, "Items"); // shesabamisi list 
            UserModel user = _Userrepo.Get(x => x.Id == list.UserModelId, "UserToDos"); // listis shesabamisi user


            await _hubContext.Clients.User(user.Id.ToString()).SendAsync("notifyTaskStatus");
            //await _hubContext.Clients.All.SendAsync("notifyTaskStatus");

            return RedirectToAction("Index", "Manager");
        }

    }
}
