using Microsoft.EntityFrameworkCore.Migrations;
using WeddingWebsite.Models.People;

#nullable disable

namespace WeddingWebsite.Migrations
{
    /// <inheritdoc />
    public partial class CleanupRsvpStatusColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Make a new table, copy all data across, drop the old table and rename the new one. This is the only way to remove a column from a table in SQLite.
            // Warning: This will lose any RSVP data, as this table references Guests with on delete cascade.
            
            migrationBuilder.CreateTable(
                name: "NewGuests",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    GuestId = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => new { x.GuestId });
                    table.ForeignKey(
                        name: "FK_Guests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                }
            );
            migrationBuilder.Sql("INSERT INTO NewGuests (UserId, GuestId, FirstName, LastName) SELECT UserId, GuestId, FirstName, LastName FROM Guests");
            migrationBuilder.DropTable(name: "Guests");
            migrationBuilder.RenameTable(name: "NewGuests", newName: "Guests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Add the column back in (no need to copy data back across as it is natively supported).
            // Note that all values before the migration were zero, so this will restore the existing data perfectly.
            migrationBuilder.AddColumn<int>(
                name: "RsvpStatus",
                table: "Guests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0
            );
        }
    }
}
