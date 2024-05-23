using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddProfiencies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiencies",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ProfiencyType = table.Column<int>(type: "int", nullable: false),
                    NeedSelectObject = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiencies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AssignedProfiencies",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfiencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedProfiencies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssignedProfiencies_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedProfiencies_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AssignedProfiencies_Profiencies_ProfiencyId",
                        column: x => x.ProfiencyId,
                        principalTable: "Profiencies",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedProfiencies_CharacterId",
                table: "AssignedProfiencies",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedProfiencies_ItemId",
                table: "AssignedProfiencies",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedProfiencies_ProfiencyId",
                table: "AssignedProfiencies",
                column: "ProfiencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedProfiencies");

            migrationBuilder.DropTable(
                name: "Profiencies");
        }
    }
}
