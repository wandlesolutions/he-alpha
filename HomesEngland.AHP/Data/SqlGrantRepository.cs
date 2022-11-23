using Microsoft.EntityFrameworkCore;

namespace HomesEngland.AHP.Data;

public class SqlGrantRepository : IGrantRepository
{
	private readonly AhpContext _context;

	public SqlGrantRepository(AhpContext ahpContext)
	{
		_context = ahpContext;
	}

	public async Task<Programme> CreateProgramme(Programme programme)
	{
		await _context.Programmes.AddAsync(programme);
		await _context.SaveChangesAsync();
		return programme;
	}

	public async Task<IEnumerable<Feature>> GetFeatures()
	{
		return await _context.Features.OrderBy(_ => _.FeatureName).ToListAsync();
	}

	public async Task<IEnumerable<Programme>> GetProgrammes()
	{
		return await _context.Programmes?.OrderBy(_ => _.ProgrammeName).ToListAsync();
	}
}
