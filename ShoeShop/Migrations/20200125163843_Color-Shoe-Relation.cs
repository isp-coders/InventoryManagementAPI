using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeShop.Migrations
{
    public partial class ColorShoeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Shoes");

            migrationBuilder.AddColumn<int>(
                name: "ShoeId",
                table: "Colors",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
