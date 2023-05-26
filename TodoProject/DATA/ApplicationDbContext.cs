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

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

			modelBuilder.Entity<UserModel>()
				.HasMany(utd => utd.UserToDos)
				.WithOne()
				.HasForeignKey(utdl => utdl.UserModelId)
				.OnDelete(DeleteBehavior.Cascade);

			// Configure TodoList and TodoListItem entities
			modelBuilder.Entity<ToDoList>()
                .HasMany(tl => tl.Items)                  // A TodoList has many TodoListItems
                .WithOne()                  // A TodoListItem belongs to one TodoList
                .HasForeignKey(tli => tli.ToDoListId)        // Foreign key property in TodoListItem
                .OnDelete(DeleteBehavior.Cascade);           // Cascade delete when TodoList is deleted

			modelBuilder.Entity<UserModel>().HasData(new UserModel { Id = 1, UserName = "TestUser", PassWord = "ramdariro", Role = UserRoles.User });

			modelBuilder.Entity<ToDoList>().HasData(new ToDoList { Id = 1, Name = "Test Task 10", Description = "Test Task 10 Description", UserModelId = 1 });

            modelBuilder.Entity<ToDoListItems>().HasData(new ToDoListItems { Id = 1, Title = "Test Task 10 Item", Description = "Test Task 10 Description", ToDoListId = 1 });

            modelBuilder.Entity<UserModel>()
                .Property(u => u.Role)
                .HasColumnName("UserRole");

            modelBuilder.Entity<ToDoListItems>().
                Property(u => u.Condition).
                HasColumnName("TaskItemCondition");
        }



    }
}
