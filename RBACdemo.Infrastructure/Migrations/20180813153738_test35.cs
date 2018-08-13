using Microsoft.EntityFrameworkCore.Migrations;

namespace RBACdemo.Infrastructure.Migrations
{
    public partial class test35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMenuItem_MenuItems_MenuItemNo",
                table: "UserMenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMenuItem_AspNetUsers_UserId",
                table: "UserMenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMenuItem",
                table: "UserMenuItem");

            migrationBuilder.RenameTable(
                name: "UserMenuItem",
                newName: "UserMenuItems");

            migrationBuilder.RenameIndex(
                name: "IX_UserMenuItem_UserId",
                table: "UserMenuItems",
                newName: "IX_UserMenuItems_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMenuItem_MenuItemNo",
                table: "UserMenuItems",
                newName: "IX_UserMenuItems_MenuItemNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMenuItems",
                table: "UserMenuItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMenuItems_MenuItems_MenuItemNo",
                table: "UserMenuItems",
                column: "MenuItemNo",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMenuItems_AspNetUsers_UserId",
                table: "UserMenuItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMenuItems_MenuItems_MenuItemNo",
                table: "UserMenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMenuItems_AspNetUsers_UserId",
                table: "UserMenuItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMenuItems",
                table: "UserMenuItems");

            migrationBuilder.RenameTable(
                name: "UserMenuItems",
                newName: "UserMenuItem");

            migrationBuilder.RenameIndex(
                name: "IX_UserMenuItems_UserId",
                table: "UserMenuItem",
                newName: "IX_UserMenuItem_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMenuItems_MenuItemNo",
                table: "UserMenuItem",
                newName: "IX_UserMenuItem_MenuItemNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMenuItem",
                table: "UserMenuItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMenuItem_MenuItems_MenuItemNo",
                table: "UserMenuItem",
                column: "MenuItemNo",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMenuItem_AspNetUsers_UserId",
                table: "UserMenuItem",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
