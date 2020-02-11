using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeShop.Migrations
{
    public partial class ReceiptMovedToSalePaymentMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Receipt",
                table: "SaleProduct");

            migrationBuilder.AddColumn<string>(
                name: "Receipt",
                table: "SalePaymentMethodsRelation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Receipt",
                table: "SalePaymentMethodsRelation");

            migrationBuilder.AddColumn<string>(
                name: "Receipt",
                table: "SaleProduct",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
