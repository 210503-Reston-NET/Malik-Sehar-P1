using Microsoft.EntityFrameworkCore.Migrations;

namespace SDL.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductsBarcode",
                table: "Inventories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreFrontId",
                table: "Inventories",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ProductsBarcode",
                table: "Inventories",
                column: "ProductsBarcode");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_StoreFrontId",
                table: "Inventories",
                column: "StoreFrontId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Locations_StoreFrontId",
                table: "Inventories",
                column: "StoreFrontId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Products_ProductsBarcode",
                table: "Inventories",
                column: "ProductsBarcode",
                principalTable: "Products",
                principalColumn: "Barcode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Locations_StoreFrontId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Products_ProductsBarcode",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_ProductsBarcode",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_StoreFrontId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ProductsBarcode",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "StoreFrontId",
                table: "Inventories");
        }
    }
}
