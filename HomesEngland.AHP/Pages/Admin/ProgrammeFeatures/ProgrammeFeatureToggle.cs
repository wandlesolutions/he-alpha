using HomesEngland.AHP.Shared;
using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Pages.Admin.ProgrammeFeatures;

public class ProgrammeFeatureToggle
{
	public Guid FeatureId { get; set; }
	public string FeatureName { get; set; }
	public string Description { get; set; }

	[Required, EnumDataType(typeof(GovEnabledValue))]
	public GovEnabledValue Toggled { get; set; }
}
