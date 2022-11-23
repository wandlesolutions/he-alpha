using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Pages.Admin.Programmes;

public class ProgrammeCreateFormModel
{
	[Required, StringLength(64)]
	public string? ProgrammeName { get; set; }

	[Required]
	public DateTimeOffset? Start { get; set; }

	[Required]
	public DateTimeOffset? Finish { get; set; }
}
