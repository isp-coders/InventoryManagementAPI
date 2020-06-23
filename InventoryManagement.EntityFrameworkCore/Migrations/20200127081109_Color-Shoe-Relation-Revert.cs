using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class ColorShoeRelationRevert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Shoes_ShoeId",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Colors_ShoeId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "ShoeId",
                table: "Colors");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Shoes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_ColorId",
                table: "Shoes",
                column: "ColorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Colors_ColorId",
                table: "Shoes",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Colors_ColorId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_ColorId",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Shoes");

            migrationBuilder.AddColumn<int>(
                name: "ShoeId",
                table: "Colors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ShoeId",
                table: "Colors",
                column: "ShoeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Shoes_ShoeId",
                table: "Colors",
                column: "ShoeId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
