using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ArmorItemId",
                table: "Characters",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    AC = table.Column<int>(type: "int", nullable: true),
                    ArmorType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                });

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
                name: "IX_Characters_ArmorItemId",
                table: "Characters",
                column: "ArmorItemId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Items_ArmorItemId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "CharacterStorageItem");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ArmorItemId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ArmorItemId",
                table: "Characters");
        }
    }
}
