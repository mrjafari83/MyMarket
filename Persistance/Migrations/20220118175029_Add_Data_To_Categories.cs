using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Add_Data_To_Categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BlogPageCategories",
                columns: new[] { "Id", "IsParent", "IsRemoved", "Name", "ParentId", "RemoveTime" },
                values: new object[] { 1383, true, false, "بدون دسته بندی", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPageCategories",
                keyColumn: "Id",
                keyValue: 1383);
        }
    }
}
