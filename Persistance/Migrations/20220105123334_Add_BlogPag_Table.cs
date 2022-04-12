using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Add_BlogPag_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPageCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPageCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPageCategories_BlogPageCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "BlogPageCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlogPageKeywords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Display = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPageKeywords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductKeywords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Display = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductKeywords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitNumber = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPages_BlogPageCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BlogPageCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Keyword<Product>Product",
                columns: table => new
                {
                    KeywordsId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyword<Product>Product", x => new { x.KeywordsId, x.ParentId });
                    table.ForeignKey(
                        name: "FK_Keyword<Product>Product_ProductKeywords_KeywordsId",
                        column: x => x.KeywordsId,
                        principalTable: "ProductKeywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Keyword<Product>Product_Products_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogPageKeyword<BlogPage>",
                columns: table => new
                {
                    KeywordsId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPageKeyword<BlogPage>", x => new { x.KeywordsId, x.ParentId });
                    table.ForeignKey(
                        name: "FK_BlogPageKeyword<BlogPage>_BlogPageKeywords_KeywordsId",
                        column: x => x.KeywordsId,
                        principalTable: "BlogPageKeywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPageKeyword<BlogPage>_BlogPages_ParentId",
                        column: x => x.ParentId,
                        principalTable: "BlogPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPageCategories_ParentId",
                table: "BlogPageCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPageKeyword<BlogPage>_ParentId",
                table: "BlogPageKeyword<BlogPage>",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPages_CategoryId",
                table: "BlogPages",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Keyword<Product>Product_ParentId",
                table: "Keyword<Product>Product",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPageKeyword<BlogPage>");

            migrationBuilder.DropTable(
                name: "Keyword<Product>Product");

            migrationBuilder.DropTable(
                name: "BlogPageKeywords");

            migrationBuilder.DropTable(
                name: "BlogPages");

            migrationBuilder.DropTable(
                name: "ProductKeywords");

            migrationBuilder.DropTable(
                name: "BlogPageCategories");
        }
    }
}
