using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoProject.DATA;
using TodoProject.Models;

namespace TodoProject.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "ToDoList");
        }
    }
}
