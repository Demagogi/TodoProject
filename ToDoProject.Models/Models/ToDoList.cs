using System.ComponentModel.DataAnnotations.Schema;


namespace TodoProject.Domain.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
		public int UserModelId { get; set; }
		public  List<ToDoListItems> Items { get; set;}

    }
}
