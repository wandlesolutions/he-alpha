using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;
// hea_milestonesplitrequests
public class GrantMilestoneSplitCreateRequest
{
	[JsonProperty("hea_newamount")]
	public required decimal NewAmount { get; set; }

	[JsonProperty("hea_SchemeMilestone@odata.bind")]
	public required AssociatedEntity SchemeMilestone { get; set; }

	[JsonProperty("hea_newtargetdate")]
	public DateTimeOffset? NewTargetDate { get; set; }
}
