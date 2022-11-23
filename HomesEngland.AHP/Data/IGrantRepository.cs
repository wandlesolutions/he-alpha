namespace HomesEngland.AHP.Data;

public interface IGrantRepository
{
	Task<IEnumerable<Programme>> GetProgrammes();
	Task<Programme?> GetProgramme(Guid programmeId);

	Task<IEnumerable<Feature>> GetFeatures();

	Task<Feature> CreateFeature(Feature feature);
	Task<Programme> CreateProgramme(Programme programme);
}
