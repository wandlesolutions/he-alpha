namespace HomesEngland.AHP.Data;

public interface IGrantRepository
{
	Task<IEnumerable<Programme>> GetProgrammes();
	Task<IEnumerable<Programme>> GetProgrammesAssociatedToSchemesForProvider(Guid providerId);
	Task<IEnumerable<Programme>> GetProgrammesWithProviderSchemeCreationEnabled();
	Task<IEnumerable<Provider>> GetProviders();
	Task<Programme?> GetProgramme(Guid programmeId);
	Task<Provider?> GetProvider(Guid providerId);

	Task<IEnumerable<Feature>> GetFeatures();

	Task<IEnumerable<ProgrammeFeature>> GetProgrammeFeatures(Guid programmeId);

	Task<IEnumerable<Property>> GetPropertiesForProvider(Guid providerId);
	Task<Property?> GetPropertyForProvider(Guid propertyId, Guid providerId);

	Task<IEnumerable<Scheme>> GetSchemesForProvider(Guid providerId);
	Task<IEnumerable<Scheme>> GetSchemesForProgrammeForProvider(Guid programmeId, Guid providerId);

	Task<Feature> CreateFeature(Feature feature);
	Task<Programme> CreateProgramme(Programme programme);
	Task<ProgrammeFeature> CreateProgrammeFeature(ProgrammeFeature programmeFeature);
	Task<Property> CreateProperty(Property property);
	Task<Provider> CreateProvider(Provider provider);
	Task<Scheme> CreateScheme(Scheme scheme);

	Task DeleteProgrammeFeature(Guid programmeFeatureId);
}
