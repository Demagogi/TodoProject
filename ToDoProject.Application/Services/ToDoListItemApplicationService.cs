using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoProject.Domain.Interfaces;

namespace ToDoProject.Application.Services
{
    public class ToDoListItemApplicationService : IToDoListItemApplicationService
    {
        private readonly IToDoListItemService _service;

        public ToDoListItemApplicationService(IToDoListItemService service)
        {
            _service = service;
        }
    }
}
