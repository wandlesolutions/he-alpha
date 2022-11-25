using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Pages.Providers.Schemes;

public class SchemeCreateFormModel
{
	[Required, StringLength(64)]
	public string? SchemeName { get; set; }

	[Required]
	public string? ProgrammeId { get; set; }

	[Required, Range(1, double.MaxValue)]
	public decimal? TotalAmount { get; set; }
}
