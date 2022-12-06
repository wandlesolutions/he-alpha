using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomesEngland.AHP.Migrations
{
    /// <inheritdoc />
    public partial class GrantMilestonesToSchemeFromProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrantMilestones_Properties_PropertyId",
                table: "GrantMilestones");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequests_PropertyExpenseClaims_PropertyExpenseClaimId",
                table: "PaymentRequests");

            migrationBuilder.DropTable(
                name: "PropertyExpenseClaims");

            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "GrantMilestones",
                newName: "SchemeId");

            migrationBuilder.RenameIndex(
                name: "IX_GrantMilestones_PropertyId",
                table: "GrantMilestones",
                newName: "IX_GrantMilestones_SchemeId");

            migrationBuilder.CreateTable(
                name: "SchemeExpenseClaims",
                columns: table => new
                {
                    SchemeExpenseClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchemeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpenseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemeExpenseClaims", x => x.SchemeExpenseClaimId);
                    table.ForeignKey(
                        name: "FK_SchemeExpenseClaims_FinancialYears_FinancialYearId",
                        column: x => x.FinancialYearId,
                        principalTable: "FinancialYears",
                        principalColumn: "FinanicalYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchemeExpenseClaims_Schemes_SchemeId",
                        column: x => x.SchemeId,
                        principalTable: "Schemes",
                        principalColumn: "SchemeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchemeExpenseClaims_FinancialYearId",
                table: "SchemeExpenseClaims",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SchemeExpenseClaims_SchemeId",
                table: "SchemeExpenseClaims",
                column: "SchemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrantMilestones_Schemes_SchemeId",
                table: "GrantMilestones",
                column: "SchemeId",
                principalTable: "Schemes",
                principalColumn: "SchemeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRequests_SchemeExpenseClaims_PropertyExpenseClaimId",
                table: "PaymentRequests",
                column: "PropertyExpenseClaimId",
                principalTable: "SchemeExpenseClaims",
                principalColumn: "SchemeExpenseClaimId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrantMilestones_Schemes_SchemeId",
                table: "GrantMilestones");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequests_SchemeExpenseClaims_PropertyExpenseClaimId",
                table: "PaymentRequests");

            migrationBuilder.DropTable(
                name: "SchemeExpenseClaims");

            migrationBuilder.RenameColumn(
                name: "SchemeId",
                table: "GrantMilestones",
                newName: "PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_GrantMilestones_SchemeId",
                table: "GrantMilestones",
                newName: "IX_GrantMilestones_PropertyId");

            migrationBuilder.CreateTable(
                name: "PropertyExpenseClaims",
                columns: table => new
                {
                    PropertyExpenseClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpenseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyExpenseClaims", x => x.PropertyExpenseClaimId);
                    table.ForeignKey(
                        name: "FK_PropertyExpenseClaims_FinancialYears_FinancialYearId",
                        column: x => x.FinancialYearId,
                        principalTable: "FinancialYears",
                        principalColumn: "FinanicalYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyExpenseClaims_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyExpenseClaims_FinancialYearId",
                table: "PropertyExpenseClaims",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyExpenseClaims_PropertyId",
                table: "PropertyExpenseClaims",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrantMilestones_Properties_PropertyId",
                table: "GrantMilestones",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRequests_PropertyExpenseClaims_PropertyExpenseClaimId",
                table: "PaymentRequests",
                column: "PropertyExpenseClaimId",
                principalTable: "PropertyExpenseClaims",
                principalColumn: "PropertyExpenseClaimId");
        }
    }
}
