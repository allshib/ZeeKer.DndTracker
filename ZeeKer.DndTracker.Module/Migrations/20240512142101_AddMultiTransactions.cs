using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddMultiTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MultipleTransaction",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleTransaction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MultipleTransaction_CharacterStorages_StorageSourceId",
                        column: x => x.StorageSourceId,
                        principalTable: "CharacterStorages",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TransactionSettings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OperationType = table.Column<int>(type: "int", nullable: false),
                    Coins = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StorageDestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MultipleTransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionSettings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TransactionSettings_CharacterStorages_StorageDestinationId",
                        column: x => x.StorageDestinationId,
                        principalTable: "CharacterStorages",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TransactionSettings_MultipleTransaction_MultipleTransactionID",
                        column: x => x.MultipleTransactionID,
                        principalTable: "MultipleTransaction",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TransactionSettings_TransactionSettings_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "TransactionSettings",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MultipleTransaction_StorageSourceId",
                table: "MultipleTransaction",
                column: "StorageSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSettings_MultipleTransactionID",
                table: "TransactionSettings",
                column: "MultipleTransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSettings_StorageDestinationId",
                table: "TransactionSettings",
                column: "StorageDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSettings_TransactionId",
                table: "TransactionSettings",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionSettings");

            migrationBuilder.DropTable(
                name: "MultipleTransaction");
        }
    }
}
