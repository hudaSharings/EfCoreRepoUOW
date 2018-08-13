using Microsoft.EntityFrameworkCore.Migrations;

namespace RBACdemo.Infrastructure.Migrations
{
    public partial class newTenent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tenant_TenantId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TenantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Tenant_TenantNo",
                table: "Tenant",
                column: "TenantNo");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TenantNo",
                table: "AspNetUsers",
                column: "TenantNo");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tenant_TenantNo",
                table: "AspNetUsers",
                column: "TenantNo",
                principalTable: "Tenant",
                principalColumn: "TenantNo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tenant_TenantNo",
                table: "AspNetUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Tenant_TenantNo",
                table: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TenantNo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TenantId",
                table: "AspNetUsers",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tenant_TenantId",
                table: "AspNetUsers",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
