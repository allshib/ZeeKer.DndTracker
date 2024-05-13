using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddCharacterInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InfoId",
                table: "Characters",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CharacterInfo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Background = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Personality = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Ideals = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    Flaws = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Aligment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Eyes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Hair = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterInfo", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_InfoId",
                table: "Characters",
                column: "InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterInfo_InfoId",
                table: "Characters",
                column: "InfoId",
                principalTable: "CharacterInfo",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterInfo_InfoId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "CharacterInfo");

            migrationBuilder.DropIndex(
                name: "IX_Characters_InfoId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "InfoId",
                table: "Characters");
        }
    }
}
