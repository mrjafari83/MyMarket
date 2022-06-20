using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Add_New_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "3c02f105-75c6-4a1e-ba19-9715833d6d8d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "9fcae411-cd9a-45c8-bccf-e27567887244");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "62485980-dab2-408b-94c7-ef3235747162");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
