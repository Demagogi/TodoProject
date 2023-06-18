using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoProject.Domain.Interfaces;

namespace ToDoProject.Application.Services
{
    public class ToDoListApplicationService : IToDoListApplicationService
    {
        private readonly IToDoListService _service;
        public ToDoListApplicationService(IToDoListService service)
        {
            _service = service;
        }
    }
}
