using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomesEngland.AHP.Data;

public class SchemeExpenseClaim
{
	public Guid SchemeExpenseClaimId { get; set; }

	[Required]
	public Guid SchemeId { get; set; }

	public Scheme Scheme { get; set; }

	[Column(TypeName = ColumnTypes.Money)]
	public decimal ExpenseAmount { get; set; }

	public DateTime Created { get; set; }

	public DateTime PaymentDate { get; set; }

	[Required]
	public Guid FinancialYearId { get; set; }

	public FinancialYear FinancialYear { get; set; }
}
