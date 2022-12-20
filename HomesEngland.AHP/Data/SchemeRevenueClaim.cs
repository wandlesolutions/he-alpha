using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomesEngland.AHP.Data;

public class SchemeRevenueClaim
{
	public Guid SchemeRevenueClaimId { get; set; }

	[Required]
	public Guid SchemeId { get; set; }

	public Scheme Scheme { get; set; }

	[Column(TypeName = ColumnTypes.Money)]
	public decimal ClaimAmount { get; set; }

	public DateTime Created { get; set; }

	public DateTime PaymentDate { get; set; }

	[Required]
	public Guid FinancialYearId { get; set; }

	public FinancialYear FinancialYear { get; set; }
}
