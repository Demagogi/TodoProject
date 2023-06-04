namespace TodoProject.Models.Models 
{
    public class CreateToDoListViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserModelId { get; set; }
        public List<ToDoListItems> Items { get; set; }
    }
}
