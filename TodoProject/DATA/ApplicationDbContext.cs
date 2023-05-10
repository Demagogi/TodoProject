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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoListItems>().HasData(new ToDoListItems {Id=1 , Title = "Test Task Item", Description = "This is test task item for vizualization" });
            modelBuilder.Entity<ToDoList>().HasData(
            new ToDoList { Id = 1, Name = "Test Task", Description = "This is test task for vizualization" }
            );
        }
    }
}
