using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomesEngland.AHP.Migrations
{
    /// <inheritdoc />
    public partial class ExpensesToRevenueRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequests_SchemeExpenseClaims_PropertyExpenseClaimId",
                table: "PaymentRequests");

            migrationBuilder.DropTable(
                name: "SchemeExpenseClaims");

            migrationBuilder.RenameColumn(
                name: "TotalGrant",
                table: "Schemes",
                newName: "TotalRevenueFundingAmount");

            migrationBuilder.RenameColumn(
                name: "TotalExpensesAmount",
                table: "Schemes",
                newName: "TotalGrantAmount");

            migrationBuilder.RenameColumn(
                name: "GrantAmount",
                table: "GrantMilestones",
                newName: "MilestoneGrantAmount");

            migrationBuilder.CreateTable(
                name: "SchemeRevenueClaims",
                columns: table => new
                {
                    SchemeRevenueClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchemeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemeRevenueClaims", x => x.SchemeRevenueClaimId);
                    table.ForeignKey(
                        name: "FK_SchemeRevenueClaims_FinancialYears_FinancialYearId",
                        column: x => x.FinancialYearId,
                        principalTable: "FinancialYears",
                        principalColumn: "FinanicalYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchemeRevenueClaims_Schemes_SchemeId",
                        column: x => x.SchemeId,
                        principalTable: "Schemes",
                        principalColumn: "SchemeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchemeRevenueClaims_FinancialYearId",
                table: "SchemeRevenueClaims",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SchemeRevenueClaims_SchemeId",
                table: "SchemeRevenueClaims",
                column: "SchemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRequests_SchemeRevenueClaims_PropertyExpenseClaimId",
                table: "PaymentRequests",
                column: "PropertyExpenseClaimId",
                principalTable: "SchemeRevenueClaims",
                principalColumn: "SchemeRevenueClaimId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequests_SchemeRevenueClaims_PropertyExpenseClaimId",
                table: "PaymentRequests");

            migrationBuilder.DropTable(
                name: "SchemeRevenueClaims");

            migrationBuilder.RenameColumn(
                name: "TotalRevenueFundingAmount",
                table: "Schemes",
                newName: "TotalGrant");

            migrationBuilder.RenameColumn(
                name: "TotalGrantAmount",
                table: "Schemes",
                newName: "TotalExpensesAmount");

            migrationBuilder.RenameColumn(
                name: "MilestoneGrantAmount",
                table: "GrantMilestones",
                newName: "GrantAmount");

            migrationBuilder.CreateTable(
                name: "SchemeExpenseClaims",
                columns: table => new
                {
                    SchemeExpenseClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchemeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpenseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "FK_PaymentRequests_SchemeExpenseClaims_PropertyExpenseClaimId",
                table: "PaymentRequests",
                column: "PropertyExpenseClaimId",
                principalTable: "SchemeExpenseClaims",
                principalColumn: "SchemeExpenseClaimId");
        }
    }
}
