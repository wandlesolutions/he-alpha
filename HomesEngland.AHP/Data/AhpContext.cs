using Microsoft.EntityFrameworkCore;

namespace HomesEngland.AHP.Data;

public class AhpContext : DbContext
{
	public AhpContext(DbContextOptions<AhpContext> options)
			: base(options)
	{
	}

	public DbSet<Programme>? Programmes { get; set; }

	public DbSet<Feature>? Features { get; set; }

	public DbSet<ProgrammeFeature> ProgrammeFeatures { get; set; }

	public DbSet<Provider> Providers { get; set; }

	public DbSet<Scheme> Schemes { get; set; }

	public DbSet<Property> Properties { get; set; }
	public DbSet<MilestoneType> MilestoneTypes { get; set; }
	public DbSet<GrantMilestone> GrantMilestones { get; set; }
	public DbSet<GrantMilestoneTemplate> GrantMilestoneTemplates { get; set; }

	public DbSet<SchemeRevenueClaim> SchemeRevenueClaims { get; set; }

	public DbSet<FinancialYear> FinancialYears { get; set; }
	public DbSet<PaymentRequest> PaymentRequests { get; set; }

	public DbSet<LocalAuthority> LocalAuthorities { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Feature>().ToTable("Features");
		modelBuilder.Entity<Programme>().ToTable("Programmes");
		modelBuilder.Entity<ProgrammeFeature>().ToTable("ProgrammeFeatures");
		modelBuilder.Entity<Scheme>().ToTable("Schemes");
		modelBuilder.Entity<Property>().ToTable("Properties");
		modelBuilder.Entity<LocalAuthority>().ToTable("LocalAuthorities");
	}
}
