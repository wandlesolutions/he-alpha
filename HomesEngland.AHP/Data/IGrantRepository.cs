namespace HomesEngland.AHP.Data;

public interface IGrantRepository
{
	Task<IEnumerable<Programme>> GetProgrammes();
	Task<IEnumerable<Provider>> GetProviders();
	Task<Programme?> GetProgramme(Guid programmeId);
	Task<Provider?> GetProvider(Guid providerId);

	Task<IEnumerable<Feature>> GetFeatures();

	Task<IEnumerable<ProgrammeFeature>> GetProgrammeFeatures(Guid programmeId);

	Task<Feature> CreateFeature(Feature feature);
	Task<Programme> CreateProgramme(Programme programme);
	Task<ProgrammeFeature> CreateProgrammeFeature(ProgrammeFeature programmeFeature);
	Task<Provider> CreateProvider(Provider provider);

	Task DeleteProgrammeFeature(Guid programmeFeatureId);
}
