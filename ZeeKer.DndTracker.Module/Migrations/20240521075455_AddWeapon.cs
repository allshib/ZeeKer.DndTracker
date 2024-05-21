using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddWeapon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Fencing",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HandWeaponType",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainDamageType",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Special",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Throwing",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeaponRangeType",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeightWeaponType",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HandLeftId",
                table: "Characters",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HandRightId",
                table: "Characters",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HandLeftId",
                table: "Characters",
                column: "HandLeftId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HandRightId",
                table: "Characters",
                column: "HandRightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AssignedItems_HandLeftId",
                table: "Characters",
                column: "HandLeftId",
                principalTable: "AssignedItems",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AssignedItems_HandRightId",
                table: "Characters",
                column: "HandRightId",
                principalTable: "AssignedItems",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AssignedItems_HandLeftId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AssignedItems_HandRightId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_HandLeftId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_HandRightId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Fencing",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "HandWeaponType",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MainDamageType",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Special",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Throwing",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "WeaponRangeType",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "WeightWeaponType",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "HandLeftId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "HandRightId",
                table: "Characters");
        }
    }
}
