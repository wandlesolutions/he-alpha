using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;
// hea_milestonesplitrequests
public class GrantMilestoneSplitRequest
{
	public const string QueryFields = "hea_milestonesplitrequestid,_hea_schememilestone_value,hea_newamount,hea_newtargetdate,_hea_programmescheme_value,statuscode";

	[JsonProperty("hea_milestonesplitrequestid")]
	public Guid SplitRequestId { get; set; }

	[JsonProperty("hea_newamount")]
	public required decimal NewAmount { get; set; }

	[JsonProperty("_hea_schememilestone_value")]
	public required Guid AssociatedGrantMilestoneId { get; set; }

	[JsonProperty("hea_newtargetdate")]
	public DateTimeOffset? NewTargetDate { get; set; }

	[JsonProperty("statuscode@OData.Community.Display.V1.FormattedValue")]
	public string StatusName { get; set; }

	[JsonProperty("statuscode")]
	public int StatusCode { get; set; }

	[JsonProperty("_hea_programmescheme_value")]
	public Guid SchemeId { get; set; }
}
