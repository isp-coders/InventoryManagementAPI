using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class RevertconvertSalestabletoSaleDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRefundedOrChanged",
                table: "SaleDetailsAndProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRefundedOrChanged",
                table: "SaleDetailsAndProduct",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
