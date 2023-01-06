using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

public record FundingProgrammeForEnabledFeatures
{
	[JsonProperty("hea_fundingprogrammeid")]
	public Guid ProgrammeId { get; set; }

	[JsonProperty("hea_programmefeatures@OData.Community.Display.V1.FormattedValue")]
	public string? Features { get; set; }

	[JsonProperty("hea_programmefeatures")]
	public string? FeatureCodes { get; set; }
}
