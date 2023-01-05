namespace HomesEngland.AHP.Pages.Providers.GrantMilestones;

public record SplitMilestoneRequest
{
	public required Guid ExistingMilestoneId { get; set; }

	public required decimal CreatedMilestoneAmount { get; set; }

	public required DateTimeOffset CreatedMilestoneDate { get; set; }
}
