using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

public class PropertyEntityCreateRequest
{
	[JsonProperty("hea_name")]
	public required string PropertyName { get; set; }

	[JsonProperty("hea_ProgrammeScheme@odata.bind")]
	public required AssociatedEntity Scheme { get; set; }

	[JsonProperty("hea_addressline1")]
	public string? Address1 { get; set; }

	[JsonProperty("hea_addressline2")]
	public string? Address2 { get; set; }

	[JsonProperty("hea_postcode")]
	public string? Postcode { get; set; }

	//[JsonProperty("hea_LocalAuthority@odata.bind")]
	//public AssociatedEntity? LocalAuthority { get; set; }

	[JsonProperty("hea_grantamount")]
	public decimal? GrantAmount { get; set; }

	[JsonProperty("hea_totalamount")]
	public decimal? TotalAmount { get; set; }
}
