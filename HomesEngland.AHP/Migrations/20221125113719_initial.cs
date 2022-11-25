using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomesEngland.AHP.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeatureName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    FeatureKey = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.FeatureId);
                });

            migrationBuilder.CreateTable(
                name: "FinancialYears",
                columns: table => new
                {
                    FinanicalYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialYearName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialYears", x => x.FinanicalYearId);
                });

            migrationBuilder.CreateTable(
                name: "MilestoneTypes",
                columns: table => new
                {
                    MilestoneTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MilestoneName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilestoneTypes", x => x.MilestoneTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Programmes",
                columns: table => new
                {
                    ProgrammeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgrammeName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Start = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Finish = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programmes", x => x.ProgrammeId);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderId);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammeFeatures",
                columns: table => new
                {
                    ProgrammeFeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgrammeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammeFeatures", x => x.ProgrammeFeatureId);
                    table.ForeignKey(
                        name: "FK_ProgrammeFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "FeatureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgrammeFeatures_Programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "Programmes",
                        principalColumn: "ProgrammeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateGrantMilestone",
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

            migrationBuilder.CreateTable(
                name: "Schemes",
                columns: table => new
                {
                    SchemeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchemeName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgrammeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalGrant = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalExpensesAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Complete = table.Column<bool>(type: "bit", nullable: false),
                    Completed = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schemes", x => x.SchemeId);
                    table.ForeignKey(
                        name: "FK_Schemes_Programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "Programmes",
                        principalColumn: "ProgrammeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schemes_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    ProperyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    SchemeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    LocalAuthority = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    GrantAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpensesAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.ProperyId);
                    table.ForeignKey(
                        name: "FK_Properties_Schemes_SchemeId",
                        column: x => x.SchemeId,
                        principalTable: "Schemes",
                        principalColumn: "SchemeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrantMilestones",
                columns: table => new
                {
                    GrantMilestoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    GrantAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MilestoneTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrantMilestones", x => x.GrantMilestoneId);
                    table.ForeignKey(
                        name: "FK_GrantMilestones_FinancialYears_FinancialYearId",
                        column: x => x.FinancialYearId,
                        principalTable: "FinancialYears",
                        principalColumn: "FinanicalYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrantMilestones_MilestoneTypes_MilestoneTypeId",
                        column: x => x.MilestoneTypeId,
                        principalTable: "MilestoneTypes",
                        principalColumn: "MilestoneTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrantMilestones_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "ProperyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyExpenseClaims",
                columns: table => new
                {
                    PropertyExpenseClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpenseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                        principalColumn: "ProperyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRequests",
                columns: table => new
                {
                    PaymentRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PropertyExpenseClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GrantMilestoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRequests", x => x.PaymentRequestId);
                    table.ForeignKey(
                        name: "FK_PaymentRequests_FinancialYears_FinancialYearId",
                        column: x => x.FinancialYearId,
                        principalTable: "FinancialYears",
                        principalColumn: "FinanicalYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentRequests_GrantMilestones_GrantMilestoneId",
                        column: x => x.GrantMilestoneId,
                        principalTable: "GrantMilestones",
                        principalColumn: "GrantMilestoneId");
                    table.ForeignKey(
                        name: "FK_PaymentRequests_PropertyExpenseClaims_PropertyExpenseClaimId",
                        column: x => x.PropertyExpenseClaimId,
                        principalTable: "PropertyExpenseClaims",
                        principalColumn: "PropertyExpenseClaimId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrantMilestones_FinancialYearId",
                table: "GrantMilestones",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_GrantMilestones_MilestoneTypeId",
                table: "GrantMilestones",
                column: "MilestoneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GrantMilestones_PropertyId",
                table: "GrantMilestones",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequests_FinancialYearId",
                table: "PaymentRequests",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequests_GrantMilestoneId",
                table: "PaymentRequests",
                column: "GrantMilestoneId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequests_PropertyExpenseClaimId",
                table: "PaymentRequests",
                column: "PropertyExpenseClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeFeatures_FeatureId",
                table: "ProgrammeFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeFeatures_ProgrammeId",
                table: "ProgrammeFeatures",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_SchemeId",
                table: "Properties",
                column: "SchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyExpenseClaims_FinancialYearId",
                table: "PropertyExpenseClaims",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyExpenseClaims_PropertyId",
                table: "PropertyExpenseClaims",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Schemes_ProgrammeId",
                table: "Schemes",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schemes_ProviderId",
                table: "Schemes",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateGrantMilestone_MilestoneTypeId",
                table: "TemplateGrantMilestone",
                column: "MilestoneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateGrantMilestone_ProgrammeId",
                table: "TemplateGrantMilestone",
                column: "ProgrammeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentRequests");

            migrationBuilder.DropTable(
                name: "ProgrammeFeatures");

            migrationBuilder.DropTable(
                name: "TemplateGrantMilestone");

            migrationBuilder.DropTable(
                name: "GrantMilestones");

            migrationBuilder.DropTable(
                name: "PropertyExpenseClaims");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "MilestoneTypes");

            migrationBuilder.DropTable(
                name: "FinancialYears");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Schemes");

            migrationBuilder.DropTable(
                name: "Programmes");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
