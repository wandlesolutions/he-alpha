using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

public class FundingProgrammeEntityCreateRequest
{
	[JsonProperty(PropertyName = "hea_name")]
	public string Name { get; set; }

	[JsonProperty(PropertyName = "hea_startdate")]
	public DateTimeOffset Start { get; set; }

	[JsonProperty(PropertyName = "hea_enddate")]
	public DateTimeOffset Finish { get; set; }
}
