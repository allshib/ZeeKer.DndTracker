using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddStatBonuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Bonuses",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "StatBonusGroups",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StatBonusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatBonusGroups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StatBonusGroups_Bonuses_StatBonusId",
                        column: x => x.StatBonusId,
                        principalTable: "Bonuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OneStatBonuses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatBonus = table.Column<int>(type: "int", nullable: false),
                    BonusType = table.Column<int>(type: "int", nullable: false),
                    StatBonusGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneStatBonuses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OneStatBonuses_StatBonusGroups_StatBonusGroupId",
                        column: x => x.StatBonusGroupId,
                        principalTable: "StatBonusGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OneStatBonuses_StatBonusGroupId",
                table: "OneStatBonuses",
                column: "StatBonusGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StatBonusGroups_StatBonusId",
                table: "StatBonusGroups",
                column: "StatBonusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OneStatBonuses");

            migrationBuilder.DropTable(
                name: "StatBonusGroups");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Bonuses");
        }
    }
}
