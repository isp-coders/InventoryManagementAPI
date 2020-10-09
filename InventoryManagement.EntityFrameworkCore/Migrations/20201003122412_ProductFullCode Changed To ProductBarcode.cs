using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class ProductFullCodeChangedToProductBarcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductFullCode",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ProductBarcode",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductBarcode",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ProductFullCode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
