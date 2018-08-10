using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RBACdemo.Infrastructure.Migrations
{
    public partial class tenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "TenantNumbers",
                schema: "shared");

            migrationBuilder.AddColumn<long>(
                name: "TenantNo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.RestartSequence(
                name: "OrderNumbers",
                schema: "shared",
                startValue: 1L);

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsDisbalbed = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TenantNo = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR shared.TenantNumbers"),
                    DomainName = table.Column<string>(nullable: true),
                    Companyname = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    Todate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tenant_TenantNo",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TenantNo",
                table: "AspNetUsers");

            migrationBuilder.DropSequence(
                name: "TenantNumbers",
                schema: "shared");

            migrationBuilder.DropColumn(
                name: "TenantNo",
                table: "AspNetUsers");

            migrationBuilder.RestartSequence(
                name: "OrderNumbers",
                schema: "shared",
                startValue: 100L);
        }
    }
}
