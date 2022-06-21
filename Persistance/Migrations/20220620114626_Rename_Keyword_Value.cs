using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Rename_Keyword_Value : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ProductKeywords",
                newName: "KeywordValue");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KeywordValue",
                table: "ProductKeywords",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "KeywordValue",
                table: "BlogKeywords",
                newName: "Value");

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
        }
    }
}
