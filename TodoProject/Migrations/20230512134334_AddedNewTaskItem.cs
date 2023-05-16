using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoProject.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewTaskItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoListItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDoList",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "ToDoList",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 10, "Test Task 10 Description", "Test Task 10" });

            migrationBuilder.InsertData(
                table: "ToDoListItems",
                columns: new[] { "Id", "Description", "Title", "ToDoListId" },
                values: new object[] { 2, "Test Task 10 Description", "Test Task 10 Item", 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoListItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDoList",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "ToDoList",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Test Task Description", "Test Task" });

            migrationBuilder.InsertData(
                table: "ToDoListItems",
                columns: new[] { "Id", "Description", "Title", "ToDoListId" },
                values: new object[] { 1, "Test Task Description", "Test Task Item", 1 });
        }
    }
}
