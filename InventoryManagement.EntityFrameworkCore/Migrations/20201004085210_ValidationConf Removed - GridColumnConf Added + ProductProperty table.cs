using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class ValidationConfRemovedGridColumnConfAddedProductPropertytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidationConf",
                table: "ProductProperties");

            migrationBuilder.AddColumn<string>(
                name: "GridColumnConf",
                table: "ProductProperties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GridColumnConf",
                table: "ProductProperties");

            migrationBuilder.AddColumn<bool>(
                name: "ValidationConf",
                table: "ProductProperties",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
