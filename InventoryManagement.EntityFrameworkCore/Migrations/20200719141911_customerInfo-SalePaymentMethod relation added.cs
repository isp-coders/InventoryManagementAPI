using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class customerInfoSalePaymentMethodrelationadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerInfoId",
                table: "SalePaymentMethodsRelation",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "customerInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalePaymentMethodsRelation_CustomerInfoId",
                table: "SalePaymentMethodsRelation",
                column: "CustomerInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalePaymentMethodsRelation_customerInfos_CustomerInfoId",
                table: "SalePaymentMethodsRelation",
                column: "CustomerInfoId",
                principalTable: "customerInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalePaymentMethodsRelation_customerInfos_CustomerInfoId",
                table: "SalePaymentMethodsRelation");

            migrationBuilder.DropTable(
                name: "customerInfos");

            migrationBuilder.DropIndex(
                name: "IX_SalePaymentMethodsRelation_CustomerInfoId",
                table: "SalePaymentMethodsRelation");

            migrationBuilder.DropColumn(
                name: "CustomerInfoId",
                table: "SalePaymentMethodsRelation");
        }
    }
}
