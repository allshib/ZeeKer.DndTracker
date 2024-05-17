using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddSkills2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acrobatics_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Acrobatics_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Acrobatics_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "AnimalHandling_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "AnimalHandling_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "AnimalHandling_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Arcana_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Arcana_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Arcana_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Athletics_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Athletics_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Athletics_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Deception_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Deception_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Deception_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "History_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "History_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "History_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Insight_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Insight_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Insight_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Intimidation_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Intimidation_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Intimidation_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Investigation_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Investigation_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Investigation_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Medicine_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Medicine_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Medicine_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Nature_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Nature_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Nature_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Perception_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Perception_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Perception_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Performance_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Performance_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Performance_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Persuasion_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Persuasion_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Persuasion_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Religion_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Religion_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Religion_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SleightOfHand_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SleightOfHand_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SleightOfHand_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Stealth_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Stealth_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Stealth_Value",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Survival_Dependency",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Survival_HasSkill",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Survival_Value",
                table: "Skills");

            migrationBuilder.CreateTable(
                name: "SkillDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    HasSkill = table.Column<bool>(type: "bit", nullable: false),
                    Dependency = table.Column<int>(type: "int", nullable: false),
                    SkillType = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SkillDetail_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillDetail_SkillsId",
                table: "SkillDetail",
                column: "SkillsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillDetail");

            migrationBuilder.AddColumn<int>(
                name: "Acrobatics_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Acrobatics_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Acrobatics_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimalHandling_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AnimalHandling_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimalHandling_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Arcana_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Arcana_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Arcana_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Athletics_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Athletics_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Athletics_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Deception_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deception_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Deception_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "History_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "History_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "History_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Insight_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Insight_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Insight_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Intimidation_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Intimidation_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Intimidation_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Investigation_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Investigation_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Investigation_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Medicine_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Medicine_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Medicine_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nature_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Nature_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nature_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Perception_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Perception_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Perception_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Performance_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Performance_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Performance_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Persuasion_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Persuasion_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Persuasion_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Religion_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Religion_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Religion_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SleightOfHand_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SleightOfHand_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SleightOfHand_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stealth_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Stealth_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stealth_Value",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Survival_Dependency",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Survival_HasSkill",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Survival_Value",
                table: "Skills",
                type: "int",
                nullable: true);
        }
    }
}
