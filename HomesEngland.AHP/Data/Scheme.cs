using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomesEngland.AHP.Data;

public class Scheme
{
	[Required, Key]
	public Guid SchemeId { get; set; }

	[Required, StringLength(64)]
	public string SchemeName { get; set; }

	[Required]
	public Guid ProviderId { get; set; }

	public Provider Provider { get; set; }

	[Required]
	public Guid ProgrammeId { get; set; }

	public Programme Programme { get; set; }

	public ICollection<Property>? Properties { get; set; }

	public ICollection<GrantMilestone>? GrantMilestones { get; set; }

	[Column(TypeName = ColumnTypes.Money)]
	public decimal? TotalGrant { get; set; }

	[Column(TypeName = ColumnTypes.Money)]
	public decimal? TotalExpensesAmount { get; set; }

	[Column(TypeName = ColumnTypes.Money)]
	public decimal? TotalAmount { get; set; }

	[Required]
	public bool Complete { get; set; }

	public DateTimeOffset? Completed { get; set; }
}
