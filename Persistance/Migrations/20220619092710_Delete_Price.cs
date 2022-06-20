using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Delete_Price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "ProductInventory",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "ProductInventory",
                newName: "Inventory");

            migrationBuilder.AddColumn<string>(
                name: "ColorName",
                table: "ProductInventory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                table: "ProductInventory",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorName",
                table: "ProductInventory");

            migrationBuilder.DropColumn(
                name: "SizeName",
                table: "ProductInventory");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ProductInventory",
                newName: "SizeId");

            migrationBuilder.RenameColumn(
                name: "Inventory",
                table: "ProductInventory",
                newName: "ColorId");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "5bbcb296-da17-49a7-b9d6-8a5cf8f0b45d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "9f783cb0-615e-4792-8962-fb4af646192c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "65091e60-ba3c-4e22-ba3c-6a4e044a0da9");
        }
    }
}
