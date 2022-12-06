using Microsoft.EntityFrameworkCore;

namespace HomesEngland.AHP.Data;

public class SqlGrantRepository : IGrantRepository
{
	private IDbContextFactory<AhpContext> _factory;

	public SqlGrantRepository(IDbContextFactory<AhpContext> ahpContextFactory)
	{
		_factory = ahpContextFactory;
	}

	private AhpContext GetContext()
	{
		return _factory.CreateDbContext();
	}

	public async Task<Feature> CreateFeature(Feature feature)
	{
		using var context = GetContext();

		context.Features.Add(feature);
		await context.SaveChangesAsync();
		return feature;
	}

	public async Task<FinancialYear> CreateFinancialYear(FinancialYear feature)
	{
		using var context = GetContext();

		context.FinancialYears.Add(feature);
		await context.SaveChangesAsync();
		return feature;
	}

	public async Task CreateGrantMilestones(IEnumerable<GrantMilestone> milestones)
	{
		using var context = GetContext();

		context.GrantMilestones.AddRange(milestones);
		await context.SaveChangesAsync();
	}

	public async Task<GrantMilestoneTemplate> CreateGrantMilestoneTemplate(GrantMilestoneTemplate feature)
	{
		using var context = GetContext();

		context.GrantMilestoneTemplates.Add(feature);
		await context.SaveChangesAsync();
		return feature;
	}

	public async Task<MilestoneType> CreateMilestoneType(MilestoneType milestoneType)
	{
		using var context = GetContext();

		context.MilestoneTypes.Add(milestoneType);
		await context.SaveChangesAsync();
		return milestoneType;
	}

	public async Task<Programme> CreateProgramme(Programme programme)
	{
		using var context = GetContext();

		await context.Programmes.AddAsync(programme);
		await context.SaveChangesAsync();
		return programme;
	}

	public async Task<ProgrammeFeature> CreateProgrammeFeature(ProgrammeFeature programmeFeature)
	{
		using var context = GetContext();

		await context.ProgrammeFeatures.AddAsync(programmeFeature);
		await context.SaveChangesAsync();
		return programmeFeature;
	}

	public async Task<Property> CreateProperty(Property property)
	{
		using var context = GetContext();

		await context.Properties.AddAsync(property);
		await context.SaveChangesAsync();
		return property;
	}

	public async Task<Provider> CreateProvider(Provider provider)
	{
		using var context = GetContext();

		await context.Providers.AddAsync(provider);
		await context.SaveChangesAsync();
		return provider;
	}

	public async Task<Scheme> CreateScheme(Scheme scheme)
	{
		using var context = GetContext();

		await context.Schemes.AddAsync(scheme);
		await context.SaveChangesAsync();
		return scheme;
	}

	public async Task DeleteProgrammeFeature(Guid programmeFeatureId)
	{
		using var context = GetContext();

		var programmeFeature = await context.ProgrammeFeatures
			.Where(_ => _.ProgrammeFeatureId == programmeFeatureId)
			.ExecuteDeleteAsync();
		await context.SaveChangesAsync();
	}

	public async Task<IEnumerable<Feature>> GetFeatures()
	{
		using var context = GetContext();

		return await context.Features.OrderBy(_ => _.FeatureName).ToListAsync();
	}

	public async Task<IEnumerable<FinancialYear>> GetFinancialYears()
	{
		using var context = GetContext();

		return await context.FinancialYears
			.ToListAsync();
	}

	public async Task<GrantMilestone?> GetGrantMilestone(Guid grantMilestoneId)
	{
		using var context = GetContext();

		return await context.GrantMilestones
			.Include(_ => _.FinancialYear)
			.Include(_ => _.MilestoneType)
			.Include(_ => _.Scheme)
			.SingleOrDefaultAsync(_ => _.GrantMilestoneId == grantMilestoneId);
	}

	public async Task<IEnumerable<GrantMilestone>> GetGrantMilestones(Guid schemeId)
	{
		using var context = GetContext();

		return await context.GrantMilestones
			.Include(_ => _.MilestoneType)
			.Include(_ => _.FinancialYear)
			.Where(_ => _.SchemeId == schemeId)
			.ToListAsync();
	}

	public async Task<IEnumerable<GrantMilestoneTemplate>> GetGrantMilestoneTemplates(Guid programmeId)
	{
		using var context = GetContext();

		return await context.GrantMilestoneTemplates
			.Include(_ => _.MilestoneType)
			.Where(_ => _.ProgrammeId == programmeId)
			.OrderBy(_ => _.MilestoneOrder)
			.ToListAsync();
	}

	public async Task<IEnumerable<MilestoneType>> GetGrantMilestoneTemplateTypes()
	{
		using var context = GetContext();

		return await context.MilestoneTypes
			.OrderBy(_ => _.MilestoneTypeName)
			.ToListAsync();
	}

	public async Task<Programme?> GetProgramme(Guid programmeId)
	{
		using var context = GetContext();

		return await context.Programmes.SingleOrDefaultAsync(_ => _.ProgrammeId == programmeId);
	}

	public async Task<IEnumerable<ProgrammeFeature>> GetProgrammeFeatures(Guid programmeId)
	{
		using var context = GetContext();

		return await context.ProgrammeFeatures.Where(_ => _.ProgrammeId == programmeId).ToListAsync();
	}

