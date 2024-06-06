using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddSpell : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(170)", maxLength: 170, nullable: true),
                    MagicSchool = table.Column<int>(type: "int", nullable: false),
                    SpellLevel = table.Column<int>(type: "int", nullable: false),
                    Descripton = table.Column<string>(type: "nvarchar(1700)", maxLength: 1700, nullable: true),
                    Components = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Source = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spells");
        }
    }
}
