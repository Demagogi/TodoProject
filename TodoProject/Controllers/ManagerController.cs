using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TodoProject.DataAccess.Data;
using TodoProject.Hubs;
using ToDoProject.Application.Services;

namespace TodoProject.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IUserApplicationService _userService;
        private readonly IToDoListApplicationService _toDoListService;
        private readonly IToDoListItemApplicationService _ToDoListItemService;

        private readonly IHubContext<UserHub> _hubContext;

        public ManagerController(IUserApplicationService userService, IToDoListApplicationService toDoListService, IToDoListItemApplicationService ToDoListItemService, IHubContext<UserHub> hubContext)
        {
            _userService = userService;
            _toDoListService = toDoListService;
            _ToDoListItemService = ToDoListItemService;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            var usersView = _userService.GetUsersForDisplay();
            return View(usersView);
        }

        public IActionResult UserDetails(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //ToDoList list = _repo.Get(x => x.Id == id);
            //UserModel user = _Userrepo.Get(x => x.Id == list.UserModelId, "UserToDos");
            var listView = _toDoListService.GetToDoView();
            var user = _userService.GetUserForDisplay();
            return View(user.UserToDos);
        }

        public IActionResult ToDoDetails(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //ToDoList ToDoFromDb = _repo.Get(t => t.Id == id, "Items");
            var todoView = _toDoListService.GetToDoView();
            if (todoView == null)
            {
                return NotFound();
            }
            return View(todoView);
        }

        public IActionResult Items(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //ToDoList toDoFromDb = _repo.Get(x => x.Id == id, "Items");
            var todoView = _toDoListService.GetToDoView();
            if (todoView == null)
            {
                return NotFound();
            }

            //var model = new ToDoListItemsViewModel
            //{
            //    ToDoListId = toDoFromDb.Id,
            //    Items = toDoFromDb.Items
            //};
            var itemView = _ToDoListItemService.GetItemToView();

            return View(itemView);
        }

        public IActionResult EditItem(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //ToDoListItems ToDoFromDb = _Itemsrepo.Get(x => x.Id == id); //todolist item bazidan
            var itemView = _ToDoListItemService.GetItemToView();
            if (itemView == null)
            {
                return NotFound();
            }
            return View(itemView);
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
