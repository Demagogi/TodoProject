namespace TodoProject.Models
{
    public class ToDoListItems
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public int ToDoListId { get; set; }
    }
}
