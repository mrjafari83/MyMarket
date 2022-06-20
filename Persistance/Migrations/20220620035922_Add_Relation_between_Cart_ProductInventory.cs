using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Add_Relation_between_Cart_ProductInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductsInCart");

            migrationBuilder.AddColumn<int>(
                name: "ProductInventoryAndPriceId",
                table: "ProductsInCart",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "d46a792f-c421-4469-92c0-12ce65a41071");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "73db3b88-8ea5-4fd3-96ff-49a42914dab7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "f6c9d431-e2f4-4381-8a1b-abaee570fe90");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInCart_ProductInventoryAndPriceId",
                table: "ProductsInCart",
                column: "ProductInventoryAndPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCart_ProductInventories_ProductInventoryAndPriceId",
                table: "ProductsInCart",
                column: "ProductInventoryAndPriceId",
                principalTable: "ProductInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCart_ProductInventories_ProductInventoryAndPriceId",
                table: "ProductsInCart");

            migrationBuilder.DropIndex(
                name: "IX_ProductsInCart_ProductInventoryAndPriceId",
                table: "ProductsInCart");

            migrationBuilder.DropColumn(
                name: "ProductInventoryAndPriceId",
                table: "ProductsInCart");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "ProductsInCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "8eb25db8-5b52-467f-94ab-00a6d90945fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "75e43ee1-6338-4648-9f7c-4bd4241c5cbf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "aeddfc6f-b33c-4aeb-b558-d123792857a6");
        }
    }
}
