using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeShop.Migrations
{
    public partial class BranchShoeSaleRelationReverese : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Sales_SaleId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Shoes_ShoeId",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_SaleId",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_ShoeId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "ShoeId",
                table: "Branches");

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Shoes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Sales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_BranchId",
                table: "Shoes",
                column: "BranchId",
                unique: true,
                filter: "[BranchId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BranchId",
                table: "Sales",
                column: "BranchId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Branches_BranchId",
                table: "Sales",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Branches_BranchId",
                table: "Shoes",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Branches_BranchId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Branches_BranchId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_BranchId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Sales_BranchId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShoeId",
                table: "Branches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_SaleId",
                table: "Branches",
                column: "SaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ShoeId",
                table: "Branches",
                column: "ShoeId",
                unique: true,
                filter: "[ShoeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Sales_SaleId",
                table: "Branches",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Shoes_ShoeId",
                table: "Branches",
                column: "ShoeId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
