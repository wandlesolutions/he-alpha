using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Data;

public class Feature
{
    [Key, Required]
    public Guid FeatureId { get; set; }

    [Required, StringLength(64)]
    public string FeatureName { get; set; }

    public ICollection<ProgrammeFeature> ProgrammeFeatures { get; set; }
}
