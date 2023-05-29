using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TodoProject.DATA;
using TodoProject.Hubs;
using TodoProject.Models;

namespace TodoProject.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly IHubContext<UserHub> _hubContext;

        public ManagerController(ApplicationDbContext db, IHubContext<UserHub> hubContext)
        {
            _db = db;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            List<UserModel> users = _db.Users.ToList();
            return View(users);
        }

        public IActionResult UserDetails(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ToDoList list = _db.ToDoList.FirstOrDefault(x => x.Id == id);
            UserModel user = _db.Users.Include(x => x.UserToDos).FirstOrDefault(x => x.Id == list.UserModelId);
            return View(user.UserToDos);
        }

        public IActionResult ToDoDetails(int? id) 
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

        public IActionResult EditItem(int? id)
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
        public async Task<IActionResult> EditItem(ToDoListItems obj)
        {
            _db.ToDoListItems.Update(obj);
            _db.SaveChanges();

            ToDoListItems ToDoFromDb = _db.ToDoListItems.FirstOrDefault(x => x.Id == obj.Id); //todolist item bazidan
            ToDoList list = _db.ToDoList.Include(x => x.Items).FirstOrDefault(x => x.Id == ToDoFromDb.ToDoListId); // shesabamisi list 
            UserModel user = _db.Users.Include(x => x.UserToDos).FirstOrDefault(x => x.Id == list.UserModelId); // listis shesabamisi user


            await _hubContext.Clients.User(user.Id.ToString()).SendAsync("notifyTaskStatus");
            //await _hubContext.Clients.All.SendAsync("notifyTaskStatus");

            return RedirectToAction("Index", "Manager");
        }

    }
}
