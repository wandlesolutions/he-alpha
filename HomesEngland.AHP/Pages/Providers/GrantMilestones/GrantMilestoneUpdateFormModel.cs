using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Pages.Providers.GrantMilestones;

public class GrantMilestoneUpdateFormModel
{
	[Required]
	public DateTimeOffset? TargetDate { get; set; }
}
