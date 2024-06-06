using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddAvailableSpell : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableSpell",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpellId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableSpell", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AvailableSpell_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableSpell_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSpell_CharacterId",
                table: "AvailableSpell",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSpell_SpellId",
                table: "AvailableSpell",
                column: "SpellId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableSpell");
        }
    }
}
