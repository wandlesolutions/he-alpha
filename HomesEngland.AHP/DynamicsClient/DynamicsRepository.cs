using BearerClient;
using HomesEngland.AHP.Data;
using HomesEngland.AHP.DynamicsClient.Models;
using System.Net.Http.Headers;
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

	public Task<Feature?> CreateFeature(Feature feature)
	{
		throw new NotImplementedException();
	}

	public Task<FinancialYear?> CreateFinancialYear(FinancialYear feature)
	{
		throw new NotImplementedException();
	}

	public Task CreateGrantMilestones(IEnumerable<GrantMilestone> milestones)
	{
		throw new NotImplementedException();
	}

	public Task<GrantMilestoneTemplate?> CreateGrantMilestoneTemplate(GrantMilestoneTemplate feature)
	{
		throw new NotImplementedException();
	}

	public Task<MilestoneType?> CreateMilestoneType(MilestoneType milestoneType)
	{
		throw new NotImplementedException();
	}

	public Task<Programme?> CreateProgramme(Programme programme)
	{
		throw new NotImplementedException();
	}

	public Task<ProgrammeFeature?> CreateProgrammeFeature(ProgrammeFeature programmeFeature)
	{
		throw new NotImplementedException();
	}

	public Task<Property?> CreateProperty(Property property)
	{
		throw new NotImplementedException();
	}

	public async Task<Provider?> CreateProvider(Provider provider)
	{
		// Send a post request using PostAsync for a ProviderEntity to the URL accounts.
		// Use ExtractEntityKey to get the ID of the newly created ProviderEntity.
		// Query GetProvider using the ID to return

		ProviderEntityCreateRequest createEntity = new()
		{
			CustomerTypeCode = 281400001,
			Name = provider.ProviderName,
		};


		var createRequest = await PostAsync<NoContentResponse, ProviderEntityCreateRequest>("accounts", createEntity);
		if (createRequest.IsSuccessful())
		{
			string? providerIdString = ExtractEntityKey(createRequest.Headers);
			if (!string.IsNullOrWhiteSpace(providerIdString))
			{
				var providerId = Guid.Parse(providerIdString);
				return await GetProvider(providerId);
			}
		}

		return null;
	}

	public Task<Scheme?> CreateScheme(Scheme scheme)
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

	public static string? ExtractEntityKey(HttpHeaders? headers)
	{
		// Extract last GUID from OData-EntityId key in headers and return without surrounding ()
		if (headers == null)
		{
			return null;
		}

		if (headers.TryGetValues("OData-EntityId", out var values))
		{
			if (values.Count() == 1)
			{
				string value = values.First();
				string fromLastForwardSlash = value.Substring(value.LastIndexOf('/') + 1);

				// Check there is a (  within the string and last character in string is ), if so, substring from the first ( in the string and  remove last character
				if (fromLastForwardSlash.Contains('(') && fromLastForwardSlash.Last() == ')')
				{
					return fromLastForwardSlash.Substring(fromLastForwardSlash.IndexOf('(') + 1).TrimEnd(')');
				}
			}
		}

		return null;
	}
}
