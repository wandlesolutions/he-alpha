using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Data;

public class MilestoneType
{
    public Guid MilestoneTypeId { get; set; }

    [Required, StringLength(32)]
    public string MilestoneName { get; set; }

    [Required]
    public bool Enabled { get; set; }
}
