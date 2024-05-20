using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddShields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rarity",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ShieldItemId",
                table: "Characters",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ShieldItemId",
                table: "Characters",
                column: "ShieldItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AssignedItems_ShieldItemId",
                table: "Characters",
                column: "ShieldItemId",
                principalTable: "AssignedItems",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AssignedItems_ShieldItemId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ShieldItemId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Rarity",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ShieldItemId",
                table: "Characters");
        }
    }
}
