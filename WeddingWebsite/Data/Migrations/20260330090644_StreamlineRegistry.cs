using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

// Warning: This migration is not fully reversible, and some data is lost when applying it.

namespace WeddingWebsite.Migrations
{
    /// <inheritdoc />
    public partial class StreamlineRegistry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Warning: This migration is not fully reversible, and some data is lost when applying it.

            // RegistryItemClaims: Add FulfillmentMethod column.
            migrationBuilder.AddColumn<int>(
                name: "FulfillmentMethod",
                table: "RegistryItemClaims",
                type: "INTEGER",
                nullable: true
            );
            
            // Copy over fulfillment method from existing claims.
            migrationBuilder.Sql(
                @"UPDATE RegistryItemClaims
                SET FulfillmentMethod = CASE 
                    WHEN DeliveryAddress = 'Bring it on the day' THEN 0
                    WHEN DeliveryAddress IS NULL THEN 2
                    ELSE 1
                END"
            );
            
            // RegistryItemClaims: Rename DeliveryAddress to Recipient.
            migrationBuilder.RenameColumn(
                name: "DeliveryAddress",
                table: "RegistryItemClaims",
                newName: "Recipient"
            );
            
            // RegistryItemClaims: Remove PurchaseMethod column. Add ReceivedAt column.
            // It's important this is done before removing any purchase methods to avoid cascading deletion.
            // As we are using sqlite, we need to manually copy everything into a new table to remove columns
            migrationBuilder.CreateTable(
                name: "NewRegistryItemClaims",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "TEXT", nullable: false),
                    FulfillmentMethod = table.Column<int>(type: "INTEGER", nullable: true),
                    ClaimedBy = table.Column<string>(type: "TEXT", nullable: false),
                    Recipient = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimedAt = table.Column<int>(type: "INTEGER", nullable: false),
                    CompletedAt = table.Column<int>(type: "INTEGER", nullable: true),
                    ReceivedAt = table.Column<int>(type: "INTEGER", nullable: true),
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
                }
            );
            migrationBuilder.Sql(
                @"INSERT INTO NewRegistryItemClaims (ItemId, FulfillmentMethod, ClaimedBy, Recipient, ClaimedAt, CompletedAt, Quantity, Notes)
                SELECT ItemId, FulfillmentMethod, ClaimedBy, Recipient, ClaimedAt, CompletedAt, Quantity, Notes FROM RegistryItemClaims"
            );
            migrationBuilder.Sql(
                @"UPDATE NewRegistryItemClaims
                SET Recipient = NULL
                WHERE FulfillmentMethod = 0"
            );
            migrationBuilder.DropTable(
                name: "RegistryItemClaims"
            );
            migrationBuilder.RenameTable(
                name: "NewRegistryItemClaims",
                newName: "RegistryItemClaims"
            );
            
            // RegistryItems: Add columns Cost, AllowDeliverToUs, AllowBringOnDay, AllowMoneyTransfer.
            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "RegistryItems",
                type: "REAL",
                nullable: false,
                defaultValue: 0
            );
            migrationBuilder.AddColumn<bool>(
                name: "AllowDeliverToUs",
                table: "RegistryItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: true
            );
            migrationBuilder.AddColumn<bool>(
                name: "AllowBringOnDay",
                table: "RegistryItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: true
            );
            migrationBuilder.AddColumn<bool>(
                name: "AllowMoneyTransfer",
                table: "RegistryItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: true
            );
            
            // Copy data from the columns within the purchase methods to the registry items themselves.
            migrationBuilder.Sql(
                @"UPDATE RegistryItems
                SET Cost = (SELECT MIN(Cost + DeliveryCost) FROM RegistryItemPurchaseMethods WHERE RegistryItemPurchaseMethods.ItemId = RegistryItems.Id),
                    AllowDeliverToUs = (SELECT MAX(AllowDeliverToUs) FROM RegistryItemPurchaseMethods WHERE RegistryItemPurchaseMethods.ItemId = RegistryItems.Id),
                    AllowBringOnDay = (SELECT MAX(AllowBringOnDay) FROM RegistryItemPurchaseMethods WHERE RegistryItemPurchaseMethods.ItemId = RegistryItems.Id),
                    AllowMoneyTransfer = (SELECT MAX(CASE WHEN AllowDeliverToUs = 0 AND AllowBringOnDay = 0 THEN 1 ELSE 0 END) FROM RegistryItemPurchaseMethods WHERE RegistryItemPurchaseMethods.ItemId = RegistryItems.Id)"
            );
            
            // Remove "money transfer" purchase methods - these are built-in now.
            migrationBuilder.Sql(
                @"DELETE FROM RegistryItemPurchaseMethods
                WHERE AllowBringOnDay = 0 AND AllowDeliverToUs = 0 AND Url IS NULL AND Name = 'Money Transfer'"
            );
            
            // RegistryItemPurchaseMethods: Remove columns AllowDeliverToUs, AllowBringOnDay, Instructions.
            // As we are using sqlite, we need to manually copy everything into a new table to remove columns
            migrationBuilder.CreateTable(
                name: "NewRegistryItemPurchaseMethods",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ItemId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
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
            
            migrationBuilder.Sql(
                @"INSERT INTO NewRegistryItemPurchaseMethods (Id, ItemId, Name, Url, Cost, DeliveryCost)
                SELECT Id, ItemId, Name, Url, Cost, DeliveryCost
                FROM RegistryItemPurchaseMethods"
            );
            
            migrationBuilder.DropTable(
                name: "RegistryItemPurchaseMethods"
            );
            
            migrationBuilder.RenameTable(
                name: "NewRegistryItemPurchaseMethods",
                newName: "RegistryItemPurchaseMethods"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Warning: This migration is not fully reversible, and some data is lost when applying it.
            
            // RegistryItems: Create table early so that we can point the foreign keys to it.
            migrationBuilder.CreateTable(
                name: "OldRegistryItems",
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
            migrationBuilder.Sql(
                @"INSERT INTO OldRegistryItems (Id, GenericName, Name, Description, ImageUrl, MaxQuantity, Priority, Hide)
                SELECT Id, GenericName, Name, Description, ImageUrl, MaxQuantity, Priority, Hide FROM RegistryItems"
            );
            
            // ----------------------------
            // RegistryItemPurchaseMethods: Recreate removed columns
            // ----------------------------
            migrationBuilder.CreateTable(
                name: "OldRegistryItemPurchaseMethods",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ItemId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Cost = table.Column<double>(type: "REAL", nullable: false),
                    DeliveryCost = table.Column<double>(type: "REAL", nullable: false, defaultValue: 0),
                    AllowDeliverToUs = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    AllowBringOnDay = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    Instructions = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistryItemPurchaseMethods", x => x.Id);
                    table.ForeignKey(
                        "FK_RegistryItemPurchaseMethods_RegistryItems_ItemId",
                        x => x.ItemId,
                        "OldRegistryItems",
                        "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                });

            migrationBuilder.Sql(
                @"INSERT INTO OldRegistryItemPurchaseMethods 
                  (Id, ItemId, Name, Url, Cost, DeliveryCost, AllowDeliverToUs, AllowBringOnDay, Instructions)
                  SELECT 
                      Id, 
                      ItemId, 
                      Name, 
                      Url, 
                      Cost, 
                      DeliveryCost,
                      0, -- will recover later
                      0, -- will recover later
                      NULL
                  FROM RegistryItemPurchaseMethods"
            );
            
            // Recover AllowDeliverToUs and AllowBringOnDay using the settings for the item as a whole.
            migrationBuilder.Sql(
                @"UPDATE OldRegistryItemPurchaseMethods
                SET AllowDeliverToUs = (SELECT MAX(AllowDeliverToUs) FROM RegistryItems WHERE RegistryItems.Id = OldRegistryItemPurchaseMethods.ItemId),
                    AllowBringOnDay = (SELECT MAX(AllowBringOnDay) FROM RegistryItems WHERE RegistryItems.Id = OldRegistryItemPurchaseMethods.ItemId)"
            );

            migrationBuilder.DropTable(name: "RegistryItemPurchaseMethods");

            migrationBuilder.RenameTable(
                name: "OldRegistryItemPurchaseMethods",
                newName: "RegistryItemPurchaseMethods"
            );

            // Recreate "Money Transfer" purchase methods (approximation)
            migrationBuilder.Sql(
                @"INSERT INTO RegistryItemPurchaseMethods (Id, ItemId, Name, Url, Cost, DeliveryCost, AllowDeliverToUs, AllowBringOnDay, Instructions)
                  SELECT 
                      lower(hex(randomblob(16))),
                      Id,
                      'Money Transfer',
                      NULL,
                      Cost,
                      0,
                      0,
                      0,
                      NULL
                  FROM RegistryItems
                  WHERE AllowMoneyTransfer = 1"
            );

            // ----------------------------
            // RegistryItemClaims: Recreate old structure (with PurchaseMethod + DeliveryAddress)
            // ----------------------------
            migrationBuilder.CreateTable(
                name: "OldRegistryItemClaims",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimedBy = table.Column<string>(type: "TEXT", nullable: false),
                    PurchaseMethod = table.Column<string>(type: "TEXT", nullable: true),
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
                        "OldRegistryItems",
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
                }
            );

            // Copy data back and reconstruct DeliveryAddress from FulfillmentMethod
            migrationBuilder.Sql(
                @"INSERT INTO OldRegistryItemClaims 
                  (ItemId, ClaimedBy, PurchaseMethod, DeliveryAddress, ClaimedAt, CompletedAt, Quantity, Notes)
                  SELECT 
                      ItemId,
                      ClaimedBy,
                      NULL, -- this will be partially recovered later
                      CASE 
                          WHEN FulfillmentMethod = 0 THEN 'Bring it on the day'
                          WHEN FulfillmentMethod = 1 THEN Recipient
                      END,
                      ClaimedAt,
                      CompletedAt,
                      Quantity,
                      Notes
                  FROM RegistryItemClaims"
            );
            
            // If FulfillmentMethod is money transfer, set the purchase method to the id of the newly added money transfer purchase method
            migrationBuilder.Sql(
                @"UPDATE OldRegistryItemClaims
                SET PurchaseMethod = (SELECT Id FROM RegistryItemPurchaseMethods WHERE RegistryItemPurchaseMethods.ItemId = OldRegistryItemClaims.ItemId AND Name = 'Money Transfer' LIMIT 1)
                WHERE (SELECT FulfillmentMethod FROM RegistryItemClaims WHERE OldRegistryItemClaims.ItemId = RegistryItemClaims.ItemId AND OldRegistryItemClaims.ClaimedBy = RegistryItemClaims.ClaimedBy) = 2"
            );
            
            // If FulfillmentMethod is deliver to us or bring on day, set the purchase method to the id of the first non-money transfer purchase method for the item
            migrationBuilder.Sql(
                @"UPDATE OldRegistryItemClaims
                SET PurchaseMethod = (SELECT Id FROM RegistryItemPurchaseMethods WHERE RegistryItemPurchaseMethods.ItemId = OldRegistryItemClaims.ItemId AND Name != 'Money Transfer' LIMIT 1)
                WHERE (SELECT FulfillmentMethod FROM RegistryItemClaims WHERE OldRegistryItemClaims.ItemId = RegistryItemClaims.ItemId AND OldRegistryItemClaims.ClaimedBy = RegistryItemClaims.ClaimedBy) IN (0, 1)"
            );
            
            migrationBuilder.DropTable(name: "RegistryItemClaims");

            migrationBuilder.RenameTable(
                name: "OldRegistryItemClaims",
                newName: "RegistryItemClaims"
            );
            
            // ----------------------------
            // RegistryItems: Drop added columns
            // ----------------------------
            // We need to recreate the table to delete columns in sqlite
            // Table was created above to allow foreign keys to point to the new table
            migrationBuilder.DropTable(name: "RegistryItems");
            migrationBuilder.RenameTable(
                name: "OldRegistryItems",
                newName: "RegistryItems"
            );
        }
    }
}
