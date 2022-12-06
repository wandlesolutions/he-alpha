﻿// <auto-generated />
using System;
using HomesEngland.AHP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomesEngland.AHP.Migrations
{
    [DbContext(typeof(AhpContext))]
    [Migration("20221206100802_GrantMilestonesToSchemeFromProperty")]
    partial class GrantMilestonesToSchemeFromProperty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HomesEngland.AHP.Data.Feature", b =>
                {
                    b.Property<Guid>("FeatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("FeatureKey")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("FeatureName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("FeatureId");

                    b.ToTable("Features", (string)null);
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.FinancialYear", b =>
                {
                    b.Property<Guid>("FinanicalYearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FinancialYearName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("FinanicalYearId");

                    b.ToTable("FinancialYears");
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.GrantMilestone", b =>
                {
                    b.Property<Guid>("GrantMilestoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("CompletionDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("FinancialYearId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("GrantAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("MilestoneTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SchemeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("TargetDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("GrantMilestoneId");

                    b.HasIndex("FinancialYearId");

                    b.HasIndex("MilestoneTypeId");

                    b.HasIndex("SchemeId");

                    b.ToTable("GrantMilestones");
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.GrantMilestoneTemplate", b =>
                {
                    b.Property<Guid>("TemplateGrantMilestoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MilestoneOrder")
                        .HasColumnType("int");

                    b.Property<Guid>("MilestoneTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Percentage")
                        .HasColumnType("decimal(16,8)");

                    b.Property<Guid>("ProgrammeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TargetNumberOfDays")
                        .HasColumnType("int");

                    b.HasKey("TemplateGrantMilestoneId");

                    b.HasIndex("MilestoneTypeId");

                    b.HasIndex("ProgrammeId");

                    b.ToTable("GrantMilestoneTemplates");
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.MilestoneType", b =>
                {
                    b.Property<Guid>("MilestoneTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("MilestoneTypeName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("MilestoneTypeId");

                    b.ToTable("MilestoneTypes");
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.PaymentRequest", b =>
                {
                    b.Property<Guid>("PaymentRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("FinancialYearId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GrantMilestoneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("PaymentDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("PropertyExpenseClaimId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PaymentRequestId");

                    b.HasIndex("FinancialYearId");

                    b.HasIndex("GrantMilestoneId");

                    b.HasIndex("PropertyExpenseClaimId");

                    b.ToTable("PaymentRequests");
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.Programme", b =>
                {
                    b.Property<Guid>("ProgrammeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Finish")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ProgrammeName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTimeOffset>("Start")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ProgrammeId");

                    b.ToTable("Programmes", (string)null);
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.ProgrammeFeature", b =>
                {
                    b.Property<Guid>("ProgrammeFeatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FeatureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProgrammeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProgrammeFeatureId");

                    b.HasIndex("FeatureId");

                    b.HasIndex("ProgrammeId");

                    b.ToTable("ProgrammeFeatures", (string)null);
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.Property", b =>
                {
                    b.Property<Guid>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address1")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Address2")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal?>("ExpensesAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("GrantAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LocalAuthority")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Postcode")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<Guid>("SchemeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PropertyId");

                    b.HasIndex("SchemeId");

                    b.ToTable("Properties", (string)null);
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.Provider", b =>
                {
                    b.Property<Guid>("ProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProviderName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("ProviderId");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.Scheme", b =>
                {
                    b.Property<Guid>("SchemeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Complete")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("Completed")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("ProgrammeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SchemeName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalExpensesAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalGrant")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SchemeId");

                    b.HasIndex("ProgrammeId");

                    b.HasIndex("ProviderId");

                    b.ToTable("Schemes", (string)null);
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.SchemeExpenseClaim", b =>
                {
                    b.Property<Guid>("SchemeExpenseClaimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ExpenseAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("FinancialYearId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SchemeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SchemeExpenseClaimId");

                    b.HasIndex("FinancialYearId");

                    b.HasIndex("SchemeId");

                    b.ToTable("SchemeExpenseClaims");
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.GrantMilestone", b =>
                {
                    b.HasOne("HomesEngland.AHP.Data.FinancialYear", "FinancialYear")
                        .WithMany()
                        .HasForeignKey("FinancialYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomesEngland.AHP.Data.MilestoneType", "MilestoneType")
                        .WithMany()
                        .HasForeignKey("MilestoneTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomesEngland.AHP.Data.Scheme", "Scheme")
                        .WithMany("GrantMilestones")
                        .HasForeignKey("SchemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinancialYear");

                    b.Navigation("MilestoneType");

                    b.Navigation("Scheme");
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.GrantMilestoneTemplate", b =>
                {
                    b.HasOne("HomesEngland.AHP.Data.MilestoneType", "MilestoneType")
                        .WithMany()
                        .HasForeignKey("MilestoneTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomesEngland.AHP.Data.Programme", "Programme")
                        .WithMany("TemplateGrantMilestones")
                        .HasForeignKey("ProgrammeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MilestoneType");

                    b.Navigation("Programme");
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.PaymentRequest", b =>
                {
                    b.HasOne("HomesEngland.AHP.Data.FinancialYear", "FinancialYear")
                        .WithMany()
                        .HasForeignKey("FinancialYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomesEngland.AHP.Data.GrantMilestone", "GrantMilestone")
                        .WithMany()
                        .HasForeignKey("GrantMilestoneId");

                    b.HasOne("HomesEngland.AHP.Data.SchemeExpenseClaim", "PropertyExpenseClaim")
                        .WithMany()
                        .HasForeignKey("PropertyExpenseClaimId");

                    b.Navigation("FinancialYear");

                    b.Navigation("GrantMilestone");

                    b.Navigation("PropertyExpenseClaim");
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.ProgrammeFeature", b =>
                {
                    b.HasOne("HomesEngland.AHP.Data.Feature", "Feature")
                        .WithMany("ProgrammeFeatures")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomesEngland.AHP.Data.Programme", "Programme")
                        .WithMany("ProgrammeFeatures")
                        .HasForeignKey("ProgrammeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");

                    b.Navigation("Programme");
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.Property", b =>
                {
                    b.HasOne("HomesEngland.AHP.Data.Scheme", "Scheme")
                        .WithMany("Properties")
                        .HasForeignKey("SchemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scheme");
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.Scheme", b =>
                {
                    b.HasOne("HomesEngland.AHP.Data.Programme", "Programme")
                        .WithMany("Schemes")
                        .HasForeignKey("ProgrammeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomesEngland.AHP.Data.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Programme");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.SchemeExpenseClaim", b =>
                {
                    b.HasOne("HomesEngland.AHP.Data.FinancialYear", "FinancialYear")
                        .WithMany()
                        .HasForeignKey("FinancialYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomesEngland.AHP.Data.Scheme", "Scheme")
                        .WithMany()
                        .HasForeignKey("SchemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinancialYear");

                    b.Navigation("Scheme");
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.Feature", b =>
                {
                    b.Navigation("ProgrammeFeatures");
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.Programme", b =>
                {
                    b.Navigation("ProgrammeFeatures");

                    b.Navigation("Schemes");

                    b.Navigation("TemplateGrantMilestones");
                });

            modelBuilder.Entity("HomesEngland.AHP.Data.Scheme", b =>
                {
                    b.Navigation("GrantMilestones");

                    b.Navigation("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}
