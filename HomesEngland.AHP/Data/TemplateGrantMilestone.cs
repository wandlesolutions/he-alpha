using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomesEngland.AHP.Data;

public class TemplateGrantMilestone
{
	[Key, Required]
	public Guid TemplateGrantMilestoneId { get; set; }

	[Required]
	public Guid MilestoneTypeId { get; set; }

	public MilestoneType MilestoneType { get; set; }

	[Required]
	public Guid ProgrammeId { get; set; }

	public Programme Programme { get; set; }

	[Required]
	[Column(TypeName = ColumnTypes.Percentage)]
	public decimal Percentage { get; set; }

	[Required]
	public int MilestoneOrder { get; set; }

	[Required]
	public int TargetNumberOfDays { get; set; }
}
