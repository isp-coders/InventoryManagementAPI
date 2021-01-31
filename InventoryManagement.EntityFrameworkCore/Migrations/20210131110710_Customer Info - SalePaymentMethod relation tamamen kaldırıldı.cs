using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class CustomerInfoSalePaymentMethodrelationtamamenkaldırıldı : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerInfoId",
                table: "SalePaymentMethodsRelation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerInfoId",
                table: "SalePaymentMethodsRelation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
