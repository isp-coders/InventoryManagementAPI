using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class SalePaymentMethodremovenullableId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalePaymentMethodsRelation_customerInfos_CustomerInfoId",
                table: "SalePaymentMethodsRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customerInfos",
                table: "customerInfos");

            migrationBuilder.RenameTable(
                name: "customerInfos",
                newName: "CustomerInfo");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerInfoId",
                table: "SalePaymentMethodsRelation",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerInfo",
                table: "CustomerInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalePaymentMethodsRelation_CustomerInfo_CustomerInfoId",
                table: "SalePaymentMethodsRelation",
                column: "CustomerInfoId",
                principalTable: "CustomerInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalePaymentMethodsRelation_CustomerInfo_CustomerInfoId",
                table: "SalePaymentMethodsRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerInfo",
                table: "CustomerInfo");

            migrationBuilder.RenameTable(
                name: "CustomerInfo",
                newName: "customerInfos");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerInfoId",
                table: "SalePaymentMethodsRelation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_customerInfos",
                table: "customerInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalePaymentMethodsRelation_customerInfos_CustomerInfoId",
                table: "SalePaymentMethodsRelation",
                column: "CustomerInfoId",
                principalTable: "customerInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
