using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

public record SchemeEntity
{
	public const string QueryFields = "hea_programmeschemeid,hea_name,hea_totalexpenseslimit,hea_totalgrant,_hea_schemeprovider_value,_hea_fundingprogramme_value";

	[JsonProperty("hea_programmeschemeid")]
	public Guid SchemeId { get; set; }

	[JsonProperty("hea_name")]
	public string SchemeName { get; set; }

	[JsonProperty("hea_totalexpenseslimit")]
	public decimal? TotalExpenses { get; set; }

	[JsonProperty("hea_totalgrant")]
	public decimal? TotalGrant { get; set; }

	[JsonProperty("_hea_schemeprovider_value")]
	public Guid ProviderId { get; set; }

	[JsonProperty("_hea_fundingprogramme_value")]
	public Guid ProgrammeId { get; set; }

	[JsonProperty("hea_FundingProgramme")]
	public FundingProgrammeEntity? FundingProgramme { get; set; }

	[JsonProperty("hea_LocalAuthority")]
	public LocalAuthorityEntity? LocalAuthority { get; set; }
}
