using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Changes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPages_BlogPageCategories_CategoryId",
                table: "BlogPages");

            migrationBuilder.DropForeignKey(
                name: "FK_CartPayings_Carts_CartId",
                table: "CartPayings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCart_Carts_CartId",
                table: "ProductsInCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCart_Products_ProductId",
                table: "ProductsInCart");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductsInCart",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "ProductsInCart",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "CartPayings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "BlogPages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "ff9838b4-b897-4b20-a8f1-5bec3716c12f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "26fd0fd8-5ac8-4a7a-b030-f8d9885565ed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "b9078ea9-832c-4e53-9438-7b09c79fcf89");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPages_BlogPageCategories_CategoryId",
                table: "BlogPages",
                column: "CategoryId",
                principalTable: "BlogPageCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartPayings_Carts_CartId",
                table: "CartPayings",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCart_Carts_CartId",
                table: "ProductsInCart",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCart_Products_ProductId",
                table: "ProductsInCart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPages_BlogPageCategories_CategoryId",
                table: "BlogPages");

            migrationBuilder.DropForeignKey(
                name: "FK_CartPayings_Carts_CartId",
                table: "CartPayings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCart_Carts_CartId",
                table: "ProductsInCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCart_Products_ProductId",
                table: "ProductsInCart");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductsInCart",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "ProductsInCart",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "CartPayings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "BlogPages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "7e184dac-4f9c-4517-9d50-3679dc03b37f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "1fa2ff25-1906-428d-bd83-a100fafa0c9f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "5ee85b91-4423-4769-a6d0-6ee16ca50771");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPages_BlogPageCategories_CategoryId",
                table: "BlogPages",
                column: "CategoryId",
                principalTable: "BlogPageCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartPayings_Carts_CartId",
                table: "CartPayings",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCart_Carts_CartId",
                table: "ProductsInCart",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCart_Products_ProductId",
                table: "ProductsInCart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
