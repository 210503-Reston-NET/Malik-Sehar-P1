using Microsoft.EntityFrameworkCore.Migrations;

namespace SDL.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_LineItems_MLineItemsId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "MLineItemsMOrders");

            migrationBuilder.DropIndex(
                name: "IX_Locations_MLineItemsId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "MLineItemsId",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "customerId",
                table: "LineItems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "locationsId",
                table: "LineItems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ordersId",
                table: "LineItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_customerId",
                table: "LineItems",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_locationsId",
                table: "LineItems",
                column: "locationsId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_ordersId",
                table: "LineItems",
                column: "ordersId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Customers_customerId",
                table: "LineItems",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Locations_locationsId",
                table: "LineItems",
                column: "locationsId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Orders_ordersId",
                table: "LineItems",
                column: "ordersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Customers_customerId",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Locations_locationsId",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Orders_ordersId",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_customerId",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_locationsId",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_ordersId",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "locationsId",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "ordersId",
                table: "LineItems");

            migrationBuilder.AddColumn<int>(
                name: "MLineItemsId",
                table: "Locations",
                type: "integer",
                nullable: true);

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
                name: "IX_Locations_MLineItemsId",
                table: "Locations",
                column: "MLineItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_MLineItemsMOrders_ordersId",
                table: "MLineItemsMOrders",
                column: "ordersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_LineItems_MLineItemsId",
                table: "Locations",
                column: "MLineItemsId",
                principalTable: "LineItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
