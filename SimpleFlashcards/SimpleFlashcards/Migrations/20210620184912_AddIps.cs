using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleFlashcards.Migrations
{
    public partial class AddIps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ip",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(maxLength: 500, nullable: true),
                    IsInBan = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserIp",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    IpId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIp", x => new { x.UserId, x.IpId });
                    table.ForeignKey(
                        name: "FK_UserIp_Ip_IpId",
                        column: x => x.IpId,
                        principalTable: "Ip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserIp_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserIp_IpId",
                table: "UserIp",
                column: "IpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserIp");

            migrationBuilder.DropTable(
                name: "Ip");
        }
    }
}
