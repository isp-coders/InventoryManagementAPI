using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class ProductPropertyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditorOptions",
                table: "ProductProperties");

            migrationBuilder.AddColumn<string>(
                name: "FormItemEditorOptions",
                table: "ProductProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GridColumnEditorOptions",
                table: "ProductProperties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormItemEditorOptions",
                table: "ProductProperties");

            migrationBuilder.DropColumn(
                name: "GridColumnEditorOptions",
                table: "ProductProperties");

            migrationBuilder.AddColumn<string>(
                name: "EditorOptions",
                table: "ProductProperties",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
