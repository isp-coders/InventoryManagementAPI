using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class IdaddedtoSaleDetailsAndProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleDetailsAndProduct",
                table: "SaleDetailsAndProduct");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SaleDetailsAndProduct",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleDetailsAndProduct",
                table: "SaleDetailsAndProduct",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetailsAndProduct_SaleId",
                table: "SaleDetailsAndProduct",
                column: "SaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleDetailsAndProduct",
                table: "SaleDetailsAndProduct");

            migrationBuilder.DropIndex(
                name: "IX_SaleDetailsAndProduct_SaleId",
                table: "SaleDetailsAndProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SaleDetailsAndProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleDetailsAndProduct",
                table: "SaleDetailsAndProduct",
                columns: new[] { "SaleId", "ProductId" });
        }
    }
}
