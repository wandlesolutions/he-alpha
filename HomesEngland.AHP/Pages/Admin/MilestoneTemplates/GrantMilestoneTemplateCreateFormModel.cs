using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Pages.Admin.MilestoneTemplates;

public class GrantMilestoneTemplateCreateFormModel
{
	[Required]
	public string? MilestoneTypeId { get; set; }

	[Required, Range(0, 100)]
	public decimal? Percentage { get; set; }

	[Required, Range(1, 100)]
	public string? MilestoneOrder { get; set; }

	[Required, Range(1, 1000)]
	public string? TargetNumberOfDays { get; set; }
}
