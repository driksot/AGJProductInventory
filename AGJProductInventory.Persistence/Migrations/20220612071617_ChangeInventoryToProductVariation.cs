using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGJProductInventory.Persistence.Migrations
{
    public partial class ChangeInventoryToProductVariation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventories_Products_ProductId",
                table: "ProductInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventorySnapshots_Products_ProductId",
                table: "ProductInventorySnapshots");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductInventorySnapshots",
                newName: "ProductVariationId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInventorySnapshots_ProductId",
                table: "ProductInventorySnapshots",
                newName: "IX_ProductInventorySnapshots_ProductVariationId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductInventories",
                newName: "ProductVariationId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInventories_ProductId",
                table: "ProductInventories",
                newName: "IX_ProductInventories_ProductVariationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventories_ProductVariations_ProductVariationId",
                table: "ProductInventories",
                column: "ProductVariationId",
                principalTable: "ProductVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventorySnapshots_ProductVariations_ProductVariationId",
                table: "ProductInventorySnapshots",
                column: "ProductVariationId",
                principalTable: "ProductVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventories_ProductVariations_ProductVariationId",
                table: "ProductInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventorySnapshots_ProductVariations_ProductVariationId",
                table: "ProductInventorySnapshots");

            migrationBuilder.RenameColumn(
                name: "ProductVariationId",
                table: "ProductInventorySnapshots",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInventorySnapshots_ProductVariationId",
                table: "ProductInventorySnapshots",
                newName: "IX_ProductInventorySnapshots_ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductVariationId",
                table: "ProductInventories",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInventories_ProductVariationId",
                table: "ProductInventories",
                newName: "IX_ProductInventories_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventories_Products_ProductId",
                table: "ProductInventories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventorySnapshots_Products_ProductId",
                table: "ProductInventorySnapshots",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
