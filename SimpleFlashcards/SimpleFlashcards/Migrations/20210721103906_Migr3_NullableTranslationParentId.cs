using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleFlashcards.Migrations
{
    public partial class Migr3_NullableTranslationParentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TranslationParentId",
                table: "FlashcardWords",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TranslationParentId",
                table: "FlashcardWords",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
