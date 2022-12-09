using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

public record SchemeEntityCreateRequest
{
	[JsonProperty("hea_name")]
	public string SchemeName { get; set; }

	[JsonProperty("hea_totalexpenseslimit")]
	public decimal? TotalExpenses { get; set; }

	[JsonProperty("hea_totalgrant")]
	public decimal? TotalGrant { get; set; }

	[JsonProperty("hea_schemeprovider@odata.bind")]
	public AssociatedEntity ProviderId { get; set; }

	[JsonProperty("hea_fundingprogramme@odata.bind")]
	public AssociatedEntity ProgrammeId { get; set; }
}
