namespace TodoProject.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public UserRoles Role { get; set; }
        public List<ToDoList> UserToDos { get; set; }
    }

    public enum UserRoles
    {
        Manager,
        User
    }
}

