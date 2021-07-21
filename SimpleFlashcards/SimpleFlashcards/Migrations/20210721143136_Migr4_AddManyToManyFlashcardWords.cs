using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleFlashcards.Migrations
{
    public partial class Migr4_AddManyToManyFlashcardWords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileInfoFlashcardWords_FlashcardWords_FlashcardWordId",
                table: "FileInfoFlashcardWords");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashcardWords_Countries_CountryId",
                table: "FlashcardWords");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashcardWords_Flashcards_FlashcardId",
                table: "FlashcardWords");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashcardWords_FlashcardWords_TranslationParentId",
                table: "FlashcardWords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlashcardWords",
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

            migrationBuilder.DropIndex(
                name: "IX_FileInfoFlashcardWords_FlashcardWordId",
                table: "FileInfoFlashcardWords");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FlashcardWords");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "FlashcardWords");

            migrationBuilder.DropColumn(
                name: "PartOfSpeech",
                table: "FlashcardWords");

            migrationBuilder.DropColumn(
                name: "Transcription",
                table: "FlashcardWords");

            migrationBuilder.DropColumn(
                name: "TranslationParentId",
                table: "FlashcardWords");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "FlashcardWords");

            migrationBuilder.DropColumn(
                name: "FlashcardWordId",
                table: "FileInfoFlashcardWords");

            migrationBuilder.AlterColumn<Guid>(
                name: "FlashcardId",
                table: "FlashcardWords",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WordId",
                table: "FlashcardWords",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "WordId",
                table: "FileInfoFlashcardWords",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlashcardWords",
                table: "FlashcardWords",
                columns: new[] { "FlashcardId", "WordId" });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Transcription = table.Column<string>(nullable: true),
                    PartOfSpeech = table.Column<int>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    TParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Words_Words_TParentId",
                        column: x => x.TParentId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashcardWords_WordId",
                table: "FlashcardWords",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_FileInfoFlashcardWords_WordId",
                table: "FileInfoFlashcardWords",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_CountryId",
                table: "Words",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_TParentId",
                table: "Words",
                column: "TParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileInfoFlashcardWords_Words_WordId",
                table: "FileInfoFlashcardWords",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashcardWords_Flashcards_FlashcardId",
                table: "FlashcardWords",
                column: "FlashcardId",
                principalTable: "Flashcards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashcardWords_Words_WordId",
                table: "FlashcardWords",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileInfoFlashcardWords_Words_WordId",
                table: "FileInfoFlashcardWords");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashcardWords_Flashcards_FlashcardId",
                table: "FlashcardWords");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashcardWords_Words_WordId",
                table: "FlashcardWords");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlashcardWords",
                table: "FlashcardWords");

            migrationBuilder.DropIndex(
                name: "IX_FlashcardWords_WordId",
                table: "FlashcardWords");

            migrationBuilder.DropIndex(
                name: "IX_FileInfoFlashcardWords_WordId",
                table: "FileInfoFlashcardWords");

            migrationBuilder.DropColumn(
                name: "WordId",
                table: "FlashcardWords");

            migrationBuilder.DropColumn(
                name: "WordId",
                table: "FileInfoFlashcardWords");

            migrationBuilder.AlterColumn<Guid>(
                name: "FlashcardId",
                table: "FlashcardWords",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "FlashcardWords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "FlashcardWords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "PartOfSpeech",
                table: "FlashcardWords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Transcription",
                table: "FlashcardWords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TranslationParentId",
                table: "FlashcardWords",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "FlashcardWords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FlashcardWordId",
                table: "FileInfoFlashcardWords",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlashcardWords",
                table: "FlashcardWords",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_FileInfoFlashcardWords_FlashcardWordId",
                table: "FileInfoFlashcardWords",
                column: "FlashcardWordId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileInfoFlashcardWords_FlashcardWords_FlashcardWordId",
                table: "FileInfoFlashcardWords",
                column: "FlashcardWordId",
                principalTable: "FlashcardWords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
