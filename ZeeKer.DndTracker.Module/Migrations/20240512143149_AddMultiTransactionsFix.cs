using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddMultiTransactionsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionSettings_MultipleTransaction_MultipleTransactionID",
                table: "TransactionSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionSettings_TransactionSettings_TransactionId",
                table: "TransactionSettings");

            migrationBuilder.DropIndex(
                name: "IX_TransactionSettings_MultipleTransactionID",
                table: "TransactionSettings");

            migrationBuilder.DropColumn(
                name: "MultipleTransactionID",
                table: "TransactionSettings");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionSettings_MultipleTransaction_TransactionId",
                table: "TransactionSettings",
                column: "TransactionId",
                principalTable: "MultipleTransaction",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionSettings_MultipleTransaction_TransactionId",
                table: "TransactionSettings");

            migrationBuilder.AddColumn<Guid>(
                name: "MultipleTransactionID",
                table: "TransactionSettings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSettings_MultipleTransactionID",
                table: "TransactionSettings",
                column: "MultipleTransactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionSettings_MultipleTransaction_MultipleTransactionID",
                table: "TransactionSettings",
                column: "MultipleTransactionID",
                principalTable: "MultipleTransaction",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionSettings_TransactionSettings_TransactionId",
                table: "TransactionSettings",
                column: "TransactionId",
                principalTable: "TransactionSettings",
                principalColumn: "ID");
        }
    }
}
