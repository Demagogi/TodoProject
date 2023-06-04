using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoList_Users_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                table: "Users",
                columns: new[] { "Id", "PassWord", "Role", "UserName" },
                values: new object[] { 1, "ramdariro", 1, "TestUser" });

            migrationBuilder.InsertData(
                table: "ToDoList",
                columns: new[] { "Id", "Description", "Name", "UserModelId" },
                values: new object[] { 1, "Test Task 10 Description", "Test Task 10", 1 });

            migrationBuilder.InsertData(
                table: "ToDoListItems",
                columns: new[] { "Id", "Description", "Title", "ToDoListId" },
                values: new object[] { 1, "Test Task 10 Description", "Test Task 10 Item", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoList_UserModelId",
                table: "ToDoList",
                column: "UserModelId");

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

            migrationBuilder.DropTable(
                name: "ToDoList");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
