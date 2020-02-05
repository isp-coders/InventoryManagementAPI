using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeShop.Migrations
{
    public partial class salepaymentmethodtablecountadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "SalePaymentMethod",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "SalePaymentMethod");
        }
    }
}
