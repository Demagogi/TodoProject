using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedProgressProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskCondition",
                table: "ToDoList");
        }
    }
}
