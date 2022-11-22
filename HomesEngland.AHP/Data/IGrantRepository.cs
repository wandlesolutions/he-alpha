namespace HomesEngland.AHP.Data;

public interface IGrantRepository
{
	Task<IEnumerable<Programme>> GetProgrammes();
}
