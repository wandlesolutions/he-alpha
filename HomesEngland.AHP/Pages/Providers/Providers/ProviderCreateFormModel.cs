using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Pages.Providers.Providers;

public class ProviderCreateFormModel
{
	[Required, StringLength(64)]
	public string? ProviderName { get; set; }
}
