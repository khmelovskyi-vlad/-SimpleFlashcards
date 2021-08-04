using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleFlashcards.Migrations
{
    public partial class Migr13_ChangeSubTopicToSubtopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubTopics_Topics_TopicId",
                table: "SubTopics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubTopics",
                table: "SubTopics");

            migrationBuilder.RenameTable(
                name: "SubTopics",
                newName: "Subtopics");

            migrationBuilder.RenameIndex(
                name: "IX_SubTopics_TopicId",
                table: "Subtopics",
                newName: "IX_Subtopics_TopicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subtopics",
                table: "Subtopics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subtopics_Topics_TopicId",
                table: "Subtopics",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subtopics_Topics_TopicId",
                table: "Subtopics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subtopics",
                table: "Subtopics");

            migrationBuilder.RenameTable(
                name: "Subtopics",
                newName: "SubTopics");

            migrationBuilder.RenameIndex(
                name: "IX_Subtopics_TopicId",
                table: "SubTopics",
                newName: "IX_SubTopics_TopicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubTopics",
                table: "SubTopics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTopics_Topics_TopicId",
                table: "SubTopics",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
