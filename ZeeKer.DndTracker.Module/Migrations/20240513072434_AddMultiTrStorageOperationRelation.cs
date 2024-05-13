using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddMultiTrStorageOperationRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MultiTransactionId",
                table: "StorageOperations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageOperations_MultiTransactionId",
                table: "StorageOperations",
                column: "MultiTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageOperations_MultipleTransaction_MultiTransactionId",
                table: "StorageOperations",
                column: "MultiTransactionId",
                principalTable: "MultipleTransaction",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageOperations_MultipleTransaction_MultiTransactionId",
                table: "StorageOperations");

            migrationBuilder.DropIndex(
                name: "IX_StorageOperations_MultiTransactionId",
                table: "StorageOperations");

            migrationBuilder.DropColumn(
                name: "MultiTransactionId",
                table: "StorageOperations");
        }
    }
}
