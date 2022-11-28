using Microsoft.EntityFrameworkCore;

namespace HomesEngland.AHP.Data;

public class SqlGrantRepository : IGrantRepository
{
	private readonly AhpContext _context;

	public SqlGrantRepository(AhpContext ahpContext)
	{
		_context = ahpContext;
	}

	public async Task<Feature> CreateFeature(Feature feature)
	{
		_context.Features.Add(feature);
		await _context.SaveChangesAsync();
		return feature;
	}

	public async Task<FinancialYear> CreateFinancialYear(FinancialYear feature)
	{
		_context.FinancialYears.Add(feature);
		await _context.SaveChangesAsync();
		return feature;
	}

	public async Task CreateGrantMilestones(IEnumerable<GrantMilestone> milestones)
	{
		_context.GrantMilestones.AddRange(milestones);
		await _context.SaveChangesAsync();
	}

	public async Task<GrantMilestoneTemplate> CreateGrantMilestoneTemplate(GrantMilestoneTemplate feature)
	{
		_context.GrantMilestoneTemplates.Add(feature);
		await _context.SaveChangesAsync();
		return feature;
	}

	public async Task<MilestoneType> CreateMilestoneType(MilestoneType milestoneType)
	{
		_context.MilestoneTypes.Add(milestoneType);
		await _context.SaveChangesAsync();
		return milestoneType;
	}

	public async Task<Programme> CreateProgramme(Programme programme)
	{
		await _context.Programmes.AddAsync(programme);
		await _context.SaveChangesAsync();
		return programme;
	}

	public async Task<ProgrammeFeature> CreateProgrammeFeature(ProgrammeFeature programmeFeature)
	{
		await _context.ProgrammeFeatures.AddAsync(programmeFeature);
		await _context.SaveChangesAsync();
		return programmeFeature;
	}

	public async Task<Property> CreateProperty(Property property)
	{
		await _context.Properties.AddAsync(property);
		await _context.SaveChangesAsync();
		return property;
	}

	public async Task<Provider> CreateProvider(Provider provider)
	{
		await _context.Providers.AddAsync(provider);
		await _context.SaveChangesAsync();
		return provider;
	}

	public async Task<Scheme> CreateScheme(Scheme scheme)
	{
		await _context.Schemes.AddAsync(scheme);
		await _context.SaveChangesAsync();
		return scheme;
	}

	public async Task DeleteProgrammeFeature(Guid programmeFeatureId)
	{
		var programmeFeature = await _context.ProgrammeFeatures
			.Where(_ => _.ProgrammeFeatureId == programmeFeatureId)
			.ExecuteDeleteAsync();
		await _context.SaveChangesAsync();
	}

	public async Task<IEnumerable<Feature>> GetFeatures()
	{
		return await _context.Features.OrderBy(_ => _.FeatureName).ToListAsync();
	}

	public async Task<IEnumerable<FinancialYear>> GetFinancialYears()
	{
		return await _context.FinancialYears
			.ToListAsync();
	}

	public async Task<IEnumerable<GrantMilestone>> GetGrantMilestones(Guid propertyId)
	{
		return await _context.GrantMilestones
			.Include(_ => _.MilestoneType)
			.Include(_ => _.FinancialYear)
			.Where(_ => _.PropertyId == propertyId)
			.ToListAsync();
	}

	public async Task<IEnumerable<GrantMilestoneTemplate>> GetGrantMilestoneTemplates(Guid programmeId)
	{
		return await _context.GrantMilestoneTemplates
			.Include(_ => _.MilestoneType)
			.Where(_ => _.ProgrammeId == programmeId)
			.OrderBy(_ => _.MilestoneOrder)
			.ToListAsync();
	}

	public async Task<IEnumerable<MilestoneType>> GetGrantMilestoneTemplateTypes()
	{
		return await _context.MilestoneTypes
			.OrderBy(_ => _.MilestoneTypeName)
			.ToListAsync();
	}

	public async Task<Programme?> GetProgramme(Guid programmeId)
	{
		return await _context.Programmes.SingleOrDefaultAsync(_ => _.ProgrammeId == programmeId);
	}

	public async Task<IEnumerable<ProgrammeFeature>> GetProgrammeFeatures(Guid programmeId)
	{
		return await _context.ProgrammeFeatures.Where(_ => _.ProgrammeId == programmeId).ToListAsync();
	}

	public async Task<IEnumerable<Programme>> GetProgrammes()
	{
		return await _context.Programmes?.OrderBy(_ => _.ProgrammeName).ToListAsync();
	}

	public async Task<IEnumerable<Programme>> GetProgrammesAssociatedToSchemesForProvider(Guid providerId)
	{
		return await _context.Schemes
			.Where(_ => _.ProviderId == providerId)
			.Select(_ => _.Programme)
			.Distinct()
			.ToListAsync();
	}

	public async Task<IEnumerable<Programme>> GetProgrammesWithProviderSchemeCreationEnabled()
	{
		// Return programmes where feature key has value of 'ProviderCanCreateSchemes'
		return await _context.ProgrammeFeatures
			.Where(_ => _.Feature.FeatureKey == FeatureToggles.ProviderCanCreateSchemes)
			.Select(_ => _.Programme)
			.Distinct()
			.ToListAsync();
	}

	public async Task<IEnumerable<Property>> GetPropertiesForProvider(Guid providerId)
	{
		// Get properties for a provider, ordered by schemeName, then property name
		return await _context.Properties
			.Include(_ => _.Scheme)
			.Include(_ => _.Scheme.Programme)
			.Where(_ => _.Scheme.ProviderId == providerId)
			.OrderBy(_ => _.Scheme.SchemeName)
			.ThenBy(_ => _.PropertyName)
			.ToListAsync();
	}

	public async Task<Property?> GetProperty(Guid propertyId)
	{
		return await _context.Properties.SingleOrDefaultAsync(_ => _.PropertyId == propertyId);
	}

	public async Task<Property?> GetPropertyForProvider(Guid propertyId, Guid providerId)
	{
		return await _context.Properties
			.Include(_ => _.Scheme)
			.Include(_ => _.Scheme.Programme)
			.Where(_ => _.Scheme.ProviderId == providerId && _.PropertyId == propertyId)
			.SingleOrDefaultAsync();
	}

	public async Task<Provider?> GetProvider(Guid providerId)
	{
		return await _context.Providers.SingleOrDefaultAsync(_ => _.ProviderId == providerId);
	}

	public async Task<IEnumerable<Provider>> GetProviders()
	{
		return await _context.Providers?.OrderBy(_ => _.ProviderName).ToListAsync();
	}

	public async Task<IEnumerable<Scheme>> GetSchemesForProgrammeForProvider(Guid programmeId, Guid providerId)
	{
		return await _context.Schemes
			.Where(_ => _.ProgrammeId == programmeId && _.ProviderId == providerId)
			.ToListAsync();
	}

	public async Task<IEnumerable<Scheme>> GetSchemesForProvider(Guid providerId)
	{
		return await _context.Schemes
			.Include(_ => _.Programme)
			.Where(_ => _.ProviderId == providerId)
			.OrderBy(_ => _.SchemeName)
			.ToListAsync();
	}
}
