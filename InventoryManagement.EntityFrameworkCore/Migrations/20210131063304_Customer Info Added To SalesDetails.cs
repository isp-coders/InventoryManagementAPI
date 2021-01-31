using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class CustomerInfoAddedToSalesDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerInfoId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerInfoId",
                table: "Sales",
                column: "CustomerInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_CustomerInfo_CustomerInfoId",
                table: "Sales",
                column: "CustomerInfoId",
                principalTable: "CustomerInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_CustomerInfo_CustomerInfoId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CustomerInfoId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CustomerInfoId",
                table: "Sales");
        }
    }
}
