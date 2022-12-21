using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

public record GrantMilestoneCompletedUpdateEntity
{
	[JsonProperty("hea_completeddate")]
	public required DateTimeOffset CompletedDate { get; set; }

	[JsonProperty("hea_completed")]
	public required bool Completed { get; set; }
}
