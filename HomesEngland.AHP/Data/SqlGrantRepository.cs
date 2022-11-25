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
