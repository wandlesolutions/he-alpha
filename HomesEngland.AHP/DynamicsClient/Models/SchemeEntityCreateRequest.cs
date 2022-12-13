using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

public record SchemeEntityCreateRequest
{
	[JsonProperty("hea_name")]
	public required string SchemeName { get; set; }

	[JsonProperty("hea_totalexpenseslimit")]
	public decimal? TotalExpenses { get; set; }

	[JsonProperty("hea_totalgrant")]
	public decimal? TotalGrant { get; set; }

	[JsonProperty("hea_SchemeProvider_account@odata.bind")]
	public required AssociatedEntity ProviderId { get; set; }

	[JsonProperty("hea_FundingProgramme@odata.bind")]
	public required AssociatedEntity ProgrammeId { get; set; }

	[JsonProperty("hea_LocalAuthority@odata.bind")]
	public AssociatedEntity? LocalAuthorityId { get; set; }
}
