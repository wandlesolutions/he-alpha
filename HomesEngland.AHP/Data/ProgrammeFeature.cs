using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Data;

public class ProgrammeFeature
{
    [Key, Required]
    public Guid ProgrammeFeatureId { get; set; }

    [Required]
    public Guid ProgrammeId { get; set; }

    [Required]
    public Guid FeatureId { get; set; }

    public Programme Programme { get; set; }
    public Feature Feature { get; set; }
}
