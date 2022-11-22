using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomesEngland.AHP.Data;

public class GrantMilestone
{
    [Required, Key]
    public Guid GrantMilestoneId { get; set; }

    [Required]
    public Guid PropertyId { get; set; }

    public Property Property { get; set; }

    public DateTime TargetDate { get; set; }
    public DateTime? CompletionDate { get; set; }


    [Required]
    public bool Completed { get; set; }

    [Column(TypeName = ColumnTypes.Money)]
    public decimal? GrantAmount { get; set; }

    [Required]
    public Guid MilestoneTypeId { get; set; }

    public MilestoneType MilestoneType { get; set; }

    [Required]
    public Guid FinancialYearId { get; set; }

    public FinancialYear FinancialYear { get; set; }
}
