﻿using Microsoft.AspNetCore.Mvc;

namespace TodoProject.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
