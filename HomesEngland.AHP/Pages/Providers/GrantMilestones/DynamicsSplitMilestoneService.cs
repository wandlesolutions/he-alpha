using HomesEngland.AHP.Data;
using HomesEngland.AHP.DynamicsClient;
using HomesEngland.AHP.DynamicsClient.Models;

namespace HomesEngland.AHP.Pages.Providers.GrantMilestones;

public class DynamicsSplitMilestoneService : ISplitMilestoneService
{
	private readonly DynamicsRepository _repo;

	public DynamicsSplitMilestoneService(IGrantRepository grantRepo)
	{
		_repo = (DynamicsRepository)grantRepo;
	}
	public async Task SplitMilestone(SplitMilestoneRequest request)
	{
		await _repo.CreateGrantMilestoneSplit(new GrantMilestoneSplitCreateRequest()
		{
			NewAmount = request.CreatedMilestoneAmount,
			NewTargetDate = request.CreatedMilestoneDate,
			SchemeMilestone = new AssociatedEntity(request.ExistingMilestoneId, DynamicsEntityUrl.GrantMilestones),
		});

	}
}
