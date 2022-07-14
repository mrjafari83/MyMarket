using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class Merge_SearchFilter_ExcelStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcelStatuses");

            migrationBuilder.DropTable(
                name: "SearchFilter");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32febe0e-5fde-4deb-ab41-d8c056347cfa");

            migrationBuilder.CreateTable(
                name: "Excels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilterJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SearchType = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excels", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "ae58f704-364e-48b0-bd77-abe01df76018");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "2215e0dd-7436-4115-a7c3-bc9174099ba6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "d6cee633-4b67-4649-8904-f14dcd6b1145");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Family", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageSrc", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b197700a-efa4-453e-92b1-53659b8c49bb", 0, "6e964821-f5f1-46e3-8048-0371788804a4", null, false, null, false, null, null, null, null, "AQAAAAEAACcQAAAAEOeY3MRi9YetlUXcs10LY6ijsvl9KOBXk8hCPhOcHYeEdNHcjCWgoR2awxfbbypTSg==", null, false, "/Images/DefaultUser.jpg", "b744dc1f-d33f-424f-b251-8b0eea42c14e", false, "Management" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Excels");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b197700a-efa4-453e-92b1-53659b8c49bb");

            migrationBuilder.CreateTable(
                name: "SearchFilter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilterJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SearchType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchFilter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExcelStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchFilterId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcelStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExcelStatuses_SearchFilter_SearchFilterId",
                        column: x => x.SearchFilterId,
                        principalTable: "SearchFilter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "7f05f455-cec3-414e-b27e-df10b094328f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "57d3333d-51bf-4aa6-86bb-784c563f8f30");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "59842727-6311-4ebe-a0d6-5ae63795f95d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Family", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageSrc", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "32febe0e-5fde-4deb-ab41-d8c056347cfa", 0, "b7c6eee0-bd15-4f51-bdc5-aa93292855d4", null, false, null, false, null, null, null, null, "AQAAAAEAACcQAAAAEOeY3MRi9YetlUXcs10LY6ijsvl9KOBXk8hCPhOcHYeEdNHcjCWgoR2awxfbbypTSg==", null, false, "/Images/DefaultUser.jpg", "3c3873cc-4ee3-49a4-8eac-b8160434b98b", false, "Management" });

            migrationBuilder.CreateIndex(
                name: "IX_ExcelStatuses_SearchFilterId",
                table: "ExcelStatuses",
                column: "SearchFilterId");
        }
    }
}
