using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddSkills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Acrobatics_Value = table.Column<int>(type: "int", nullable: true),
                    Acrobatics_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    Acrobatics_Dependency = table.Column<int>(type: "int", nullable: true),
                    AnimalHandling_Value = table.Column<int>(type: "int", nullable: true),
                    AnimalHandling_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    AnimalHandling_Dependency = table.Column<int>(type: "int", nullable: true),
                    Arcana_Value = table.Column<int>(type: "int", nullable: true),
                    Arcana_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    Arcana_Dependency = table.Column<int>(type: "int", nullable: true),
                    Athletics_Value = table.Column<int>(type: "int", nullable: true),
                    Athletics_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    Athletics_Dependency = table.Column<int>(type: "int", nullable: true),
                    Deception_Value = table.Column<int>(type: "int", nullable: true),
                    Deception_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    Deception_Dependency = table.Column<int>(type: "int", nullable: true),
                    History_Value = table.Column<int>(type: "int", nullable: true),
                    History_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    History_Dependency = table.Column<int>(type: "int", nullable: true),
                    Insight_Value = table.Column<int>(type: "int", nullable: true),
                    Insight_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    Insight_Dependency = table.Column<int>(type: "int", nullable: true),
                    Intimidation_Value = table.Column<int>(type: "int", nullable: true),
                    Intimidation_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    Intimidation_Dependency = table.Column<int>(type: "int", nullable: true),
                    Investigation_Value = table.Column<int>(type: "int", nullable: true),
                    Investigation_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    Investigation_Dependency = table.Column<int>(type: "int", nullable: true),
                    Medicine_Value = table.Column<int>(type: "int", nullable: true),
                    Medicine_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    Medicine_Dependency = table.Column<int>(type: "int", nullable: true),
                    Nature_Value = table.Column<int>(type: "int", nullable: true),
                    Nature_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    Nature_Dependency = table.Column<int>(type: "int", nullable: true),
                    Perception_Value = table.Column<int>(type: "int", nullable: true),
                    Perception_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    Perception_Dependency = table.Column<int>(type: "int", nullable: true),
                    Performance_Value = table.Column<int>(type: "int", nullable: true),
                    Performance_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    Performance_Dependency = table.Column<int>(type: "int", nullable: true),
                    Persuasion_Value = table.Column<int>(type: "int", nullable: true),
                    Persuasion_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    Persuasion_Dependency = table.Column<int>(type: "int", nullable: true),
                    Religion_Value = table.Column<int>(type: "int", nullable: true),
                    Religion_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    Religion_Dependency = table.Column<int>(type: "int", nullable: true),
                    SleightOfHand_Value = table.Column<int>(type: "int", nullable: true),
                    SleightOfHand_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    SleightOfHand_Dependency = table.Column<int>(type: "int", nullable: true),
                    Stealth_Value = table.Column<int>(type: "int", nullable: true),
                    Stealth_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    Stealth_Dependency = table.Column<int>(type: "int", nullable: true),
                    Survival_Value = table.Column<int>(type: "int", nullable: true),
                    Survival_HasSkill = table.Column<bool>(type: "bit", nullable: true),
                    Survival_Dependency = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
