using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleFlashcards.Migrations
{
    public partial class Migr8_ThirdTryAddTranslation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Words_WordId1",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Words_WordId2",
                table: "Translations");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Words_WordId1",
                table: "Translations",
                column: "WordId1",
                principalTable: "Words",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Words_WordId2",
                table: "Translations",
                column: "WordId2",
                principalTable: "Words",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Words_WordId1",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Words_WordId2",
                table: "Translations");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Words_WordId1",
                table: "Translations",
                column: "WordId1",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Words_WordId2",
                table: "Translations",
                column: "WordId2",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