	public async Task<IEnumerable<Programme>> GetProgrammes()
	{
		using var context = GetContext();

		return await context.Programmes?.OrderBy(_ => _.ProgrammeName).ToListAsync();
	}

	public async Task<IEnumerable<Programme>> GetProgrammesAssociatedToSchemesForProvider(Guid providerId)
	{
		using var context = GetContext();

		return await context.Schemes
			.Where(_ => _.ProviderId == providerId)
			.Select(_ => _.Programme)
			.Distinct()
			.ToListAsync();
	}

	public async Task<IEnumerable<Programme>> GetProgrammesWithProviderSchemeCreationEnabled()
	{
		using var context = GetContext();

		// Return programmes where feature key has value of 'ProviderCanCreateSchemes'
		return await context.ProgrammeFeatures
			.Where(_ => _.Feature.FeatureKey == FeatureToggles.ProviderCanCreateSchemes)
			.Select(_ => _.Programme)
			.Distinct()
			.OrderBy(_ => _.ProgrammeName)
			.ToListAsync();
	}

	public async Task<IEnumerable<Property>> GetPropertiesForProvider(Guid providerId)
	{
		using var context = GetContext();

		// Get properties for a provider, ordered by schemeName, then property name
		return await context.Properties
			.Include(_ => _.Scheme)
			.Include(_ => _.Scheme.Programme)
			.Where(_ => _.Scheme.ProviderId == providerId)
			.OrderBy(_ => _.Scheme.SchemeName)
			.ThenBy(_ => _.PropertyName)
			.ToListAsync();
	}

	public async Task<Property?> GetProperty(Guid propertyId)
	{
		using var context = GetContext();

		return await context.Properties
			.Include(_ => _.Scheme)
			.SingleOrDefaultAsync(_ => _.PropertyId == propertyId);
	}

	public async Task<Property?> GetPropertyForProvider(Guid propertyId, Guid providerId)
	{
		using var context = GetContext();

		return await context.Properties
			.Include(_ => _.Scheme)
			.Include(_ => _.Scheme.Programme)
			.Where(_ => _.Scheme.ProviderId == providerId && _.PropertyId == propertyId)
			.SingleOrDefaultAsync();
	}

	public async Task<Provider?> GetProvider(Guid providerId)
	{
		using var context = GetContext();

		return await context.Providers.SingleOrDefaultAsync(_ => _.ProviderId == providerId);
	}

	public async Task<IEnumerable<Provider>> GetProviders()
	{
		using var context = GetContext();

		return await context.Providers?.OrderBy(_ => _.ProviderName).ToListAsync();
	}

	public async Task<IEnumerable<Scheme>> GetSchemesForProgrammeForProvider(Guid programmeId, Guid providerId)
	{
		using var context = GetContext();

		return await context.Schemes
			.Where(_ => _.ProgrammeId == programmeId && _.ProviderId == providerId)
			.ToListAsync();
	}

	public async Task<IEnumerable<Scheme>> GetSchemesForProvider(Guid providerId)
	{
		using var context = GetContext();

		return await context.Schemes
			.Include(_ => _.Programme)
			.Where(_ => _.ProviderId == providerId)
			.OrderBy(_ => _.SchemeName)
			.ToListAsync();
	}

	public async Task UpdateGrantMilestoneDate(Guid grantMilestoneId, DateTimeOffset targetDate)
	{
		using var context = GetContext();

		int records = await context.GrantMilestones
			.Where(_ => _.GrantMilestoneId == grantMilestoneId)
			.ExecuteUpdateAsync(_ => _.SetProperty(p => p.TargetDate, targetDate));

		await context.SaveChangesAsync();

		if (records != 1)
		{
			throw new InvalidOperationException("Grant milestone not found");
		}
	}

	public async Task ClearData()
	{
		using var context = GetContext();

		await context.Database.ExecuteSqlRawAsync("DELETE FROM PaymentRequests");
		await context.Database.ExecuteSqlRawAsync("DELETE FROM FinancialYears");
		await context.Database.ExecuteSqlRawAsync("DELETE FROM PropertyExpenseClaims");
		await context.Database.ExecuteSqlRawAsync("DELETE FROM GrantMilestones");
		await context.Database.ExecuteSqlRawAsync("DELETE FROM GrantMilestoneTemplates");
		await context.Database.ExecuteSqlRawAsync("DELETE FROM MilestoneTypes");
		await context.Database.ExecuteSqlRawAsync("DELETE FROM Properties");
		await context.Database.ExecuteSqlRawAsync("DELETE FROM Schemes");
		await context.Database.ExecuteSqlRawAsync("DELETE FROM Providers");

		await context.Database.ExecuteSqlRawAsync("DELETE FROM ProgrammeFeatures");
		await context.Database.ExecuteSqlRawAsync("DELETE FROM Features");
		await context.Database.ExecuteSqlRawAsync("DELETE FROM Programmes");

	}

	public async Task<Scheme?> GetScheme(Guid schemeId)
	{
		using var context = GetContext();

		return await context.Schemes
			.Include(_ => _.Programme)
			.SingleOrDefaultAsync(_ => _.SchemeId == schemeId);
	}
}
