using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Add_InvntoyAndPrice_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventory_Products_ProductId",
                table: "ProductInventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInventory",
                table: "ProductInventory");

            migrationBuilder.RenameTable(
                name: "ProductInventory",
                newName: "ProductInventories");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInventory_ProductId",
                table: "ProductInventories",
                newName: "IX_ProductInventories_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInventories",
                table: "ProductInventories",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "689ef6f1-d18c-40fb-b287-12d7fcb3836b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "a4e3bb76-8f43-482b-a4e5-ab3bca8698f9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "be32e166-fa42-4e11-b734-72970ecd125b");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventories_Products_ProductId",
                table: "ProductInventories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventories_Products_ProductId",
                table: "ProductInventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInventories",
                table: "ProductInventories");

            migrationBuilder.RenameTable(
                name: "ProductInventories",
                newName: "ProductInventory");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInventories_ProductId",
                table: "ProductInventory",
                newName: "IX_ProductInventory_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInventory",
                table: "ProductInventory",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "7b26d7e2-8443-4a8b-aa6a-f71a34806861");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "fc772edf-af87-44e2-a874-311efeedb3d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "8cb5fe09-6b66-422e-963e-44740ed2510c");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventory_Products_ProductId",
                table: "ProductInventory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
