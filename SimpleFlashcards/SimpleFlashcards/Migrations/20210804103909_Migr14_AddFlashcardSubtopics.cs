using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleFlashcards.Migrations
{
    public partial class Migr14_AddFlashcardSubtopics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAllSubtopics",
                table: "Flashcards",
                nullable: false,
                defaultValue: true);

            migrationBuilder.CreateTable(
                name: "FlashcardSubtopics",
                columns: table => new
                {
                    FlashcardId = table.Column<Guid>(nullable: false),
                    SubtopicId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashcardSubtopics", x => new { x.FlashcardId, x.SubtopicId });
                    table.ForeignKey(
                        name: "FK_FlashcardSubtopics_Flashcards_FlashcardId",
                        column: x => x.FlashcardId,
                        principalTable: "Flashcards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlashcardSubtopics_Subtopics_SubtopicId",
                        column: x => x.SubtopicId,
                        principalTable: "Subtopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashcardSubtopics_SubtopicId",
                table: "FlashcardSubtopics",
                column: "SubtopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlashcardSubtopics");

            migrationBuilder.DropColumn(
                name: "IsAllSubtopics",
                table: "Flashcards");
        }
    }
}
