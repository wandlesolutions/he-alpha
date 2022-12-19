using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

public class FundingProgrammeEntity
{
	public const string QueryFields = "hea_fundingprogrammeid,hea_name,hea_startdate,hea_enddate";

	[JsonProperty(PropertyName = "hea_fundingprogrammeid")]
	public Guid FundingProgrammeId { get; set; }

	[JsonProperty(PropertyName = "hea_name")]
	public string Name { get; set; }

	[JsonProperty(PropertyName = "hea_startdate")]
	public DateTimeOffset Start { get; set; }

	[JsonProperty(PropertyName = "hea_enddate")]
	public DateTimeOffset Finish { get; set; }


}
