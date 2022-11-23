namespace HomesEngland.AHP.Data;

public interface IGrantRepository
{
	Task<IEnumerable<Programme>> GetProgrammes();

	Task<IEnumerable<Feature>> GetFeatures();

	Task<Programme> CreateProgramme(Programme programme);
}
