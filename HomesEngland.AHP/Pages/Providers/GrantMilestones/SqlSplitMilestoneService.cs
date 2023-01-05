using HomesEngland.AHP.Data;
using HomesEngland.AHP.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HomesEngland.AHP.Pages.Providers.GrantMilestones;

public class SqlSplitMilestoneService : ISplitMilestoneService
{
	private readonly IDbContextFactory<AhpContext> _dbFactory;

	public SqlSplitMilestoneService(IDbContextFactory<AhpContext> ahpContextFactory)
	{
		_dbFactory = ahpContextFactory;

	}

	public async Task SplitMilestone(SplitMilestoneRequest request)
	{
		decimal roundedAmount = Math.Round(request.CreatedMilestoneAmount, 2);
		if (roundedAmount != request.CreatedMilestoneAmount)
		{
			throw new InvalidOperationException("Too many decmial places for currency");
		}

		using var ctx = await _dbFactory.CreateDbContextAsync();

		GrantMilestone? milestone = await ctx.GrantMilestones
			.Where(m => m.GrantMilestoneId == request.ExistingMilestoneId)
			.FirstOrDefaultAsync();

		if (milestone == null)
		{
			throw new InvalidOperationException("Grant milestone not found");
		}

		if (!milestone.MilestoneGrantAmount.HasValue)
		{
			throw new InvalidOperationException("Existing milestone has no grant amount");
		}

		decimal newMilestoneAmount = milestone.MilestoneGrantAmount.Value - request.CreatedMilestoneAmount;
		if (newMilestoneAmount < 0)
		{
			throw new InvalidOperationException("Cannot split milestone by amount greater than existing milestone amount");

		}

		var financialYears = await ctx.FinancialYears.ToListAsync();

		GrantMilestone newMilestone = new()
		{
			Completed = false,
			CompletionDate = null,
			FinancialYear = financialYears.FromDate(request.CreatedMilestoneDate),
			MilestoneGrantAmount = request.CreatedMilestoneAmount,
			MilestoneTypeId = milestone.MilestoneTypeId,
			SchemeId = milestone.SchemeId,
			TargetDate = request.CreatedMilestoneDate,
		};

		milestone.MilestoneGrantAmount = newMilestoneAmount;

		ctx.GrantMilestones.Add(newMilestone);
		await ctx.SaveChangesAsync();

	}
}
