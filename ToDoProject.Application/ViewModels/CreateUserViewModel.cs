using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Application.ViewModels;

namespace ToDoProject.Application.ViewModels
{
    public class CreateUserViewModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public UserRoles Role { get; set; }
        public List<ToDoListViewModel> UserToDos { get; set; }
    }
}
