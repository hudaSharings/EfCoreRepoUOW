using Microsoft.EntityFrameworkCore.Migrations;

namespace RBACdemo.Infrastructure.Migrations
{
    public partial class testdb1234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleMenuItems_MenuItems_MenuItemNo",
                table: "RoleMenuItems");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_MenuItems_MenuItemNo",
                table: "MenuItems",
                column: "MenuItemNo");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleMenuItems_MenuItems_MenuItemNo",
                table: "RoleMenuItems",
                column: "MenuItemNo",
                principalTable: "MenuItems",
                principalColumn: "MenuItemNo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleMenuItems_MenuItems_MenuItemNo",
                table: "RoleMenuItems");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_MenuItems_MenuItemNo",
                table: "MenuItems");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleMenuItems_MenuItems_MenuItemNo",
                table: "RoleMenuItems",
                column: "MenuItemNo",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
