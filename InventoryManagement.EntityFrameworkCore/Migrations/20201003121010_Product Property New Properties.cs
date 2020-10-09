using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class ProductPropertyNewProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductProperties");

            migrationBuilder.AddColumn<string>(
                name: "DataField",
                table: "ProductProperties",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Disabled",
                table: "ProductProperties",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EditorOptions",
                table: "ProductProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditorType",
                table: "ProductProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Validation",
                table: "ProductProperties",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ValidationConf",
                table: "ProductProperties",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataField",
                table: "ProductProperties");

            migrationBuilder.DropColumn(
                name: "Disabled",
                table: "ProductProperties");

            migrationBuilder.DropColumn(
                name: "EditorOptions",
                table: "ProductProperties");

            migrationBuilder.DropColumn(
                name: "EditorType",
                table: "ProductProperties");

            migrationBuilder.DropColumn(
                name: "Validation",
                table: "ProductProperties");

            migrationBuilder.DropColumn(
                name: "ValidationConf",
                table: "ProductProperties");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductProperties",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
