using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Edit_Keywords_Feature_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPages_Keyword<BlogPage>_Keyword<BlogPage>Id",
                table: "BlogPages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Keyword<Product>_Keyword<Product>Id",
                table: "Products");

            migrationBuilder.DropTable(
                name: "FeaturesInProducts");

            migrationBuilder.DropTable(
                name: "KeywordsInBlogPages");

            migrationBuilder.DropTable(
                name: "KeywordsInProducts");

            migrationBuilder.DropTable(
                name: "BlogPageKeywords");

            migrationBuilder.DropTable(
                name: "ProductKeywords");

            migrationBuilder.DropIndex(
                name: "IX_Products_Keyword<Product>Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_BlogPages_Keyword<BlogPage>Id",
                table: "BlogPages");

            migrationBuilder.DropColumn(
                name: "Keyword<Product>Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Keyword<BlogPage>Id",
                table: "BlogPages");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductFutures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Keyword<Product>",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Keyword<BlogPage>",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductFutures_ProductId",
                table: "ProductFutures",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Keyword<Product>_ParentId",
                table: "Keyword<Product>",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Keyword<BlogPage>_ParentId",
                table: "Keyword<BlogPage>",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Keyword<BlogPage>_BlogPages_ParentId",
                table: "Keyword<BlogPage>",
                column: "ParentId",
                principalTable: "BlogPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Keyword<Product>_Products_ParentId",
                table: "Keyword<Product>",
                column: "ParentId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFutures_Products_ProductId",
                table: "ProductFutures",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keyword<BlogPage>_BlogPages_ParentId",
                table: "Keyword<BlogPage>");

            migrationBuilder.DropForeignKey(
                name: "FK_Keyword<Product>_Products_ParentId",
                table: "Keyword<Product>");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFutures_Products_ProductId",
                table: "ProductFutures");

            migrationBuilder.DropIndex(
                name: "IX_ProductFutures_ProductId",
                table: "ProductFutures");

            migrationBuilder.DropIndex(
                name: "IX_Keyword<Product>_ParentId",
                table: "Keyword<Product>");

            migrationBuilder.DropIndex(
                name: "IX_Keyword<BlogPage>_ParentId",
                table: "Keyword<BlogPage>");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductFutures");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Keyword<Product>");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Keyword<BlogPage>");

            migrationBuilder.AddColumn<int>(
                name: "Keyword<Product>Id",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Keyword<BlogPage>Id",
                table: "BlogPages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BlogPageKeywords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPageKeywords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeaturesInProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturesInProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeaturesInProducts_ProductFutures_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "ProductFutures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FeaturesInProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductKeywords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductKeywords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeywordsInBlogPages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogPageId = table.Column<int>(type: "int", nullable: true),
                    KeywordKeywordInBlogPageId = table.Column<int>(name: "Keyword<KeywordInBlogPage>Id", type: "int", nullable: true),
                    KeywordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordsInBlogPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeywordsInBlogPages_BlogPageKeywords_Keyword<KeywordInBlogPage>Id",
                        column: x => x.KeywordKeywordInBlogPageId,
                        principalTable: "BlogPageKeywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KeywordsInBlogPages_BlogPages_BlogPageId",
                        column: x => x.BlogPageId,
                        principalTable: "BlogPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KeywordsInBlogPages_Keyword<BlogPage>_KeywordId",
                        column: x => x.KeywordId,
                        principalTable: "Keyword<BlogPage>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KeywordsInProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeywordKeywordInProductId = table.Column<int>(name: "Keyword<KeywordInProduct>Id", type: "int", nullable: true),
                    KeywordId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordsInProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeywordsInProducts_Keyword<Product>_KeywordId",
                        column: x => x.KeywordId,
                        principalTable: "Keyword<Product>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KeywordsInProducts_ProductKeywords_Keyword<KeywordInProduct>Id",
                        column: x => x.KeywordKeywordInProductId,
                        principalTable: "ProductKeywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KeywordsInProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Keyword<Product>Id",
                table: "Products",
                column: "Keyword<Product>Id");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPages_Keyword<BlogPage>Id",
                table: "BlogPages",
                column: "Keyword<BlogPage>Id");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturesInProducts_FeatureId",
                table: "FeaturesInProducts",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturesInProducts_ProductId",
                table: "FeaturesInProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordsInBlogPages_BlogPageId",
                table: "KeywordsInBlogPages",
                column: "BlogPageId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordsInBlogPages_Keyword<KeywordInBlogPage>Id",
                table: "KeywordsInBlogPages",
                column: "Keyword<KeywordInBlogPage>Id");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordsInBlogPages_KeywordId",
                table: "KeywordsInBlogPages",
                column: "KeywordId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordsInProducts_Keyword<KeywordInProduct>Id",
                table: "KeywordsInProducts",
                column: "Keyword<KeywordInProduct>Id");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordsInProducts_KeywordId",
                table: "KeywordsInProducts",
                column: "KeywordId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordsInProducts_ProductId",
                table: "KeywordsInProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPages_Keyword<BlogPage>_Keyword<BlogPage>Id",
                table: "BlogPages",
                column: "Keyword<BlogPage>Id",
                principalTable: "Keyword<BlogPage>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Keyword<Product>_Keyword<Product>Id",
                table: "Products",
                column: "Keyword<Product>Id",
                principalTable: "Keyword<Product>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
