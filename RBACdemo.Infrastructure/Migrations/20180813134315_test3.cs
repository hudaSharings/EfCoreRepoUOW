using Microsoft.EntityFrameworkCore.Migrations;

namespace RBACdemo.Infrastructure.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tenant_TenantNo",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenant",
                table: "Tenant");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Tenant_TenantNo",
                table: "Tenant");

            migrationBuilder.RenameTable(
                name: "Tenant",
                newName: "Tenants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Tenants_TenantNo",
                table: "Tenants",
                column: "TenantNo");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tenants_TenantNo",
                table: "AspNetUsers",
                column: "TenantNo",
                principalTable: "Tenants",
                principalColumn: "TenantNo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tenants_TenantNo",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Tenants_TenantNo",
                table: "Tenants");

            migrationBuilder.RenameTable(
                name: "Tenants",
                newName: "Tenant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenant",
                table: "Tenant",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Tenant_TenantNo",
                table: "Tenant",
                column: "TenantNo");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tenant_TenantNo",
                table: "AspNetUsers",
                column: "TenantNo",
                principalTable: "Tenant",
                principalColumn: "TenantNo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
