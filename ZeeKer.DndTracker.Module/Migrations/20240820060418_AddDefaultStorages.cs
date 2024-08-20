using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultStorages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DefaultStorageID",
                table: "CharacterClasses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClasses_DefaultStorageID",
                table: "CharacterClasses",
                column: "DefaultStorageID");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterClasses_CharacterStorages_DefaultStorageID",
                table: "CharacterClasses",
                column: "DefaultStorageID",
                principalTable: "CharacterStorages",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterClasses_CharacterStorages_DefaultStorageID",
                table: "CharacterClasses");

            migrationBuilder.DropIndex(
                name: "IX_CharacterClasses_DefaultStorageID",
                table: "CharacterClasses");

            migrationBuilder.DropColumn(
                name: "DefaultStorageID",
                table: "CharacterClasses");
        }
    }
}
