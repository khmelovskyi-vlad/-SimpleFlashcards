using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleFlashcards.Migrations
{
    public partial class Migr7_SecondTryAddTranslation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Words_WordId1",
                table: "Translations");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Words_WordId1",
                table: "Translations",
                column: "WordId1",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Words_WordId1",
                table: "Translations");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Words_WordId1",
                table: "Translations",
                column: "WordId1",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
