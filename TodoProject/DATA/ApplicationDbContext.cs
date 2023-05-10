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
            // Configure the relationship
            modelBuilder.Entity<ToDoList>()
                .HasMany(tdl => tdl.Items) // ToDoList has many ToDoListItems
                .WithOne(tdi => tdi.ToDoList) // ToDoListItem has one ToDoList
                .HasForeignKey(tdi => tdi.ToDoListId); // Use ToDoListId as the foreign key
        }

    }
}
