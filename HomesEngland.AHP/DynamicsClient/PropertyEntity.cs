using HomesEngland.AHP.DynamicsClient.Models;
using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient;

public class PropertyEntity
{
	public const string QueryFields = "hea_schemepropertyid,hea_name,_hea_programmescheme_value,hea_addressline1,hea_addressline2,hea_postcode,hea_grantamount,hea_expenselimit,hea_totalamount";

	[JsonProperty("hea_schemepropertyid")]
	public Guid PropertyId { get; set; }

	[JsonProperty("hea_name")]
	public string PropertyName { get; set; }

	[JsonProperty("_hea_programmescheme_value")]
	public Guid SchemeId { get; set; }

	[JsonProperty("hea_ProgrammeScheme")]
	public SchemeEntity? Scheme { get; set; }

	[JsonProperty("hea_addressline1")]
	public string? Address1 { get; set; }

	[JsonProperty("hea_addressline2")]
	public string? Address2 { get; set; }

	[JsonProperty("hea_postcode")]
	public string? Postcode { get; set; }

	[JsonProperty("hea_LocalAuthority")]
	public LocalAuthorityEntity? LocalAuthority { get; set; }

	[JsonProperty("hea_grantamount")]
	public decimal? GrantAmount { get; set; }

	[JsonProperty("hea_expenselimit")]
	public decimal? ExpensesAmount { get; set; }

	[JsonProperty("hea_totalamount")]
	public decimal? TotalAmount { get; set; }
}
