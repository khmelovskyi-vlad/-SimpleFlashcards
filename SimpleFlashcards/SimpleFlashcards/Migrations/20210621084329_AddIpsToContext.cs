using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleFlashcards.Migrations
{
    public partial class AddIpsToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIp_Ip_IpId",
                table: "UserIp");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIp_AspNetUsers_UserId",
                table: "UserIp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIp",
                table: "UserIp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ip",
                table: "Ip");

            migrationBuilder.RenameTable(
                name: "UserIp",
                newName: "UserIps");

            migrationBuilder.RenameTable(
                name: "Ip",
                newName: "Ips");

            migrationBuilder.RenameIndex(
                name: "IX_UserIp_IpId",
                table: "UserIps",
                newName: "IX_UserIps_IpId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIps",
                table: "UserIps",
                columns: new[] { "UserId", "IpId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ips",
                table: "Ips",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIps_Ips_IpId",
                table: "UserIps",
                column: "IpId",
                principalTable: "Ips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserIps_AspNetUsers_UserId",
                table: "UserIps",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIps_Ips_IpId",
                table: "UserIps");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIps_AspNetUsers_UserId",
                table: "UserIps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIps",
                table: "UserIps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ips",
                table: "Ips");

            migrationBuilder.RenameTable(
                name: "UserIps",
                newName: "UserIp");

            migrationBuilder.RenameTable(
                name: "Ips",
                newName: "Ip");

            migrationBuilder.RenameIndex(
                name: "IX_UserIps_IpId",
                table: "UserIp",
                newName: "IX_UserIp_IpId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIp",
                table: "UserIp",
                columns: new[] { "UserId", "IpId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ip",
                table: "Ip",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIp_Ip_IpId",
                table: "UserIp",
                column: "IpId",
                principalTable: "Ip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserIp_AspNetUsers_UserId",
                table: "UserIp",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
