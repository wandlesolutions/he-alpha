namespace HomesEngland.AHP.Data;

public interface IGrantRepository
{
	Task<Feature> CreateFeature(Feature feature);
	Task<FinancialYear> CreateFinancialYear(FinancialYear feature);
	Task<GrantMilestoneTemplate> CreateGrantMilestoneTemplate(GrantMilestoneTemplate feature);
	Task<MilestoneType> CreateMilestoneType(MilestoneType milestoneType);
	Task<Programme> CreateProgramme(Programme programme);
	Task<ProgrammeFeature> CreateProgrammeFeature(ProgrammeFeature programmeFeature);
	Task<Property> CreateProperty(Property property);
	Task<Provider> CreateProvider(Provider provider);
	Task<Scheme> CreateScheme(Scheme scheme);

	Task DeleteProgrammeFeature(Guid programmeFeatureId);
	Task<IEnumerable<Programme>> GetProgrammes();
	Task<IEnumerable<Programme>> GetProgrammesAssociatedToSchemesForProvider(Guid providerId);
	Task<IEnumerable<Programme>> GetProgrammesWithProviderSchemeCreationEnabled();
	Task<IEnumerable<Provider>> GetProviders();
	Task<Programme?> GetProgramme(Guid programmeId);
	Task<Provider?> GetProvider(Guid providerId);

	Task<IEnumerable<Feature>> GetFeatures();
	Task<IEnumerable<MilestoneType>> GetGrantMilestoneTemplateTypes();

	Task<IEnumerable<ProgrammeFeature>> GetProgrammeFeatures(Guid programmeId);

	Task<IEnumerable<Property>> GetPropertiesForProvider(Guid providerId);
	Task<Property?> GetPropertyForProvider(Guid propertyId, Guid providerId);

	Task<IEnumerable<Scheme>> GetSchemesForProvider(Guid providerId);
	Task<IEnumerable<Scheme>> GetSchemesForProgrammeForProvider(Guid programmeId, Guid providerId);
	Task<IEnumerable<GrantMilestoneTemplate>> GetGrantMilestoneTemplates(Guid programmeId);
	Task<Property?> GetProperty(Guid propertyId);
	Task<IEnumerable<FinancialYear>> GetFinancialYears();
	Task CreateGrantMilestones(IEnumerable<GrantMilestone> milestones);
	Task<IEnumerable<GrantMilestone>> GetGrantMilestones(Guid propertyId);
}
