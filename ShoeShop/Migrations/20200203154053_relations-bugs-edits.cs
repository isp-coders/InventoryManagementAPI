using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeShop.Migrations
{
    public partial class relationsbugsedits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalePaymentMethod_PaymentMethod_PaymentMethodId",
                table: "SalePaymentMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePaymentMethod_Sales_SaleId",
                table: "SalePaymentMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Roles_RoleId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalePaymentMethod",
                table: "SalePaymentMethod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod");

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "UserRoleRelation");

            migrationBuilder.RenameTable(
                name: "SalePaymentMethod",
                newName: "SalePaymentMethodsRelation");

            migrationBuilder.RenameTable(
                name: "PaymentMethod",
                newName: "PaymentMethods");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_UserId",
                table: "UserRoleRelation",
                newName: "IX_UserRoleRelation_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SalePaymentMethod_PaymentMethodId",
                table: "SalePaymentMethodsRelation",
                newName: "IX_SalePaymentMethodsRelation_PaymentMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoleRelation",
                table: "UserRoleRelation",
                columns: new[] { "RoleId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalePaymentMethodsRelation",
                table: "SalePaymentMethodsRelation",
                columns: new[] { "SaleId", "PaymentMethodId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethods",
                table: "PaymentMethods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalePaymentMethodsRelation_PaymentMethods_PaymentMethodId",
                table: "SalePaymentMethodsRelation",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalePaymentMethodsRelation_Sales_SaleId",
                table: "SalePaymentMethodsRelation",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleRelation_Roles_RoleId",
                table: "UserRoleRelation",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleRelation_Users_UserId",
                table: "UserRoleRelation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalePaymentMethodsRelation_PaymentMethods_PaymentMethodId",
                table: "SalePaymentMethodsRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePaymentMethodsRelation_Sales_SaleId",
                table: "SalePaymentMethodsRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleRelation_Roles_RoleId",
                table: "UserRoleRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleRelation_Users_UserId",
                table: "UserRoleRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoleRelation",
                table: "UserRoleRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalePaymentMethodsRelation",
                table: "SalePaymentMethodsRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethods",
                table: "PaymentMethods");

            migrationBuilder.RenameTable(
                name: "UserRoleRelation",
                newName: "UserRole");

            migrationBuilder.RenameTable(
                name: "SalePaymentMethodsRelation",
                newName: "SalePaymentMethod");

            migrationBuilder.RenameTable(
                name: "PaymentMethods",
                newName: "PaymentMethod");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoleRelation_UserId",
                table: "UserRole",
                newName: "IX_UserRole_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SalePaymentMethodsRelation_PaymentMethodId",
                table: "SalePaymentMethod",
                newName: "IX_SalePaymentMethod_PaymentMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalePaymentMethod",
                table: "SalePaymentMethod",
                columns: new[] { "SaleId", "PaymentMethodId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalePaymentMethod_PaymentMethod_PaymentMethodId",
                table: "SalePaymentMethod",
                column: "PaymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalePaymentMethod_Sales_SaleId",
                table: "SalePaymentMethod",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Roles_RoleId",
                table: "UserRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
