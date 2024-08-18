using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddOriginalNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "Spells",
                type: "nvarchar(170)",
                maxLength: 170,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "Items",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "Items");
        }
    }
}
