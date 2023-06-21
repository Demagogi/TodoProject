
namespace TodoProject.Application.ViewModels
{
    public class ToDoListViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserModelId { get; set; }
        public List<ToDoListItemViewModel> Items { get; set; }
    }
}
