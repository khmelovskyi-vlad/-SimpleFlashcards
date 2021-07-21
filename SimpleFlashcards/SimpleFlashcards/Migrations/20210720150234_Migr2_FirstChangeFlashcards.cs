using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleFlashcards.Migrations
{
    public partial class Migr2_FirstChangeFlashcards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashcardWords_FlashcardTranslations_FlashcardTranslationId",
                table: "FlashcardWords");

            migrationBuilder.DropTable(
                name: "FlashcardTranslations");

            migrationBuilder.DropIndex(
                name: "IX_FlashcardWords_FlashcardTranslationId",
                table: "FlashcardWords");

            migrationBuilder.DropColumn(
                name: "FlashcardTranslationId",
                table: "FlashcardWords");

            migrationBuilder.DropColumn(
                name: "PronunciationId",
                table: "FlashcardWords");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "FlashcardWords",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FlashcardId",
                table: "FlashcardWords",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TranslationParentId",
                table: "FlashcardWords",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FlashcardWords_CountryId",
                table: "FlashcardWords",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashcardWords_FlashcardId",
                table: "FlashcardWords",
                column: "FlashcardId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashcardWords_TranslationParentId",
                table: "FlashcardWords",
                column: "TranslationParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashcardWords_Countries_CountryId",
                table: "FlashcardWords",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashcardWords_Flashcards_FlashcardId",
                table: "FlashcardWords",
                column: "FlashcardId",
                principalTable: "Flashcards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashcardWords_FlashcardWords_TranslationParentId",
                table: "FlashcardWords",
                column: "TranslationParentId",
                principalTable: "FlashcardWords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashcardWords_Countries_CountryId",
                table: "FlashcardWords");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashcardWords_Flashcards_FlashcardId",
                table: "FlashcardWords");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashcardWords_FlashcardWords_TranslationParentId",
                table: "FlashcardWords");

            migrationBuilder.DropIndex(
                name: "IX_FlashcardWords_CountryId",
                table: "FlashcardWords");

            migrationBuilder.DropIndex(
                name: "IX_FlashcardWords_FlashcardId",
                table: "FlashcardWords");

            migrationBuilder.DropIndex(
                name: "IX_FlashcardWords_TranslationParentId",
                table: "FlashcardWords");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "FlashcardWords");

            migrationBuilder.DropColumn(
                name: "FlashcardId",
                table: "FlashcardWords");

            migrationBuilder.DropColumn(
                name: "TranslationParentId",
                table: "FlashcardWords");

            migrationBuilder.AddColumn<Guid>(
                name: "FlashcardTranslationId",
                table: "FlashcardWords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PronunciationId",
                table: "FlashcardWords",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FlashcardTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlashcardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashcardTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlashcardTranslations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlashcardTranslations_Flashcards_FlashcardId",
                        column: x => x.FlashcardId,
                        principalTable: "Flashcards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashcardWords_FlashcardTranslationId",
                table: "FlashcardWords",
                column: "FlashcardTranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashcardTranslations_CountryId",
                table: "FlashcardTranslations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashcardTranslations_FlashcardId",
                table: "FlashcardTranslations",
                column: "FlashcardId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashcardWords_FlashcardTranslations_FlashcardTranslationId",
                table: "FlashcardWords",
                column: "FlashcardTranslationId",
                principalTable: "FlashcardTranslations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
