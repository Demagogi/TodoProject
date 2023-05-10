using TodoProject.Models;

namespace TodoProject.Models
{
    public class ToDoListItems
    {
        public int Id { get; set; }
        public int ToDoListId { get; set; }
        public ToDoList ToDoList { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
