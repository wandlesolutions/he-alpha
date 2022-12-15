using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Pages.Providers.Schemes;

public class SchemeCreateFormModel
{
	[Required, StringLength(200)]
	public string? SchemeName { get; set; }

	[Required]
	public string? ProgrammeId { get; set; }

	public string? LocalAuthorityId { get; set; }

	[Required, Range(0, double.MaxValue)]
	public decimal? GrantAmount { get; set; }

	[Required, Range(0, double.MaxValue)]
	public decimal? ExpensesAmount { get; set; }
}
