using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pasar_Maya_Api.Migrations
{
    /// <inheritdoc />
    public partial class updatecartProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CartsProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CartsProducts");
        }
    }
}
