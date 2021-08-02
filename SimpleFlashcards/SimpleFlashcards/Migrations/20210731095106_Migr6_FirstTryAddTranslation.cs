using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleFlashcards.Migrations
{
    public partial class Migr6_FirstTryAddTranslation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Words_TParentId",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_TParentId",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "TParentId",
                table: "Words");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Words",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Words",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    WordId1 = table.Column<Guid>(nullable: false),
                    WordId2 = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => new { x.WordId1, x.WordId2 });
                    table.ForeignKey(
                        name: "FK_Translations_Words_WordId1",
                        column: x => x.WordId1,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Translations_Words_WordId2",
                        column: x => x.WordId2,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Translations_WordId2",
                table: "Translations",
                column: "WordId2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Words");

            migrationBuilder.AddColumn<Guid>(
                name: "TParentId",
                table: "Words",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Words_TParentId",
                table: "Words",
                column: "TParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Words_TParentId",
                table: "Words",
                column: "TParentId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
