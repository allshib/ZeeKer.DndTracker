using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NeedSetting",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxSettingCount",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SettingOnThis",
                table: "AssignedItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeedSetting",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MaxSettingCount",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SettingOnThis",
                table: "AssignedItems");
        }
    }
}
