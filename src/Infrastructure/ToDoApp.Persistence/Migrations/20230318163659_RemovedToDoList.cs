using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovedToDoList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoLists");

            migrationBuilder.AddColumn<string>(
                name: "ToDoDescription",
                table: "ToDoItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: 1,
                column: "ToDoDescription",
                value: "");

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: 2,
                column: "ToDoDescription",
                value: "");

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: 3,
                column: "ToDoDescription",
                value: "");

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: 4,
                column: "ToDoDescription",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToDoDescription",
                table: "ToDoItems");

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

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_ToDoItemId",
                table: "ToDoLists",
                column: "ToDoItemId");
        }
    }
}
