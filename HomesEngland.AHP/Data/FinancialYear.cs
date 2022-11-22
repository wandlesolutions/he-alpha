using System.ComponentModel.DataAnnotations;

namespace HomesEngland.AHP.Data;

public class FinancialYear
{
    [Required, Key]
    public Guid FinanicalYearId { get; set; }

    [Required, StringLength(64)]
    public string FinancialYearName { get; set; }

    [Required]
    public DateTimeOffset StartDate { get; set; }

    [Required]
    public DateTimeOffset EndDate { get; set; }
}
