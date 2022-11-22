using Microsoft.EntityFrameworkCore;

namespace HomesEngland.AHP.Data;

public class SqlGrantRepository : IGrantRepository
{
    private readonly AhpContext _context;

    public SqlGrantRepository(AhpContext ahpContext)
    {
        _context = ahpContext;
    }

    public async Task<IEnumerable<Programme>> GetProgrammes()
    {
        return await _context.Programmes?.OrderBy(_ => _.ProgrammeName).ToListAsync();
    }
}
