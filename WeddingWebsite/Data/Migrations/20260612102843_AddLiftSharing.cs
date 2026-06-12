using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingWebsite.Migrations
{
    /// <inheritdoc />
    public partial class AddLiftSharing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("SharedLifts", table => new
            {
                Id = table.Column<string>(type: "TEXT", nullable: false),
                UserId = table.Column<string>(type: "TEXT", nullable: false),
                Name = table.Column<string>(type: "TEXT", nullable: false),
                Spaces = table.Column<int>(type: "INTEGER", nullable: false),
                StartLocation = table.Column<string>(type: "TEXT", nullable: false),
                EndLocation = table.Column<string>(type: "TEXT", nullable: false),
                StartTime = table.Column<int>(type: "INTEGER", nullable: false),
                EndTime = table.Column<int>(type: "INTEGER", nullable: false),
                Notes = table.Column<string>(type: "TEXT", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_SharedLifts", x => x.Id);
            });
            
            migrationBuilder.CreateTable("SharedLiftGuestBookings", table => new
            {
                LiftId = table.Column<string>(type: "TEXT", nullable: true),
                UserId = table.Column<string>(type: "TEXT", nullable: false),
                GuestId = table.Column<string>(type: "TEXT", nullable: false),
                BookedAt = table.Column<int>(type: "INTEGER", nullable: false),
                AcknowledgedAt = table.Column<int>(type: "INTEGER", nullable: true)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_SharedLiftBookings", x => new { x.UserId, x.GuestId });
                table.ForeignKey("FK_SharedLiftBookings_AspNetUsers_UserId", x => x.UserId, "AspNetUsers", "Id", onDelete: ReferentialAction.Cascade);
                table.ForeignKey("FK_SharedLiftBookings_Guests_GuestId", x => x.GuestId, "Guests", "Id", onDelete: ReferentialAction.Cascade);
                table.ForeignKey("FK_SharedLiftBookings_SharedLifts_LiftId", x => x.LiftId, "SharedLifts", "Id", onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable("SharedLiftNonGuestBookings", table => new
            {
                LiftId = table.Column<string>(type: "TEXT", nullable: true),
                UserId = table.Column<string>(type: "TEXT", nullable: false),
                PassengerName = table.Column<string>(type: "TEXT", nullable: false),
                BookedAt = table.Column<int>(type: "INTEGER", nullable: false),
                AcknowledgedAt = table.Column<int>(type: "INTEGER", nullable: true)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_SharedLiftNonGuestBookings", x => new { x.UserId, x.PassengerName });
                table.ForeignKey("FK_SharedLiftNonGuestBookings_AspNetUsers_UserId", x => x.UserId, "AspNetUsers", "Id", onDelete: ReferentialAction.Cascade);
                table.ForeignKey("FK_SharedLiftNonGuestBookings_SharedLifts_LiftId", x => x.LiftId, "SharedLifts", "Id", onDelete: ReferentialAction.Cascade);
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("SharedLifts");
            migrationBuilder.DropTable("SharedLiftGuestBookings");
            migrationBuilder.DropTable("SharedLiftNonGuestBookings");
        }
    }
}
