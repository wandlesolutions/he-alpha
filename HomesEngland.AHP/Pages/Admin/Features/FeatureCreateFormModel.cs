using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Pages.Admin.Features;

public class FeatureCreateFormModel
{
	[Required, StringLength(64)]
	public string? FeatureName { get; set; }

	[Required, StringLength(32)]
	public string? FeatureKey { get; set; }

	[Required, StringLength(1024)]
	public string? Description { get; set; }
}
