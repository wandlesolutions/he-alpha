using BearerClient;
using HomesEngland.AHP.Data;
using HomesEngland.AHP.DynamicsClient.Models;
using System.Net.Http.Headers;
using WandleSolutions.Common.ApiClient;

namespace HomesEngland.AHP.DynamicsClient;

public class DynamicsRepository : BearerBaseApiClient, IGrantRepository
{
	private readonly static string[] PreferHeaders = new string[] { "Prefer", "odata.include-annotations=*" };


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

	public async Task<Property?> CreateProperty(Property property)
	{
		PropertyEntityCreateRequest createEntity = new()
		{
			Address1 = property.Address1,
			Address2 = property.Address2,
			ExpensesAmount = property.ExpensesAmount,
			GrantAmount = property.GrantAmount,
			Postcode = property.Postcode,
			PropertyName = property.PropertyName,
			Scheme = new AssociatedEntity(property.SchemeId, DynamicsEntityUrl.Scheme),
			TotalAmount = property.TotalAmount,
		};

		var createRequest = await PostAsync<NoContentResponse, PropertyEntityCreateRequest>(DynamicsEntityUrl.Properties, createEntity);
		if (createRequest.IsSuccessful())
		{
			Guid? entityId = ExtractEntityKey(createRequest.Headers);
			if (entityId.HasValue)
			{
				return await GetProperty(entityId.Value);
			}
		}

		return null;
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
			TotalExpenses = scheme.TotalRevenueFundingAmount,
			TotalGrant = scheme.TotalGrantAmount,
		};

		if (scheme.LocalAuthorityId.HasValue)
		{
			createEntity.LocalAuthorityId = new AssociatedEntity(scheme.LocalAuthorityId.Value, DynamicsEntityUrl.LocalAuthority);
		}

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

	public async Task<IEnumerable<Feature>> GetFeatures()
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<FinancialYear>> GetFinancialYears()
	{
		throw new NotImplementedException();
	}

	public async Task<GrantMilestone?> GetGrantMilestone(Guid grantMilestoneId)
	{
		var response = await GetAsync<GrantMilestoneEntity>($"hea_schememilestones({grantMilestoneId})?$select={GrantMilestoneEntity.QueryFields}&$expand=hea_ProgrammeScheme($select={SchemeEntity.QueryFields})",
			customHeaders: PreferHeaders
			);

		return response?.Content?.ToModel();
	}

