using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingWebsite.Migrations
{
    /// <inheritdoc />
    public partial class AddTimestampToTodoList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                type: "INTEGER", 
                name: "CreatedAt", 
                table: "TodoItems", 
                nullable: false, 
                defaultValue: 0L
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Removing columns isn't supported, so we need to manually copy the data over.
            
            migrationBuilder.CreateTable(
                name: "OldTodoItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    OwnerId = table.Column<string>(type: "TEXT", nullable: true),
                    GroupId = table.Column<string>(type: "TEXT", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    WaitingUntil = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                    table.ForeignKey("FK_TodoItems_AspNetUsers_OwnerId", x => x.OwnerId, "AspNetUsers", "Id");
                    table.ForeignKey("FK_TodoItems_TodoGroups_GroupId", x => x.GroupId, "TodoGroups", "Id");
            });

            migrationBuilder.Sql(@"
                INSERT INTO OldTodoItems (Id, OwnerId, GroupId, Text, WaitingUntil, CompletedAt)
                SELECT Id, OwnerId, GroupId, Text, WaitingUntil, CompletedAt
                FROM TodoItems
            ");
            
            migrationBuilder.DropTable("TodoItems");
            migrationBuilder.RenameTable("OldTodoItems", newName: "TodoItems");
        }
    }
}
