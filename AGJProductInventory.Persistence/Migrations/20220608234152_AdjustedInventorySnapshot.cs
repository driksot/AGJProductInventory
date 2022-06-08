using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGJProductInventory.Persistence.Migrations
{
    public partial class AdjustedInventorySnapshot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventorySnapshots_ProductInventories_ProductInventoryId",
                table: "ProductInventorySnapshots");

            migrationBuilder.DropIndex(
                name: "IX_ProductInventorySnapshots_ProductInventoryId",
                table: "ProductInventorySnapshots");

            migrationBuilder.RenameColumn(
                name: "ProductInventoryId",
                table: "ProductInventorySnapshots",
                newName: "QuantityOnHand");

            migrationBuilder.RenameColumn(
                name: "InventoryId",
                table: "ProductInventorySnapshots",
                newName: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventorySnapshots_ProductId",
                table: "ProductInventorySnapshots",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventorySnapshots_Products_ProductId",
                table: "ProductInventorySnapshots",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventorySnapshots_Products_ProductId",
                table: "ProductInventorySnapshots");

            migrationBuilder.DropIndex(
                name: "IX_ProductInventorySnapshots_ProductId",
                table: "ProductInventorySnapshots");

            migrationBuilder.RenameColumn(
                name: "QuantityOnHand",
                table: "ProductInventorySnapshots",
                newName: "ProductInventoryId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductInventorySnapshots",
                newName: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventorySnapshots_ProductInventoryId",
                table: "ProductInventorySnapshots",
                column: "ProductInventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventorySnapshots_ProductInventories_ProductInventoryId",
                table: "ProductInventorySnapshots",
                column: "ProductInventoryId",
                principalTable: "ProductInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
