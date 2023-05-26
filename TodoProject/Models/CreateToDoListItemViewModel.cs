namespace TodoProject.Models;

public class CreateToDoListItemViewModel
{
    public string Title { get; set; }

    public string Description { get; set; }

    public TaskItemCondition Condition { get; set; }
    public int ToDoListId { get; set; }
}
