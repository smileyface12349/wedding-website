using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingWebsite.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountLog",
                columns: table => new
                {
                    LogId = table.Column<string>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<int>(type: "INTEGER", nullable: false),
                    AffectedUserId = table.Column<string>(type: "TEXT", nullable: false),
                    ActorId = table.Column<string>(type: "TEXT", nullable: false),
                    EventType = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => new { x.LogId });
                    table.ForeignKey(
                        name: "FK_AccountLog_AspNetUsers_AffectedUserId",
                        column: x => x.AffectedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountLog_AspNetUsers_ActorId",
                        column: x => x.ActorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("AccountLog");
        }
    }
}
