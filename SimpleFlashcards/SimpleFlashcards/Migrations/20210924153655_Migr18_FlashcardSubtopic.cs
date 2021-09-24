using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleFlashcards.Migrations
{
    public partial class Migr18_FlashcardSubtopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flashcards_Topics_TopicId",
                table: "Flashcards");

            migrationBuilder.DropIndex(
                name: "IX_Flashcards_TopicId",
                table: "Flashcards");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Flashcards");

            migrationBuilder.CreateTable(
                name: "FlashcardTopics",
                columns: table => new
                {
                    FlashcardId = table.Column<Guid>(nullable: false),
                    TopicId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashcardTopics", x => new { x.FlashcardId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_FlashcardTopics_Flashcards_FlashcardId",
                        column: x => x.FlashcardId,
                        principalTable: "Flashcards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlashcardTopics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashcardTopics_TopicId",
                table: "FlashcardTopics",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlashcardTopics");

            migrationBuilder.AddColumn<Guid>(
                name: "TopicId",
                table: "Flashcards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flashcards_TopicId",
                table: "Flashcards",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flashcards_Topics_TopicId",
                table: "Flashcards",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
