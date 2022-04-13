using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Add_Products_In_CartPayingInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartPayingInfoId",
                table: "ProductsInCart",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInCart_CartPayingInfoId",
                table: "ProductsInCart",
                column: "CartPayingInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCart_CartPayings_CartPayingInfoId",
                table: "ProductsInCart",
                column: "CartPayingInfoId",
                principalTable: "CartPayings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCart_CartPayings_CartPayingInfoId",
                table: "ProductsInCart");

            migrationBuilder.DropIndex(
                name: "IX_ProductsInCart_CartPayingInfoId",
                table: "ProductsInCart");

            migrationBuilder.DropColumn(
                name: "CartPayingInfoId",
                table: "ProductsInCart");
        }
    }
}
