using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeShop.Migrations
{
    public partial class SalePaymentMethodAmountAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "SalePaymentMethodsRelation",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "SalePaymentMethodsRelation");
        }
    }
}
