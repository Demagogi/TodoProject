namespace TodoProject.Application.ViewModels
{
    public class ToDoListItemViewModel
    {
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

