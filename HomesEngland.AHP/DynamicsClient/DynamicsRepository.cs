using BearerClient;
using HomesEngland.AHP.Data;
using HomesEngland.AHP.DynamicsClient.Models;
using WandleSolutions.Common.ApiClient;

namespace HomesEngland.AHP.DynamicsClient;

public class DynamicsRepository : BearerBaseApiClient, IGrantRepository
{
	public DynamicsRepository(IHttpClientFactory httpClientFactory, string configurationKey, IBearerTokenProvider bearerTokenProvider, ICancellationTokenProvider cancellationTokenProvider = null) : base(httpClientFactory, configurationKey, bearerTokenProvider, cancellationTokenProvider)
	{
	}

	public Task ClearData()
	{
		throw new NotImplementedException();
	}

	public Task<Feature> CreateFeature(Feature feature)
	{
		throw new NotImplementedException();
	}

	public Task<FinancialYear> CreateFinancialYear(FinancialYear feature)
	{
		throw new NotImplementedException();
	}

	public Task CreateGrantMilestones(IEnumerable<GrantMilestone> milestones)
	{
		throw new NotImplementedException();
	}

	public Task<GrantMilestoneTemplate> CreateGrantMilestoneTemplate(GrantMilestoneTemplate feature)
	{
		throw new NotImplementedException();
	}

	public Task<MilestoneType> CreateMilestoneType(MilestoneType milestoneType)
	{
		throw new NotImplementedException();
	}

	public Task<Programme> CreateProgramme(Programme programme)
	{
		throw new NotImplementedException();
	}

	public Task<ProgrammeFeature> CreateProgrammeFeature(ProgrammeFeature programmeFeature)
	{
		throw new NotImplementedException();
	}

	public Task<Property> CreateProperty(Property property)
	{
		throw new NotImplementedException();
	}

	public Task<Provider> CreateProvider(Provider provider)
	{
		throw new NotImplementedException();
	}

	public Task<Scheme> CreateScheme(Scheme scheme)
	{
		throw new NotImplementedException();
	}

	public Task DeleteProgrammeFeature(Guid programmeFeatureId)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Feature>> GetFeatures()
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<FinancialYear>> GetFinancialYears()
	{
		throw new NotImplementedException();
	}

	public Task<GrantMilestone?> GetGrantMilestone(Guid grantMilestoneId)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<GrantMilestone>> GetGrantMilestones(Guid schemeId)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<GrantMilestoneTemplate>> GetGrantMilestoneTemplates(Guid programmeId)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<MilestoneType>> GetGrantMilestoneTemplateTypes()
	{
		throw new NotImplementedException();
	}

	public async Task<Programme?> GetProgramme(Guid programmeId)
	{
		var response = await GetAsync<FundingProgrammeEntity>($"hea_fundingprogrammes({programmeId})");

		return response.Content?.ToModel();
	}

	public Task<IEnumerable<ProgrammeFeature>> GetProgrammeFeatures(Guid programmeId)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Programme>> GetProgrammes()
	{
		var response = await GetAsync<DynamicsReponseWrapper<FundingProgrammeEntity>>("hea_fundingprogrammes");

		return response.Content.Value.Select(_ => _.ToModel());
	}

	public Task<IEnumerable<Programme>> GetProgrammesAssociatedToSchemesForProvider(Guid providerId)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Programme>> GetProgrammesWithProviderSchemeCreationEnabled()
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Property>> GetPropertiesForProvider(Guid providerId)
	{
		throw new NotImplementedException();
	}

	public Task<Property?> GetProperty(Guid propertyId)
	{
		throw new NotImplementedException();
	}

	public Task<Property?> GetPropertyForProvider(Guid propertyId, Guid providerId)
	{
		throw new NotImplementedException();
	}

	public async Task<Provider?> GetProvider(Guid providerId)
	{
		var response = await GetAsync<ProviderEntity>($"accounts({providerId})?$filter=customertypecode eq 281400001&$select=name");

		return response.Content?.ToModel();
	}

	public async Task<IEnumerable<Provider>> GetProviders()
	{
		var response = await GetAsync<DynamicsReponseWrapper<ProviderEntity>>("accounts?$filter=customertypecode eq 281400001&$select=name");

		return response.Content.Value?.Select(_ => _.ToModel());

	}

	public Task<Scheme?> GetScheme(Guid schemeId)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Scheme>> GetSchemesForProgrammeForProvider(Guid programmeId, Guid providerId)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Scheme>> GetSchemesForProvider(Guid providerId)
	{
		throw new NotImplementedException();
	}

	public Task UpdateGrantMilestoneDate(Guid grantMilestoneId, DateTimeOffset targetDate)
	{
		throw new NotImplementedException();
	}
}
