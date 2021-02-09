using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class CampaignSaleDetailsAndProductCampaignOnetoMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "SaleDetailsAndProduct",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetailsAndProduct_CampaignId",
                table: "SaleDetailsAndProduct",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetailsAndProduct_Campaigns_CampaignId",
                table: "SaleDetailsAndProduct",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetailsAndProduct_Campaigns_CampaignId",
                table: "SaleDetailsAndProduct");

            migrationBuilder.DropIndex(
                name: "IX_SaleDetailsAndProduct_CampaignId",
                table: "SaleDetailsAndProduct");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "SaleDetailsAndProduct");
        }
    }
}
