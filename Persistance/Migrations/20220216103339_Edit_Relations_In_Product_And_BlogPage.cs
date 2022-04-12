using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Edit_Relations_In_Product_And_BlogPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPageKeyword<BlogPage>");

            migrationBuilder.DropTable(
                name: "Keyword<Product>Product");

            migrationBuilder.DropTable(
                name: "ProductProductColor");

            migrationBuilder.DropTable(
                name: "ProductProductFuture");

            migrationBuilder.DropTable(
                name: "ProductProductSize");

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
                name: "ColorsInProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorsInProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorsInProducts_ProductColors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "ProductColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColorsInProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeaturesInProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    FeatureId = table.Column<int>(type: "int", nullable: true)
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
                name: "Keyword<BlogPage>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyword<BlogPage>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keyword<Product>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyword<Product>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SizesInProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizesInProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizesInProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SizesInProducts_ProductSizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "ProductSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KeywordsInBlogPages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogPageId = table.Column<int>(type: "int", nullable: true),
                    KeywordId = table.Column<int>(type: "int", nullable: true),
                    KeywordKeywordInBlogPageId = table.Column<int>(name: "Keyword<KeywordInBlogPage>Id", type: "int", nullable: true)
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
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    KeywordId = table.Column<int>(type: "int", nullable: true),
                    KeywordKeywordInProductId = table.Column<int>(name: "Keyword<KeywordInProduct>Id", type: "int", nullable: true)
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
                name: "IX_ColorsInProducts_ColorId",
                table: "ColorsInProducts",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorsInProducts_ProductId",
                table: "ColorsInProducts",
                column: "ProductId");

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

            migrationBuilder.CreateIndex(
                name: "IX_SizesInProducts_ProductId",
                table: "SizesInProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SizesInProducts_SizeId",
                table: "SizesInProducts",
                column: "SizeId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPages_Keyword<BlogPage>_Keyword<BlogPage>Id",
                table: "BlogPages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Keyword<Product>_Keyword<Product>Id",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ColorsInProducts");

            migrationBuilder.DropTable(
                name: "FeaturesInProducts");

            migrationBuilder.DropTable(
                name: "KeywordsInBlogPages");

            migrationBuilder.DropTable(
                name: "KeywordsInProducts");

            migrationBuilder.DropTable(
                name: "SizesInProducts");

            migrationBuilder.DropTable(
                name: "Keyword<BlogPage>");

            migrationBuilder.DropTable(
                name: "Keyword<Product>");

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
                name: "ProductProductColor",
                columns: table => new
                {
                    ProductColorsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductColor", x => new { x.ProductColorsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductProductColor_ProductColors_ProductColorsId",
                        column: x => x.ProductColorsId,
                        principalTable: "ProductColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductColor_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductFuture",
                columns: table => new
                {
                    ProductFuturesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductFuture", x => new { x.ProductFuturesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductProductFuture_ProductFutures_ProductFuturesId",
                        column: x => x.ProductFuturesId,
                        principalTable: "ProductFutures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductFuture_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductSize",
                columns: table => new
                {
                    ProductSizesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductSize", x => new { x.ProductSizesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductProductSize_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductSize_ProductSizes_ProductSizesId",
                        column: x => x.ProductSizesId,
                        principalTable: "ProductSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPageKeyword<BlogPage>_ParentId",
                table: "BlogPageKeyword<BlogPage>",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Keyword<Product>Product_ParentId",
                table: "Keyword<Product>Product",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductColor_ProductsId",
                table: "ProductProductColor",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductFuture_ProductsId",
                table: "ProductProductFuture",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductSize_ProductsId",
                table: "ProductProductSize",
                column: "ProductsId");
        }
    }
}
