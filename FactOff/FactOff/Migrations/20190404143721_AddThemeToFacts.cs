using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FactOff.Migrations
{
    public partial class AddThemeToFacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ThemeId",
                table: "Facts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facts_ThemeId",
                table: "Facts",
                column: "ThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_Themes_ThemeId",
                table: "Facts",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "ThemeId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facts_Themes_ThemeId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_Facts_ThemeId",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "ThemeId",
                table: "Facts");
        }
    }
}
