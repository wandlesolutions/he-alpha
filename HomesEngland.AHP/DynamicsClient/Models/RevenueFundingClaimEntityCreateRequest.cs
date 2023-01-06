using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

public class RevenueFundingClaimEntityCreateRequest
{
	[JsonProperty("hea_amountclaimed")]
	public decimal AmountClaimed { get; set; }

	[JsonProperty("hea_ProgrammeScheme@odata.bind")]
	public AssociatedEntity Scheme { get; set; }

	[JsonProperty("hea_forecastpaymentdate")]
	public DateTimeOffset? ForecastPaymentDate { get; set; }
}
