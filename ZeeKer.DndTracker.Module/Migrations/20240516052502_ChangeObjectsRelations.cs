using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class ChangeObjectsRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterClasses_ClassId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Persons_PersonId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionPolicyUser_Persons_PersonId",
                table: "PermissionPolicyUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterClasses_ClassId",
                table: "Characters",
                column: "ClassId",
                principalTable: "CharacterClasses",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Persons_PersonId",
                table: "Characters",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionPolicyUser_Persons_PersonId",
                table: "PermissionPolicyUser",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterClasses_ClassId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Persons_PersonId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionPolicyUser_Persons_PersonId",
                table: "PermissionPolicyUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterClasses_ClassId",
                table: "Characters",
                column: "ClassId",
                principalTable: "CharacterClasses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Persons_PersonId",
                table: "Characters",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionPolicyUser_Persons_PersonId",
                table: "PermissionPolicyUser",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "ID");
        }
    }
}
