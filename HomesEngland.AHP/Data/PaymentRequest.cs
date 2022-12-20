using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomesEngland.AHP.Data;

public class PaymentRequest
{
	[Required, Key]
	public Guid PaymentRequestId { get; set; }

	public DateTimeOffset Created { get; set; }

	public DateTimeOffset PaymentDate { get; set; }

	[Column(TypeName = ColumnTypes.Money)]
	public double Amount { get; set; }

	public Guid? PropertyExpenseClaimId { get; set; }
	public SchemeRevenueClaim? PropertyExpenseClaim { get; set; }

	public Guid? GrantMilestoneId { get; set; }
	public GrantMilestone? GrantMilestone { get; set; }

	[Required]
	public Guid FinancialYearId { get; set; }

	public FinancialYear FinancialYear { get; set; }
}
