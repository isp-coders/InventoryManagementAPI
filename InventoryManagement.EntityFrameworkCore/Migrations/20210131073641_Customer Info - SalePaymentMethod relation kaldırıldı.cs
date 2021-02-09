using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class CustomerInfoSalePaymentMethodrelationkaldırıldı : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalePaymentMethodsRelation_CustomerInfo_CustomerInfoId",
                table: "SalePaymentMethodsRelation");

            migrationBuilder.DropIndex(
                name: "IX_SalePaymentMethodsRelation_CustomerInfoId",
                table: "SalePaymentMethodsRelation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SalePaymentMethodsRelation_CustomerInfoId",
                table: "SalePaymentMethodsRelation",
                column: "CustomerInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalePaymentMethodsRelation_CustomerInfo_CustomerInfoId",
                table: "SalePaymentMethodsRelation",
                column: "CustomerInfoId",
                principalTable: "CustomerInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
