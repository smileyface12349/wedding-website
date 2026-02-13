using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingWebsite.Migrations
{
    /// <inheritdoc />
    public partial class AddRsvpForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RsvpFormResponses",
                columns: table => new
                {
                    GuestId = table.Column<string>(type: "TEXT", nullable: false),
                    IsAttending = table.Column<int>(type: "INTEGER", nullable: false),
                    Data0 = table.Column<string>(type: "TEXT", nullable: true),
                    Data1 = table.Column<string>(type: "TEXT", nullable: true),
                    Data2 = table.Column<string>(type: "TEXT", nullable: true),
                    Data3 = table.Column<string>(type: "TEXT", nullable: true),
                    Data4 = table.Column<string>(type: "TEXT", nullable: true),
                    Data5 = table.Column<string>(type: "TEXT", nullable: true),
                    Data6 = table.Column<string>(type: "TEXT", nullable: true),
                    Data7 = table.Column<string>(type: "TEXT", nullable: true),
                    Data8 = table.Column<string>(type: "TEXT", nullable: true),
                    Data9 = table.Column<string>(type: "TEXT", nullable: true),
                    Data10 = table.Column<string>(type: "TEXT", nullable: true),
                    Data11 = table.Column<string>(type: "TEXT", nullable: true),
                    Data12 = table.Column<string>(type: "TEXT", nullable: true),
                    Data13 = table.Column<string>(type: "TEXT", nullable: true),
                    Data14 = table.Column<string>(type: "TEXT", nullable: true),
                    Data15 = table.Column<string>(type: "TEXT", nullable: true),
                    Data16 = table.Column<string>(type: "TEXT", nullable: true),
                    Data17 = table.Column<string>(type: "TEXT", nullable: true),
                    Data18 = table.Column<string>(type: "TEXT", nullable: true),
                    Data19 = table.Column<string>(type: "TEXT", nullable: true),
                    Data20 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RsvpFormResponses", x => new { x.GuestId });
                    table.ForeignKey(
                        name: "FK_RsvpFormResponses_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "RsvpFormResponses");
        }
    }
}
