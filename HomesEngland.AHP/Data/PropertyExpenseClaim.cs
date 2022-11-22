using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomesEngland.AHP.Data;

public class PropertyExpenseClaim
{
	public Guid PropertyExpenseClaimId { get; set; }

	public Guid PropertyId { get; set; }
	public Property Property { get; set; }

	[Column(TypeName = ColumnTypes.Money)]
	public decimal ExpenseAmount { get; set; }

	public DateTime Created { get; set; }

	public DateTime PaymentDate { get; set; }

	[Required]
	public Guid FinancialYearId { get; set; }

	public FinancialYear FinancialYear { get; set; }
}
