using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationProfiencyItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfiencyId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProfiencyId",
                table: "Items",
                column: "ProfiencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Profiencies_ProfiencyId",
                table: "Items",
                column: "ProfiencyId",
                principalTable: "Profiencies",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Profiencies_ProfiencyId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ProfiencyId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ProfiencyId",
                table: "Items");
        }
    }
}
