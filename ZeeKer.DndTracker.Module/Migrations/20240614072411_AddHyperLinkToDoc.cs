using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddHyperLinkToDoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "DocumentationInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Hyperlinks",
                type: "nvarchar(34)",
                maxLength: 34,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(21)",
                oldMaxLength: 21);

            migrationBuilder.AddColumn<Guid>(
                name: "HyperLinkID",
                table: "DocumentationInfo",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentationInfo_HyperLinkID",
                table: "DocumentationInfo",
                column: "HyperLinkID");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentationInfo_Hyperlinks_HyperLinkID",
                table: "DocumentationInfo",
                column: "HyperLinkID",
                principalTable: "Hyperlinks",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentationInfo_Hyperlinks_HyperLinkID",
                table: "DocumentationInfo");

            migrationBuilder.DropIndex(
                name: "IX_DocumentationInfo_HyperLinkID",
                table: "DocumentationInfo");

            migrationBuilder.DropColumn(
                name: "HyperLinkID",
                table: "DocumentationInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Hyperlinks",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(34)",
                oldMaxLength: 34);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "DocumentationInfo",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
