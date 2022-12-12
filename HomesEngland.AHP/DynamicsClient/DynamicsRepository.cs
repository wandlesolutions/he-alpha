using BearerClient;
using HomesEngland.AHP.Data;
using HomesEngland.AHP.DynamicsClient.Models;
using Newtonsoft.Json;
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

	public async Task<Programme?> CreateProgramme(Programme programme)
	{
		// Create a new programme as FundingProgrammeEntityCreateRequest to hea_fundingprogrammes URL as POST

		FundingProgrammeEntityCreateRequest createEntity = new()
		{
			Name = programme.ProgrammeName,
			Start = programme.Start,
			Finish = programme.Finish,
		};

		var createRequest = await PostAsync<NoContentResponse, FundingProgrammeEntityCreateRequest>(DynamicsEntityUrl.Programme, createEntity);
		if (createRequest.IsSuccessful())
		{
			Guid? entityId = ExtractEntityKey(createRequest.Headers);
			if (entityId.HasValue)
			{
				return await GetProgramme(entityId.Value);
			}
		}

		return null;
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
		ProviderEntityCreateRequest createEntity = new()
		{
			CustomerTypeCode = 281400001,
			Name = provider.ProviderName,
		};

		var createRequest = await PostAsync<NoContentResponse, ProviderEntityCreateRequest>("accounts", createEntity);
		if (createRequest.IsSuccessful())
		{
			Guid? entityId = ExtractEntityKey(createRequest.Headers);
			if (entityId.HasValue)
			{
				return await GetProvider(entityId.Value);
			}
		}

		return null;
	}

	public async Task<Scheme?> CreateScheme(Scheme scheme)
	{
		SchemeEntityCreateRequest createEntity = new()
		{
			ProgrammeId = new AssociatedEntity(scheme.ProgrammeId, DynamicsEntityUrl.Programme),
			ProviderId = new AssociatedEntity(scheme.ProviderId, DynamicsEntityUrl.Provider),
			SchemeName = scheme.SchemeName,
			TotalExpenses = scheme.TotalExpensesAmount,
			TotalGrant = scheme.TotalGrant,
		};

		var sending = JsonConvert.SerializeObject(createEntity);

		var createRequest = await PostAsync<NoContentResponse, SchemeEntityCreateRequest>(DynamicsEntityUrl.Scheme, createEntity);
		if (createRequest.IsSuccessful())
		{
			Guid? entityId = ExtractEntityKey(createRequest.Headers);
			if (entityId.HasValue)
			{
				return await GetScheme(entityId.Value);
			}
		}

		return null;
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
		return Task.FromResult(Enumerable.Empty<GrantMilestone>());
	}

	public Task<IEnumerable<GrantMilestoneTemplate>> GetGrantMilestoneTemplates(Guid programmeId)
	{
		return Task.FromResult(Enumerable.Empty<GrantMilestoneTemplate>());
	}

	public Task<IEnumerable<MilestoneType>> GetGrantMilestoneTemplateTypes()
	{
		throw new NotImplementedException();
	}

	public async Task<Programme?> GetProgramme(Guid programmeId)
	{
		var response = await GetAsync<FundingProgrammeEntity>($"hea_fundingprogrammes({programmeId})?$select={FundingProgrammeEntity.QueryFields}");

		return response.Content?.ToModel();
	}

	public Task<IEnumerable<ProgrammeFeature>> GetProgrammeFeatures(Guid programmeId)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Programme>> GetProgrammes()
	{
		var response = await GetAsync<DynamicsReponseWrapper<FundingProgrammeEntity>>($"hea_fundingprogrammes?$select={FundingProgrammeEntity.QueryFields}");

		return response.Content.Value.Select(_ => _.ToModel());
	}

	public Task<IEnumerable<Programme>> GetProgrammesAssociatedToSchemesForProvider(Guid providerId)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Programme>> GetProgrammesWithProviderSchemeCreationEnabled()
	{
		// TODO: filtering based on feature toggles
		var response = await GetAsync<DynamicsReponseWrapper<FundingProgrammeEntity>>("hea_fundingprogrammes");

		return response.Content.Value.Select(_ => _.ToModel());
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

	public async Task<Scheme?> GetScheme(Guid schemeId)
	{
		var response = await GetAsync<SchemeEntity>($"{DynamicsEntityUrl.Scheme}({schemeId})?$expand=hea_FundingProgramme($select={FundingProgrammeEntity.QueryFields}),hea_LocalAuthority($select={LocalAuthorityEntity.QueryFields})");

		return response.Content?.ToModel();
	}

	public Task<IEnumerable<Scheme>> GetSchemesForProgrammeForProvider(Guid programmeId, Guid providerId)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Scheme>> GetSchemesForProvider(Guid providerId)
	{
		var response = await GetAsync<DynamicsReponseWrapper<SchemeEntity>>($"hea_programmeschemes?$filter=_hea_schemeprovider_value eq {providerId}");

		if (response.IsSuccessful())
		{
			IEnumerable<Guid> programmeIds = response.Content.Value.Select(_ => _.ProgrammeId).Distinct();

			var programmes = await GetProgrammes(programmeIds);
			return response.Content?.Value?.Select(_ => _.ToModel(programmes));

		}

		return Enumerable.Empty<Scheme>();
	}

	public async Task<IDictionary<Guid, Programme>> GetProgrammes(IEnumerable<Guid> programmeIds)
	{
		Dictionary<Guid, Programme> results = new();

		foreach (Guid programmeId in programmeIds)
		{
			var programme = await GetProgramme(programmeId);
			if (programme != null)
			{
				results.Add(programmeId, programme);
			}
		}

		return results;
	}

	public Task UpdateGrantMilestoneDate(Guid grantMilestoneId, DateTimeOffset targetDate)
	{
		throw new NotImplementedException();
	}

	public static Guid? ExtractEntityKey(HttpHeaders? headers)
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
					string entityId = fromLastForwardSlash.Substring(fromLastForwardSlash.IndexOf('(') + 1).TrimEnd(')');
					return Guid.Parse(entityId);
				}
			}
		}

		return null;
	}

	public async Task<IEnumerable<LocalAuthority>> GetLocalAuthorities()
	{
		var response = await GetAsync<DynamicsReponseWrapper<LocalAuthorityEntity>>("accounts?$filter=customertypecode eq 281400000&$select=name,accountid");

		return response.Content.Value?.Select(_ => _.ToModel());
	}
}
