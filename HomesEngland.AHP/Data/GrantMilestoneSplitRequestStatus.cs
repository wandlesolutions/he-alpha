namespace HomesEngland.AHP.Data;

public record GrantMilestoneSplitRequestStatus
{
	public required Guid GrantMilestoneId { get; set; }

	public required string StatusName { get; set; }

	public required int StatusCode { get; set; }
}
