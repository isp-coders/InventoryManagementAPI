using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class minor1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleRoleId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "RoleRoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
