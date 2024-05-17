using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class LinkSkillsToStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StatsId",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SkillsId",
                table: "CharacterStats",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_StatsId",
                table: "Skills",
                column: "StatsId",
                unique: true,
                filter: "[StatsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_CharacterStats_StatsId",
                table: "Skills",
                column: "StatsId",
                principalTable: "CharacterStats",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_CharacterStats_StatsId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_StatsId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "StatsId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SkillsId",
                table: "CharacterStats");
        }
    }
}
