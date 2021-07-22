using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleFlashcards.Migrations
{
    public partial class Migr5_MoveImagesFromFlashcardsToWords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileInfoFlashcards");

            migrationBuilder.DropTable(
                name: "FileInfoFlashcardWords");

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "FlashcardWords",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "FileInfoWordImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    OriginalName = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    WordId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileInfoWordImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileInfoWordImages_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileInfoWordPronunciations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    OriginalName = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    WordId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileInfoWordPronunciations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileInfoWordPronunciations_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileInfoWordImages_WordId",
                table: "FileInfoWordImages",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_FileInfoWordPronunciations_WordId",
                table: "FileInfoWordPronunciations",
                column: "WordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileInfoWordImages");

            migrationBuilder.DropTable(
                name: "FileInfoWordPronunciations");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "FlashcardWords");

            migrationBuilder.CreateTable(
                name: "FileInfoFlashcards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlashcardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileInfoFlashcards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileInfoFlashcards_Flashcards_FlashcardId",
                        column: x => x.FlashcardId,
                        principalTable: "Flashcards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileInfoFlashcardWords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    WordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileInfoFlashcardWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileInfoFlashcardWords_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileInfoFlashcards_FlashcardId",
                table: "FileInfoFlashcards",
                column: "FlashcardId");

            migrationBuilder.CreateIndex(
                name: "IX_FileInfoFlashcardWords_WordId",
                table: "FileInfoFlashcardWords",
                column: "WordId");
        }
    }
}
