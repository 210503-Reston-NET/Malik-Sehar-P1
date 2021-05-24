using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SDL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PhoneNo = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StoreId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Total = table.Column<double>(type: "double precision", nullable: false),
                    CustID = table.Column<int>(type: "integer", nullable: false),
                    LocationID = table.Column<int>(type: "integer", nullable: false),
                    storeFrontsId = table.Column<int>(type: "integer", nullable: true),
                    customerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    MInventoryId = table.Column<int>(type: "integer", nullable: true),
                    MLineItemsId = table.Column<int>(type: "integer", nullable: true),
                    MProductBarcode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Inventories_MInventoryId",
                        column: x => x.MInventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Barcode = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    MInventoryId = table.Column<int>(type: "integer", nullable: true),
                    MLineItemsId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Barcode);
                    table.ForeignKey(
                        name: "FK_Products_Inventories_MInventoryId",
                        column: x => x.MInventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProId = table.Column<string>(type: "text", nullable: true),
                    OrderID = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    productBarcode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItems_Products_productBarcode",
                        column: x => x.productBarcode,
                        principalTable: "Products",
                        principalColumn: "Barcode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MLineItemsMOrders",
                columns: table => new
                {
                    lineItemsId = table.Column<int>(type: "integer", nullable: false),
                    ordersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MLineItemsMOrders", x => new { x.lineItemsId, x.ordersId });
                    table.ForeignKey(
                        name: "FK_MLineItemsMOrders_LineItems_lineItemsId",
                        column: x => x.lineItemsId,
                        principalTable: "LineItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MLineItemsMOrders_Orders_ordersId",
                        column: x => x.ordersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_productBarcode",
                table: "LineItems",
                column: "productBarcode");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_MInventoryId",
                table: "Locations",
                column: "MInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_MLineItemsId",
                table: "Locations",
                column: "MLineItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_MProductBarcode",
                table: "Locations",
                column: "MProductBarcode");

            migrationBuilder.CreateIndex(
                name: "IX_MLineItemsMOrders_ordersId",
                table: "MLineItemsMOrders",
                column: "ordersId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customerId",
                table: "Orders",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_storeFrontsId",
                table: "Orders",
                column: "storeFrontsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MInventoryId",
                table: "Products",
                column: "MInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MLineItemsId",
                table: "Products",
                column: "MLineItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Locations_storeFrontsId",
                table: "Orders",
                column: "storeFrontsId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_LineItems_MLineItemsId",
                table: "Locations",
                column: "MLineItemsId",
                principalTable: "LineItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Products_MProductBarcode",
                table: "Locations",
                column: "MProductBarcode",
                principalTable: "Products",
                principalColumn: "Barcode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_LineItems_MLineItemsId",
                table: "Products",
                column: "MLineItemsId",
                principalTable: "LineItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_productBarcode",
                table: "LineItems");

            migrationBuilder.DropTable(
                name: "MLineItemsMOrders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "LineItems");
        }
    }
}
