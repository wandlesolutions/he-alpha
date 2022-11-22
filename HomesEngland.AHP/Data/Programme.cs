using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Data;

public class Programme
{
	[Key, Required]
	public Guid ProgrammeId { get; set; }

	[Required, StringLength(64)]
	public string ProgrammeName { get; set; }

	[Required]
	public DateTimeOffset Start { get; set; }

	[Required]
	public DateTimeOffset Finish { get; set; }

	public ICollection<ProgrammeFeature> ProgrammeFeatures { get; set; }

	public ICollection<TemplateGrantMilestone> TemplateGrantMilestones { get; set; }

	public ICollection<Scheme> Schemes { get; set; }
}
