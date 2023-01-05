using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Pages.Providers.RevenueFunding;

public class RevenueFundingClaimFormModel
{
	[Required, Range(0, double.MaxValue)]
	public decimal? ClaimAmount { get; set; }

	[Required]
	public DateTimeOffset? PaymentDate { get; set; }
}
