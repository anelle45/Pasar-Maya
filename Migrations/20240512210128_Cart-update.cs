using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pasar_Maya_Api.Migrations
{
    /// <inheritdoc />
    public partial class Cartupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_userId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carts_Cartid",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Cartid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Cartid",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "CartsProducts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartsProducts", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartsProducts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartsProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartsProducts_ProductId",
                table: "CartsProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_userId",
                table: "Carts",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_userId",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "CartsProducts");

            migrationBuilder.AddColumn<int>(
                name: "Cartid",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Cartid",
                table: "Products",
                column: "Cartid");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_userId",
                table: "Carts",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Carts_Cartid",
                table: "Products",
                column: "Cartid",
                principalTable: "Carts",
                principalColumn: "id");
        }
    }
}