	public async Task<IEnumerable<GrantMilestone>> GetGrantMilestones(Guid schemeId)
	{
		var response = await GetAsync<DynamicsReponseWrapper<GrantMilestoneEntity>>($"hea_schememilestones?$filter=_hea_programmescheme_value eq {schemeId}&$select={GrantMilestoneEntity.QueryFields}&$expand=hea_ProgrammeScheme($select={SchemeEntity.QueryFields})",
			customHeaders: PreferHeaders
			);

		if (!response.IsSuccessful())
		{
			throw new InvalidOperationException($"Failed to retrieve grant milestones. {response.StatusCode}, {response?.Content}");
		}

		if (response.Content == null
			|| response.Content.Value == null)
		{
			return Enumerable.Empty<GrantMilestone>();
		}

		return response.Content.Value.Select(_ => _.ToModel());
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

	public async Task<IEnumerable<Programme>> GetProgrammesAssociatedToSchemesForProvider(Guid providerId)
	{
		var response = await GetAsync<DynamicsReponseWrapper<SchemeEntity>>($"hea_programmeschemes?$filter=_hea_schemeprovider_value eq {providerId}&$expand=hea_FundingProgramme($select={FundingProgrammeEntity.QueryFields})&$select={SchemeEntity.QueryFields}");

		return response.Content.Value?.DistinctBy(_ => _.ProgrammeId).Select(_ => _.FundingProgramme.ToModel());

	}

	public async Task<IEnumerable<KeyValue>> GetProgrammesWithProviderSchemeCreationEnabled()
	{
		// TODO: filtering based on feature toggles
		var response = await GetAsync<DynamicsReponseWrapper<FundingProgrammeKeyValueEntity>>($"hea_fundingprogrammes?$filter=statuscode eq 1 and Microsoft.Dynamics.CRM.ContainValues(PropertyName='hea_programmefeatures',PropertyValues=%5B'{FeatureToggleChoiceIds.ProviderCanCreateSchemes}'%5D)&$select={FundingProgrammeKeyValueEntity.QueryFields}");

		return response.Content.Value.Select(_ => new KeyValue()
		{
			Key = _.FundingProgrammeId,
			Value = _.Name,
		});
	}

	public async Task<IEnumerable<Property>> GetPropertiesForProvider(Guid providerId)
	{
		var response = await GetAsync<DynamicsReponseWrapper<PropertyEntity>>($"hea_schemeproperties?$select={PropertyEntity.QueryFields}&$expand=hea_LocalAuthority($select={LocalAuthorityEntity.QueryFields}),hea_ProgrammeScheme($select={SchemeEntity.QueryFields})");

		IEnumerable<Guid> programmeIds = response.Content.Value.Select(_ => _.Scheme?.ProgrammeId)
			.Where(_ => _.HasValue)
			.Select(_ => _.Value)
			.Distinct();

		var programmes = await GetProgrammes(programmeIds);


		List<Property> properties = response.Content.Value?.Select(_ => _.ToModel()).ToList();
		// Set programme on each property based on scheme.ProgrammeId
		foreach (Property property in properties)
		{
			if (property.Scheme == null)
			{
				continue;
			}

			if (programmes.TryGetValue(property.Scheme.ProgrammeId, out Programme? programme))
			{
				property.Scheme.Programme = programme;

			}
		}

		return properties;
	}

	public async Task<Property?> GetProperty(Guid propertyId)
	{
		var response = await GetAsync<PropertyEntity?>($"{DynamicsEntityUrl.Properties}({propertyId})?$filter=hea_schemepropertyid eq {propertyId}&$select={PropertyEntity.QueryFields}&$expand=hea_LocalAuthority($select={LocalAuthorityEntity.QueryFields}),hea_ProgrammeScheme($select={SchemeEntity.QueryFields})");


		return response?.Content?.ToModel();
	}

	public async Task<Property?> GetPropertyForProvider(Guid propertyId, Guid providerId)
	{
		var response = await GetAsync<PropertyEntity?>($"{DynamicsEntityUrl.Properties}({propertyId})?$filter=hea_schemepropertyid eq {propertyId}&$select={PropertyEntity.QueryFields}&$expand=hea_LocalAuthority($select={LocalAuthorityEntity.QueryFields}),hea_ProgrammeScheme($select={SchemeEntity.QueryFields})");


		return response?.Content?.ToModel();
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
		var response = await GetAsync<SchemeEntity>($"{DynamicsEntityUrl.Scheme}({schemeId})?$expand=hea_FundingProgramme($select={FundingProgrammeEntity.QueryFields}),hea_LocalAuthority($select={LocalAuthorityEntity.QueryFields})",
		customHeaders: PreferHeaders);

		return response.Content?.ToModel();
	}

	public async Task<IEnumerable<Scheme>> GetSchemesForProgrammeForProvider(Guid programmeId, Guid providerId)
	{
		var response = await GetAsync<DynamicsReponseWrapper<SchemeEntity>>($"hea_programmeschemes?$filter=_hea_schemeprovider_value eq {providerId} and _hea_fundingprogramme_value eq {programmeId}&$expand=hea_FundingProgramme($select={FundingProgrammeEntity.QueryFields}),hea_LocalAuthority($select={LocalAuthorityEntity.QueryFields})&$select={SchemeEntity.QueryFields}",
		customHeaders: PreferHeaders);

		if (response.IsSuccessful())
		{
			IEnumerable<Guid> programmeIds = response.Content.Value.Select(_ => _.ProgrammeId).Distinct();

			var programmes = await GetProgrammes(programmeIds);
			return response.Content?.Value?.Select(_ => _.ToModel(programmes));

		}

		return Enumerable.Empty<Scheme>();
	}

	public async Task<IEnumerable<Scheme>> GetSchemesForProvider(Guid providerId)
	{
		var response = await GetAsync<DynamicsReponseWrapper<SchemeEntity>>($"hea_programmeschemes?$filter=_hea_schemeprovider_value eq {providerId}&$select={SchemeEntity.QueryFields}");

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

	public async Task UpdateGrantMilestoneDate(Guid grantMilestoneId, DateTimeOffset targetDate)
	{
		var updateModel = new GrantMilestoneDateUpdateEntity()
		{
			TargetDate = targetDate
		};

		var response = await PatchAsync<GrantMilestoneDateUpdateEntity>($"{DynamicsEntityUrl.GrantMilestones}({grantMilestoneId})",
			updateModel);

		if (response != System.Net.HttpStatusCode.NoContent &&
			response != System.Net.HttpStatusCode.OK)
		{
			throw new Exception($"Failed to update grant milestone date. Status code: {response}");
		}
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

	public Task CompleteGrantMilestone(Guid grantMilestoneId, DateTimeOffset completionDate)
	{
		throw new NotImplementedException();
	}
}
