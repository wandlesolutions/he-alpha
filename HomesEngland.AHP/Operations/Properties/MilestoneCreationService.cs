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

	public async Task CreateMilestoneAfterPropertyIsCreated(Guid propertyId)
	{
		Property? property = await _repo.GetProperty(propertyId);
		if (property == null)
		{
			return;
		}

		IEnumerable<GrantMilestone> existingMilestones = await _repo.GetGrantMilestones(propertyId);
		if (existingMilestones.Any())
		{
			return;
		}

		IEnumerable<GrantMilestoneTemplate> templatedGrantsForProgramme = await _repo.GetGrantMilestoneTemplates(property.Scheme.ProgrammeId);
		decimal percentageTotal = templatedGrantsForProgramme
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

		foreach (GrantMilestoneTemplate grantMilestoneTemplate in templatedGrantsForProgramme)
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
				GrantAmount = Math.Round(property.GrantAmount.Value * (grantMilestoneTemplate.Percentage.Value / 100), 2),
				MilestoneTypeId = grantMilestoneTemplate.MilestoneTypeId,
				PropertyId = propertyId,
				TargetDate = milestoneDate,
			};

			milestones.Add(grantMilestone);
		}

		EnsureLastMilestoneHasRemainingGrantValue(property, milestones);

		ValidateMilestoneGrantAmounts(milestones, property.GrantAmount);

		await _repo.CreateGrantMilestones(milestones);
	}

	private void ValidateMilestoneGrantAmounts(List<GrantMilestone> milestones, decimal? grantAmount)
	{
		decimal milestoneTotals = milestones
			.Where(_ => _.GrantAmount.HasValue)
			.Sum(_ => _.GrantAmount.Value);

		if (milestoneTotals != grantAmount)
		{
			throw new InvalidOperationException($"Milestone totals do not match grant amount. Milestone total: {milestoneTotals}, Grant amount: {grantAmount}");
		}
	}

	private static void EnsureLastMilestoneHasRemainingGrantValue(Property? property, List<GrantMilestone> milestones)
	{
		GrantMilestone lastMilestone = milestones.Last();

		decimal totalAmountsExceptLast = milestones.Except(new GrantMilestone[] { lastMilestone }).Sum(_ => _.GrantAmount.Value);

		lastMilestone.GrantAmount = property.GrantAmount.Value - totalAmountsExceptLast;
	}
}
