using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Pages.Providers.GrantMilestones;

public record SplitMilestoneFormModel
{
	[Required, Range(1, double.MaxValue)]
	public decimal? CreatedMilestoneAmount { get; set; }

	[Required]
	public DateTimeOffset? CreatedMilestoneDate { get; set; }
}
