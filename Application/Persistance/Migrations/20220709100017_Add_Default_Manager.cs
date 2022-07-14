using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Persistance.Migrations
{
    public partial class Add_Default_Manager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "03cb33b7-3127-4200-ba5d-e2789b75238e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "0e641184-6fa8-4d0c-873e-45c8b6c911fb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "c553d5d5-87f9-4e98-82cc-abd2ca30c9e0");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Family", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageSrc", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "07f71df4-68f8-4a4f-86da-875e9aacf7c7", 0, "7fff2107-c92b-4664-9117-5295aabe494b", null, false, null, false, null, null, null, null, null, null, false, "/Images/DefaultUser.jpg", "10ed54dd-a87a-4807-9d34-e4a73bdc1279", false, "Management" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "07f71df4-68f8-4a4f-86da-875e9aacf7c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "4909d4ba-1a6b-4972-9af6-f518371b7c59");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "079df04b-18e2-42fa-97b0-dfe95eadcd93");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "43b16434-a0eb-4efc-9feb-d8ee8e894df6");
        }
    }
}
