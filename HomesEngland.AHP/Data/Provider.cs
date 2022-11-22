using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Data;

public class Provider
{
    [Required, Key]
    public Guid ProviderId { get; set; }

    [Required, StringLength(64)]
    public string ProviderName { get; set; }
}
