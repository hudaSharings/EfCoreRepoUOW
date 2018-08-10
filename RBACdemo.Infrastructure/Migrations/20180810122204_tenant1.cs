using Microsoft.EntityFrameworkCore.Migrations;

namespace RBACdemo.Infrastructure.Migrations
{
    public partial class tenant1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tenant_TenantNo",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TenantNo",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "TenantNo",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<long>(
                name: "TenantNo",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TenantNo",
                table: "AspNetUsers",
                column: "TenantNo");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tenant_TenantNo",
                table: "AspNetUsers",
                column: "TenantNo",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
