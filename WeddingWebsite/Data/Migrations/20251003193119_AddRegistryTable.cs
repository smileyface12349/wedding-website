using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingWebsite.Migrations
{
    /// <inheritdoc />
    public partial class AddRegistryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistryItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    GenericName = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    MaxQuantity = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 1),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    Hide = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistryItems", x => x.Id);
                });
            
            migrationBuilder.CreateTable(
                name: "RegistryItemPurchaseMethods",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ItemId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AllowBringOnDay = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    AllowDeliverToUs = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Instructions = table.Column<string>(type: "TEXT", nullable: true),
                    Cost = table.Column<double>(type: "REAL", nullable: false),
                    DeliveryCost = table.Column<double>(type: "REAL", defaultValue: 0, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistryItemPurchaseMethods", x => x.Id);
                    table.ForeignKey(
                        "FK_RegistryItemPurchaseMethods_RegistryItems_ItemId", 
                        x => x.ItemId, 
                        "RegistryItems", 
                        "Id", 
                        onDelete: ReferentialAction.Cascade
                    );
                });

            migrationBuilder.CreateTable(
                name: "RegistryItemClaims",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimedBy = table.Column<string>(type: "TEXT", nullable: false),
                    PurchaseMethodId = table.Column<string>(type: "TEXT", nullable: true),
                    DeliveryAddress = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimedAt = table.Column<int>(type: "INTEGER", nullable: false),
                    CompletedAt = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 1),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistryItemClaims", x => new { x.ItemId, x.ClaimedBy });
                    table.ForeignKey(
                        "FK_RegistryItemClaims_RegistryItems_ItemId", 
                        x => x.ItemId, 
                        "RegistryItems", 
                        "Id", 
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        "FK_RegistryItemClaims_AspNetUsers_ClaimedBy",
                        x => x.ClaimedBy,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        "FK_RegistryItemClaims_RegistryItemPurchaseMethods_PurchaseMethodId",
                        x => x.PurchaseMethodId,
                        "RegistryItemPurchaseMethods",
                        "Id"
                    );
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("RegistryItems");
            migrationBuilder.DropTable("RegistryItemPurchaseMethods");
            migrationBuilder.DropTable("RegistryItemClaims");
        }
    }
}
