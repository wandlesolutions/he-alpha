using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

public class FundingProgrammeKeyValueEntity
{
	public const string QueryFields = "hea_fundingprogrammeid,hea_name";

	[JsonProperty(PropertyName = "hea_fundingprogrammeid")]

	public Guid FundingProgrammeId { get; set; }

	[JsonProperty(PropertyName = "hea_name")]
	public string Name { get; set; }


}
