using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Add_Keywords_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keyword<BlogPage>_BlogPages_ParentId",
                table: "Keyword<BlogPage>");

            migrationBuilder.DropForeignKey(
                name: "FK_Keyword<Product>_Products_ParentId",
                table: "Keyword<Product>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Keyword<Product>",
                table: "Keyword<Product>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Keyword<BlogPage>",
                table: "Keyword<BlogPage>");

            migrationBuilder.RenameTable(
                name: "Keyword<Product>",
                newName: "ProductKeywords");

            migrationBuilder.RenameTable(
                name: "Keyword<BlogPage>",
                newName: "BlogKeywords");

            migrationBuilder.RenameIndex(
                name: "IX_Keyword<Product>_ParentId",
                table: "ProductKeywords",
                newName: "IX_ProductKeywords_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Keyword<BlogPage>_ParentId",
                table: "BlogKeywords",
                newName: "IX_BlogKeywords_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductKeywords",
                table: "ProductKeywords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogKeywords",
                table: "BlogKeywords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogKeywords_BlogPages_ParentId",
                table: "BlogKeywords",
                column: "ParentId",
                principalTable: "BlogPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductKeywords_Products_ParentId",
                table: "ProductKeywords",
                column: "ParentId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogKeywords_BlogPages_ParentId",
                table: "BlogKeywords");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductKeywords_Products_ParentId",
                table: "ProductKeywords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductKeywords",
                table: "ProductKeywords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogKeywords",
                table: "BlogKeywords");

            migrationBuilder.RenameTable(
                name: "ProductKeywords",
                newName: "Keyword<Product>");

            migrationBuilder.RenameTable(
                name: "BlogKeywords",
                newName: "Keyword<BlogPage>");

            migrationBuilder.RenameIndex(
                name: "IX_ProductKeywords_ParentId",
                table: "Keyword<Product>",
                newName: "IX_Keyword<Product>_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogKeywords_ParentId",
                table: "Keyword<BlogPage>",
                newName: "IX_Keyword<BlogPage>_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Keyword<Product>",
                table: "Keyword<Product>",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Keyword<BlogPage>",
                table: "Keyword<BlogPage>",
                column: "Id");

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
        }
    }
}
