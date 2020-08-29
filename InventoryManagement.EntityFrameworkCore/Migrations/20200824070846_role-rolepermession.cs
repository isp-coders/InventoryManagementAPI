using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class rolerolepermession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrivilegesList",
                table: "Roles");

            migrationBuilder.AddColumn<string>(
                name: "Cellphone",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSuccesfulLoginDate",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserStatus",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleGroupId",
                table: "Roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RolePermessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleKey = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Translate = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleAndRolePermessions",
                columns: table => new
                {
                    RolePermessionId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAndRolePermessions", x => new { x.RoleId, x.RolePermessionId });
                    table.ForeignKey(
                        name: "FK_RoleAndRolePermessions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAndRolePermessions_RolePermessions_RolePermessionId",
                        column: x => x.RolePermessionId,
                        principalTable: "RolePermessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleAndRolePermessions_RolePermessionId",
                table: "RoleAndRolePermessions",
                column: "RolePermessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleAndRolePermessions");

            migrationBuilder.DropTable(
                name: "RolePermessions");

            migrationBuilder.DropColumn(
                name: "Cellphone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastSuccesfulLoginDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserStatus",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleGroupId",
                table: "Roles");

            migrationBuilder.AddColumn<string>(
                name: "PrivilegesList",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
