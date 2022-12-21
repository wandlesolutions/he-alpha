using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

public record GrantMilestoneDateUpdateEntity
{
	[JsonProperty("hea_targetdate")]
	public required DateTimeOffset TargetDate { get; set; }
}
