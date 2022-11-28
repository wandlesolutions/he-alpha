using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomesEngland.AHP.Migrations
{
    /// <inheritdoc />
    public partial class GrantTemplateMilestonesRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateGrantMilestone");

            migrationBuilder.RenameColumn(
                name: "MilestoneName",
                table: "MilestoneTypes",
                newName: "MilestoneTypeName");

            migrationBuilder.CreateTable(
                name: "GrantMilestoneTemplates",
                columns: table => new
                {
                    TemplateGrantMilestoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MilestoneTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgrammeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(16,8)", nullable: false),
                    MilestoneOrder = table.Column<int>(type: "int", nullable: false),
                    TargetNumberOfDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrantMilestoneTemplates", x => x.TemplateGrantMilestoneId);
                    table.ForeignKey(
                        name: "FK_GrantMilestoneTemplates_MilestoneTypes_MilestoneTypeId",
                        column: x => x.MilestoneTypeId,
                        principalTable: "MilestoneTypes",
                        principalColumn: "MilestoneTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrantMilestoneTemplates_Programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "Programmes",
                        principalColumn: "ProgrammeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrantMilestoneTemplates_MilestoneTypeId",
                table: "GrantMilestoneTemplates",
                column: "MilestoneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GrantMilestoneTemplates_ProgrammeId",
                table: "GrantMilestoneTemplates",
                column: "ProgrammeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrantMilestoneTemplates");

            migrationBuilder.RenameColumn(
                name: "MilestoneTypeName",
                table: "MilestoneTypes",
                newName: "MilestoneName");

            migrationBuilder.CreateTable(
                name: "TemplateGrantMilestone",
                columns: table => new
                {
                    TemplateGrantMilestoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MilestoneTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgrammeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MilestoneOrder = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(16,8)", nullable: false),
                    TargetNumberOfDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateGrantMilestone", x => x.TemplateGrantMilestoneId);
                    table.ForeignKey(
                        name: "FK_TemplateGrantMilestone_MilestoneTypes_MilestoneTypeId",
                        column: x => x.MilestoneTypeId,
                        principalTable: "MilestoneTypes",
                        principalColumn: "MilestoneTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateGrantMilestone_Programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "Programmes",
                        principalColumn: "ProgrammeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateGrantMilestone_MilestoneTypeId",
                table: "TemplateGrantMilestone",
                column: "MilestoneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateGrantMilestone_ProgrammeId",
                table: "TemplateGrantMilestone",
                column: "ProgrammeId");
        }
    }
}
