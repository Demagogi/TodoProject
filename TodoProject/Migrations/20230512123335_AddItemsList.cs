using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoProject.Migrations
{
    /// <inheritdoc />
    public partial class AddItemsList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoListItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToDoListId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "ToDoListItems",
                columns: new[] { "Id", "Description", "Title", "ToDoListId" },
                values: new object[] { 1, "Test Task Description", "Test Task Item", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoListItems_ToDoListId",
                table: "ToDoListItems",
                column: "ToDoListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoListItems");
        }
    }
}
