using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Edit_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_SizeCategories_CategoryId",
                table: "ProductSizes");

            migrationBuilder.DropTable(
                name: "SizeCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductSizes_CategoryId",
                table: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductSizes");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductSizes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SizeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_CategoryId",
                table: "ProductSizes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_SizeCategories_CategoryId",
                table: "ProductSizes",
                column: "CategoryId",
                principalTable: "SizeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
