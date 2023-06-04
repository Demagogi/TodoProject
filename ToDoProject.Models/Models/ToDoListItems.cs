namespace TodoProject.Models.Models
{
    public class ToDoListItems
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public TaskItemCondition Condition { get; set; }
        public int ToDoListId { get; set; }
    }

    public enum TaskItemCondition
    {
        NotStarted,
        InProgress,
        Completed
    }
}
