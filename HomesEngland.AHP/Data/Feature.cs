using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Data;

public class Feature
{
	[Key, Required]
	public Guid FeatureId { get; set; }

	[Required, StringLength(64)]
	public string FeatureName { get; set; }

	[Required, StringLength(32)]
	public string FeatureKey { get; set; }

	[Required, StringLength(1024)]
	public string Description { get; set; }

	public ICollection<ProgrammeFeature> ProgrammeFeatures { get; set; }
}
