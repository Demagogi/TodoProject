using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoProject.Migrations
{
    /// <inheritdoc />
    public partial class ReplacedCondditionPoperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskCondition",
                table: "ToDoList");

            migrationBuilder.AddColumn<int>(
                name: "TaskItemCondition",
                table: "ToDoListItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ToDoListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "TaskItemCondition",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskItemCondition",
                table: "ToDoListItems");

            migrationBuilder.AddColumn<int>(
                name: "TaskCondition",
                table: "ToDoList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ToDoList",
                keyColumn: "Id",
                keyValue: 1,
                column: "TaskCondition",
                value: 0);
        }
    }
}
