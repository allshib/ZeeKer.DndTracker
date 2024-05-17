using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class OperationRalationSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterStorages_Characters_CharacterId",
                table: "CharacterStorages");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterStorages_Characters_CharacterId",
                table: "CharacterStorages",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterStorages_Characters_CharacterId",
                table: "CharacterStorages");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterStorages_Characters_CharacterId",
                table: "CharacterStorages",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
