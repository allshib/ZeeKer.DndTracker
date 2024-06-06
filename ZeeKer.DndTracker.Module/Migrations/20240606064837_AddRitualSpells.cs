using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddRitualSpells : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRitual",
                table: "Spells",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRitual",
                table: "Spells");
        }
    }
}
