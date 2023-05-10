namespace TodoProject.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ToDoListItems> Items { get; set; }

        public ToDoList()
        {
            Items = new List<ToDoListItems>();
        }
    }
}
