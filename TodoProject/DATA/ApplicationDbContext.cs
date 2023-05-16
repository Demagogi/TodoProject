using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
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
            // Configure TodoList and TodoListItem entities
            modelBuilder.Entity<ToDoList>()
                .HasMany(tl => tl.Items)                  // A TodoList has many TodoListItems
                .WithOne()                  // A TodoListItem belongs to one TodoList
                .HasForeignKey(tli => tli.ToDoListId)        // Foreign key property in TodoListItem
                .OnDelete(DeleteBehavior.Cascade);           // Cascade delete when TodoList is deleted

            modelBuilder.Entity<ToDoList>().HasData(new ToDoList { Id = 10, Name = "Test Task 10", Description = "Test Task 10 Description" });

            modelBuilder.Entity<ToDoListItems>().HasData(new ToDoListItems { Id = 2, Title = "Test Task 10 Item", Description = "Test Task 10 Description", ToDoListId = 10 });
        }



    }
}
