using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomesEngland.AHP.Data;

public class Property
{
	[Required, Key]
	public Guid ProperyId { get; set; }

	[Required, StringLength(64)]
	public string PropertyName { get; set; }

	[Required]
	public Guid SchemeId { get; set; }

	public Scheme Scheme { get; set; }

	[StringLength(64)]
	public string? Address1 { get; set; }

	[StringLength(64)]
	public string? Address2 { get; set; }

	[StringLength(16)]
	public string? Postcode { get; set; }

	[StringLength(64)]
	public string? LocalAuthority { get; set; }

	[Column(TypeName = ColumnTypes.Money)]
	public decimal? GrantAmount { get; set; }

	[Column(TypeName = ColumnTypes.Money)]
	public decimal? ExpensesTotal { get; set; }
}
