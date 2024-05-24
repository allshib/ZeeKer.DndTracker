using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletingBlock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "CharacterInfo");

            migrationBuilder.AddColumn<bool>(
                name: "Block",
                table: "Characters",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Block",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "CharacterInfo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
