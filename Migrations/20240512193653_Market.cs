using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pasar_Maya_Api.Migrations
{
    /// <inheritdoc />
    public partial class Market : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Markets_AspNetUsers_UserId",
                table: "Markets");

            migrationBuilder.DropIndex(
                name: "IX_Markets_UserId",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Markets");

            migrationBuilder.AddColumn<int>(
                name: "MarketId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MarketId",
                table: "AspNetUsers",
                column: "MarketId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Markets_MarketId",
                table: "AspNetUsers",
                column: "MarketId",
                principalTable: "Markets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Markets_MarketId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MarketId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MarketId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Markets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_UserId",
                table: "Markets",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Markets_AspNetUsers_UserId",
                table: "Markets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
