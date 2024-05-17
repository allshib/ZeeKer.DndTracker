using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddCharacterStatsCascadeDeleting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterStats_StatsId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterStats_Characters_CharacterId",
                table: "CharacterStats");

            migrationBuilder.DropIndex(
                name: "IX_CharacterStats_CharacterId",
                table: "CharacterStats");

            migrationBuilder.DropIndex(
                name: "IX_Characters_StatsId",
                table: "Characters");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterStats_CharacterId",
                table: "CharacterStats",
                column: "CharacterId",
                unique: true,
                filter: "[CharacterId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterStats_Characters_CharacterId",
                table: "CharacterStats",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterStats_Characters_CharacterId",
                table: "CharacterStats");

            migrationBuilder.DropIndex(
                name: "IX_CharacterStats_CharacterId",
                table: "CharacterStats");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterStats_CharacterId",
                table: "CharacterStats",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_StatsId",
                table: "Characters",
                column: "StatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterStats_StatsId",
                table: "Characters",
                column: "StatsId",
                principalTable: "CharacterStats",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterStats_Characters_CharacterId",
                table: "CharacterStats",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "ID");
        }
    }
}
