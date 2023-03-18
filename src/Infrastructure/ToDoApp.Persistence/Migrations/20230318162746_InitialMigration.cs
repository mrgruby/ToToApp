using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    ToDoItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToDoItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToDoIsDone = table.Column<bool>(type: "bit", nullable: false),
                    ToDoItemId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.ToDoItemId);
                    table.ForeignKey(
                        name: "FK_ToDoItems_ToDoItems_ToDoItemId1",
                        column: x => x.ToDoItemId1,
                        principalTable: "ToDoItems",
                        principalColumn: "ToDoItemId");
                });

            migrationBuilder.CreateTable(
                name: "ToDoLists",
                columns: table => new
                {
                    ToDoListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToDoItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoLists", x => x.ToDoListId);
                    table.ForeignKey(
                        name: "FK_ToDoLists_ToDoItems_ToDoItemId",
                        column: x => x.ToDoItemId,
                        principalTable: "ToDoItems",
                        principalColumn: "ToDoItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "ToDoItemId", "ToDoIsDone", "ToDoItemId1", "ToDoItemName" },
                values: new object[,]
                {
                    { 1, false, null, "MyFirstTodo" },
                    { 2, false, null, "MySecondTodo" },
                    { 3, false, null, "MyThirdTodo" },
                    { 4, false, null, "MyFourthTodo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_ToDoItemId1",
                table: "ToDoItems",
                column: "ToDoItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_ToDoItemId",
                table: "ToDoLists",
                column: "ToDoItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoLists");

            migrationBuilder.DropTable(
                name: "ToDoItems");
        }
    }
}
