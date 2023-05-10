using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoListItems");

            migrationBuilder.InsertData(
                table: "ToDoList",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Test Task Description", "Test Task" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoList",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "ToDoListItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToDoListId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoListItems_ToDoList_ToDoListId",
                        column: x => x.ToDoListId,
                        principalTable: "ToDoList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoListItems_ToDoListId",
                table: "ToDoListItems",
                column: "ToDoListId");
        }
    }
}
