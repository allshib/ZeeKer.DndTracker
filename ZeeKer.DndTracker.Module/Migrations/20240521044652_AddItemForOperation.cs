using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddItemForOperation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "StorageOperations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageOperations_ItemId",
                table: "StorageOperations",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageOperations_AssignedItems_ItemId",
                table: "StorageOperations",
                column: "ItemId",
                principalTable: "AssignedItems",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageOperations_AssignedItems_ItemId",
                table: "StorageOperations");

            migrationBuilder.DropIndex(
                name: "IX_StorageOperations_ItemId",
                table: "StorageOperations");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "StorageOperations");
        }
    }
}
