﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddSizeToSpellDescription2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripton",
                table: "Spells",
                type: "nvarchar(max)",
                maxLength: 4500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripton",
                table: "Spells",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 4500,
                oldNullable: true);
        }
    }
}
