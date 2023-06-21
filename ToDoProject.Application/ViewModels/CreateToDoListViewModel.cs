using TodoProject.Application.ViewModels;

namespace ToDoProject.Application.ViewModels
{
    public class CreateToDoListViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserModelId { get; set; }
        public List<ToDoListItemViewModel> Items { get; set; }
    }
}
