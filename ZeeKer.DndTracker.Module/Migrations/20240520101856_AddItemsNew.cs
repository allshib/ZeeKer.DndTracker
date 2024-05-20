using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddItemsNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Items_ArmorItemId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "CharacterStorageItem");

            migrationBuilder.CreateTable(
                name: "AssignedItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StorageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssignedItems_CharacterStorages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "CharacterStorages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AssignedItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedItems_ItemId",
                table: "AssignedItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedItems_StorageId",
                table: "AssignedItems",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AssignedItems_ArmorItemId",
                table: "Characters",
                column: "ArmorItemId",
                principalTable: "AssignedItems",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AssignedItems_ArmorItemId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "AssignedItems");

            migrationBuilder.CreateTable(
                name: "CharacterStorageItem",
                columns: table => new
                {
                    ItemsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoragesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterStorageItem", x => new { x.ItemsID, x.StoragesID });
                    table.ForeignKey(
                        name: "FK_CharacterStorageItem_CharacterStorages_StoragesID",
                        column: x => x.StoragesID,
                        principalTable: "CharacterStorages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterStorageItem_Items_ItemsID",
                        column: x => x.ItemsID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterStorageItem_StoragesID",
                table: "CharacterStorageItem",
                column: "StoragesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Items_ArmorItemId",
                table: "Characters",
                column: "ArmorItemId",
                principalTable: "Items",
                principalColumn: "ID");
        }
    }
}
