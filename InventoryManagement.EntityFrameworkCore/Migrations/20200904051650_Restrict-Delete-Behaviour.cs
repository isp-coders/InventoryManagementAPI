using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class RestrictDeleteBehaviour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Colors_ColorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleAndRolePermessions_Roles_RoleId",
                table: "RoleAndRolePermessions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleAndRolePermessions_RolePermessions_RolePermessionId",
                table: "RoleAndRolePermessions");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetailsAndProduct_Products_ProductId",
                table: "SaleDetailsAndProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetailsAndProduct_Sales_SaleId",
                table: "SaleDetailsAndProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePaymentMethodsRelation_CustomerInfo_CustomerInfoId",
                table: "SalePaymentMethodsRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePaymentMethodsRelation_PaymentMethods_PaymentMethodId",
                table: "SalePaymentMethodsRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePaymentMethodsRelation_Sales_SaleId",
                table: "SalePaymentMethodsRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Branches_BranchId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleRelation_Roles_RoleId",
                table: "UserRoleRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleRelation_Users_UserId",
                table: "UserRoleRelation");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Colors_ColorId",
                table: "Products",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAndRolePermessions_Roles_RoleId",
                table: "RoleAndRolePermessions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAndRolePermessions_RolePermessions_RolePermessionId",
                table: "RoleAndRolePermessions",
                column: "RolePermessionId",
                principalTable: "RolePermessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetailsAndProduct_Products_ProductId",
                table: "SaleDetailsAndProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetailsAndProduct_Sales_SaleId",
                table: "SaleDetailsAndProduct",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalePaymentMethodsRelation_CustomerInfo_CustomerInfoId",
                table: "SalePaymentMethodsRelation",
                column: "CustomerInfoId",
                principalTable: "CustomerInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalePaymentMethodsRelation_PaymentMethods_PaymentMethodId",
                table: "SalePaymentMethodsRelation",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalePaymentMethodsRelation_Sales_SaleId",
                table: "SalePaymentMethodsRelation",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Branches_BranchId",
                table: "Sales",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleRelation_Roles_RoleId",
                table: "UserRoleRelation",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleRelation_Users_UserId",
                table: "UserRoleRelation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Colors_ColorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleAndRolePermessions_Roles_RoleId",
                table: "RoleAndRolePermessions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleAndRolePermessions_RolePermessions_RolePermessionId",
                table: "RoleAndRolePermessions");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetailsAndProduct_Products_ProductId",
                table: "SaleDetailsAndProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetailsAndProduct_Sales_SaleId",
                table: "SaleDetailsAndProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePaymentMethodsRelation_CustomerInfo_CustomerInfoId",
                table: "SalePaymentMethodsRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePaymentMethodsRelation_PaymentMethods_PaymentMethodId",
                table: "SalePaymentMethodsRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePaymentMethodsRelation_Sales_SaleId",
                table: "SalePaymentMethodsRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Branches_BranchId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleRelation_Roles_RoleId",
                table: "UserRoleRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleRelation_Users_UserId",
                table: "UserRoleRelation");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Colors_ColorId",
                table: "Products",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAndRolePermessions_Roles_RoleId",
                table: "RoleAndRolePermessions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAndRolePermessions_RolePermessions_RolePermessionId",
                table: "RoleAndRolePermessions",
                column: "RolePermessionId",
                principalTable: "RolePermessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetailsAndProduct_Products_ProductId",
                table: "SaleDetailsAndProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetailsAndProduct_Sales_SaleId",
                table: "SaleDetailsAndProduct",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalePaymentMethodsRelation_CustomerInfo_CustomerInfoId",
                table: "SalePaymentMethodsRelation",
                column: "CustomerInfoId",
                principalTable: "CustomerInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Sales_Branches_BranchId",
                table: "Sales",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "Users",
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
    }
}
