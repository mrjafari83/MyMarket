using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Edit_Slider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sliders_Products_ProductId",
                table: "Sliders");

            migrationBuilder.DropIndex(
                name: "IX_Sliders_ProductId",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Sliders");

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "9a150e88-70b4-413f-a3c5-e78a81800069");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "e884c611-33f6-4e73-a2ab-094c37bf0c49");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "a89d9097-28fe-4f44-9f22-2981e9eb342d");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Sliders");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Sliders",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "55f1f2f7-d390-4a4e-b7e7-af251f672019");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "67c42dbb-c77f-4075-b8f9-a1cc7391e148");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "2758e7b1-b57a-410e-85b4-32ade1c4d4bd");

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_ProductId",
                table: "Sliders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sliders_Products_ProductId",
                table: "Sliders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
