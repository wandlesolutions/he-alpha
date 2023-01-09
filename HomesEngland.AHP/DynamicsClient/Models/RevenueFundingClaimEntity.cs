using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

public class RevenueFundingClaimEntity
{
	public const string QueryFields = "hea_schemeexpenseclaimid,hea_amountclaimed,_hea_programmescheme_value,hea_forecastpaymentdate,statecode,createdon";

	[JsonProperty("hea_schemeexpenseclaimid")]
	public Guid SchemeExpenseClaimId { get; set; }

	[JsonProperty("hea_amountclaimed")]
	public decimal AmountClaimed { get; set; }

	[JsonProperty("hea_ProgrammeScheme")]
	public SchemeEntity? Scheme { get; set; }

	[JsonProperty("_hea_programmescheme_value")]
	public Guid SchemeId { get; set; }

	[JsonProperty("hea_forecastpaymentdate")]
	public DateTimeOffset? ForecastPaymentDate { get; set; }

	[JsonProperty("statuscode@OData.Community.Display.V1.FormattedValue")]
	public string? StatusName { get; set; }

	[JsonProperty("statuscode")]
	public int? StatusCode { get; set; }

	[JsonProperty("createdon")]
	public DateTimeOffset Created { get; set; }
}
