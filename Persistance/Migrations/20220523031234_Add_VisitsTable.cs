using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Add_VisitsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitNumber",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Browsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrowserCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Browsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPagesVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrowserId = table.Column<int>(type: "int", nullable: true),
                    BlogPageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPagesVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPagesVisits_BlogPages_BlogPageId",
                        column: x => x.BlogPageId,
                        principalTable: "BlogPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlogPagesVisits_Browsers_BrowserId",
                        column: x => x.BrowserId,
                        principalTable: "Browsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductsVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrowserId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsVisits_Browsers_BrowserId",
                        column: x => x.BrowserId,
                        principalTable: "Browsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsVisits_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "bc17e9b3-9cb4-418a-b082-81a255eab8dc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "cf23dbcb-7b62-432a-9cdf-0d07e47e98ed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "7f639d33-c0cf-4899-aa4c-244636618b24");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPagesVisits_BlogPageId",
                table: "BlogPagesVisits",
                column: "BlogPageId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPagesVisits_BrowserId",
                table: "BlogPagesVisits",
                column: "BrowserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsVisits_BrowserId",
                table: "ProductsVisits",
                column: "BrowserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsVisits_ProductId",
                table: "ProductsVisits",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPagesVisits");

            migrationBuilder.DropTable(
                name: "ProductsVisits");

            migrationBuilder.DropTable(
                name: "Browsers");

            migrationBuilder.AddColumn<int>(
                name: "VisitNumber",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "f9789ca0-07bf-492b-a4ca-6a0c83a992d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Customer",
                column: "ConcurrencyStamp",
                value: "7c0e6be0-ce39-40b2-b334-0848d7a0c717");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Owner",
                column: "ConcurrencyStamp",
                value: "cf5a2101-1516-46dc-955a-a0f2bd2dd6be");
        }
    }
}
