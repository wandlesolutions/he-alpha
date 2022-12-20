using HomesEngland.AHP.Data;
using HomesEngland.AHP.Helpers;

namespace HomesEngland.AHP.Operations.Properties;

public class MilestoneCreationService
{
	private readonly IGrantRepository _repo;

	public MilestoneCreationService(IGrantRepository grantRepository)
	{
		_repo = grantRepository;
	}

	public async Task CreateMilestoneAfterSchemeIsCreated(Guid schemeId)
	{
		Scheme? scheme = await _repo.GetScheme(schemeId);
		if (scheme == null)
		{
			return;
		}

		IEnumerable<GrantMilestone> existingMilestones = await _repo.GetGrantMilestones(schemeId);
		if (existingMilestones.Any())
		{
			return;
		}

		IEnumerable<GrantMilestoneTemplate> templatedGrantsForScheme = await _repo.GetGrantMilestoneTemplates(scheme.ProgrammeId);
		decimal percentageTotal = templatedGrantsForScheme
			.Where(_ => _.Percentage.HasValue)
			.Select(_ => _.Percentage.Value)
			.Sum();

		if (percentageTotal != 100M)
		{
			return;
		}

		IEnumerable<FinancialYear> financialYears = await _repo.GetFinancialYears();

		DateTimeOffset now = DateTimeOffset.UtcNow;

		List<GrantMilestone> milestones = new();

		foreach (GrantMilestoneTemplate grantMilestoneTemplate in templatedGrantsForScheme)
		{
			DateTimeOffset milestoneDate = now.AddDays(grantMilestoneTemplate.TargetNumberOfDays);

			FinancialYear? financialYear = financialYears.FromDate(milestoneDate);
			if (financialYear == null)
			{
				return;
			}

			GrantMilestone grantMilestone = new GrantMilestone()
			{
				Completed = false,
				CompletionDate = null,
				FinancialYearId = financialYear.FinanicalYearId,
				MilestoneGrantAmount = Math.Round(scheme.TotalGrantAmount.Value * (grantMilestoneTemplate.Percentage.Value / 100), 2),
				MilestoneTypeId = grantMilestoneTemplate.MilestoneTypeId,
				SchemeId = schemeId,
				TargetDate = milestoneDate,
			};

			milestones.Add(grantMilestone);
		}

		EnsureLastMilestoneHasRemainingGrantValue(scheme, milestones);

		ValidateMilestoneGrantAmounts(milestones, scheme.TotalGrantAmount);

		await _repo.CreateGrantMilestones(milestones);
	}

	private void ValidateMilestoneGrantAmounts(List<GrantMilestone> milestones, decimal? grantAmount)
	{
		decimal milestoneTotals = milestones
			.Where(_ => _.MilestoneGrantAmount.HasValue)
			.Sum(_ => _.MilestoneGrantAmount.Value);

		if (milestoneTotals != grantAmount)
		{
			throw new InvalidOperationException($"Milestone totals do not match grant amount. Milestone total: {milestoneTotals}, Grant amount: {grantAmount}");
		}
	}

	private static void EnsureLastMilestoneHasRemainingGrantValue(Scheme? scheme, List<GrantMilestone> milestones)
	{
		GrantMilestone lastMilestone = milestones.Last();

		decimal totalAmountsExceptLast = milestones.Except(new GrantMilestone[] { lastMilestone }).Sum(_ => _.MilestoneGrantAmount.Value);

		lastMilestone.MilestoneGrantAmount = scheme.TotalGrantAmount.Value - totalAmountsExceptLast;
	}
}
