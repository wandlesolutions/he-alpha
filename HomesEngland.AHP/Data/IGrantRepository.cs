namespace HomesEngland.AHP.Data;

public interface IGrantRepository
{

	Task ClearData();
	Task<Feature?> CreateFeature(Feature feature);
	Task<FinancialYear?> CreateFinancialYear(FinancialYear feature);
	Task<GrantMilestoneTemplate?> CreateGrantMilestoneTemplate(GrantMilestoneTemplate feature);
	Task<MilestoneType?> CreateMilestoneType(MilestoneType milestoneType);
	Task<Programme?> CreateProgramme(Programme programme);
	Task<ProgrammeFeature?> CreateProgrammeFeature(ProgrammeFeature programmeFeature);
	Task<Property?> CreateProperty(Property property);
	Task<Provider?> CreateProvider(Provider provider);
	Task<SchemeRevenueClaim> CreateSchemeRevenueClaim(SchemeRevenueClaim schemeRevenueClaim);
	Task<Scheme?> CreateScheme(Scheme scheme);

	Task DeleteProgrammeFeature(Guid programmeFeatureId);
	Task<IEnumerable<Programme>> GetProgrammes();
	Task<IEnumerable<Programme>> GetProgrammesAssociatedToSchemesForProvider(Guid providerId);
	Task<IEnumerable<KeyValue>> GetProgrammesWithProviderSchemeCreationEnabled();
	Task<IEnumerable<Provider>> GetProviders();
	Task<Programme?> GetProgramme(Guid programmeId);
	Task<Provider?> GetProvider(Guid providerId);

	Task<IEnumerable<Feature>> GetFeatures();
	Task<GrantMilestone?> GetGrantMilestone(Guid grantMilestoneId);
	Task<IEnumerable<MilestoneType>> GetGrantMilestoneTemplateTypes();
	Task<IEnumerable<LocalAuthority>> GetLocalAuthorities();

	Task<IEnumerable<ProgrammeFeature>> GetProgrammeFeatures(Guid programmeId);
	Task<IEnumerable<string>> GetFeatureKeysForProgramme(Guid programmeId);

	Task<IEnumerable<Property>> GetPropertiesForProvider(Guid providerId);
	Task<Property?> GetPropertyForProvider(Guid propertyId, Guid providerId);

	Task<IEnumerable<Scheme>> GetSchemesForProvider(Guid providerId);
	Task<IEnumerable<Scheme>> GetSchemesForProgrammeForProvider(Guid programmeId, Guid providerId);
	Task<IEnumerable<SchemeRevenueClaim>> GetSchemeRevenueClaims(Guid schemeId);
	Task<IEnumerable<GrantMilestoneTemplate>> GetGrantMilestoneTemplates(Guid programmeId);
	Task<Property?> GetProperty(Guid propertyId);
	Task<IEnumerable<FinancialYear>> GetFinancialYears();
	Task CreateGrantMilestones(IEnumerable<GrantMilestone> milestones);
	Task<IEnumerable<GrantMilestone>> GetGrantMilestones(Guid schemeId);
	Task<IEnumerable<GrantMilestoneSplitRequestStatus>> GetGrantMilestoneSplitStatus(Guid schemeId);

	Task UpdateGrantMilestoneDate(Guid grantMilestoneId, DateTimeOffset targetDate);
	Task CompleteGrantMilestone(Guid grantMilestoneId, DateTimeOffset completionDate);
	Task<Scheme?> GetScheme(Guid schemeId);
}
