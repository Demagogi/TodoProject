using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TodoProject.Models;

namespace TodoProject.DATA
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ToDoList> ToDoList { get; set; }
        public DbSet<ToDoListItems> ToDoListItems { get; set; }
    }
}
