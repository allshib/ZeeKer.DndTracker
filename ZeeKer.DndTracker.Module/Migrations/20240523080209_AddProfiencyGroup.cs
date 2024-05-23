using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddProfiencyGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupProfiencyType",
                table: "Profiencies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupProfiencyType",
                table: "Profiencies");
        }
    }
}
