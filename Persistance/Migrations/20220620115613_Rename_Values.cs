using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Rename_Values : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KeywordValue",
                table: "ProductKeywords",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ProductFutures",
                newName: "FeatureValue");

            migrationBuilder.RenameColumn(
                name: "KeywordValue",
                table: "BlogKeywords",
                newName: "Value");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "74bae673-b6ca-439f-b820-d074a1bfe10a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "3b5fc3fc-8be6-4731-a309-5d3c455806e4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "fbafe709-c371-42f5-a46d-ccee07836a15");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ProductKeywords",
                newName: "KeywordValue");

            migrationBuilder.RenameColumn(
                name: "FeatureValue",
                table: "ProductFutures",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "BlogKeywords",
                newName: "KeywordValue");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "3a29fe0e-80c4-45f3-810b-f9d7853b6160");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "8d0be5d9-9b8f-423e-b984-39637c23556c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "0b2c7500-145e-4ae7-8402-d0ae81cdb4e7");
        }
    }
}
