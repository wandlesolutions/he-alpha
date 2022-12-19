using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

public record GrantMilestoneEntity
{
	public const string QueryFields = "hea_schememilestoneid,_hea_programmescheme_value,hea_completed,hea_completeddate,hea_grantamount,hea_targetdate,hea_milestonetype";

	[JsonProperty("hea_schememilestoneid")]
	public Guid GrantMilestoneId { get; set; }

	[JsonProperty("_hea_programmescheme_value")]
	public Guid SchemeId { get; set; }

	[JsonProperty("hea_ProgrammeScheme")]
	public SchemeEntity? Scheme { get; set; }

	[JsonProperty("hea_completed")]
	public bool Completed { get; set; }

	[JsonProperty("hea_completeddate")]
	public DateTimeOffset? CompletionDate { get; set; }

	[JsonProperty("hea_grantamount")]
	public decimal? GrantAmount { get; set; }

	[JsonProperty("hea_milestonetype@OData.Community.Display.V1.FormattedValue")]
	public string MilestoneTypeName { get; set; }

	[JsonProperty("hea_targetdate")]
	public DateTimeOffset TargetDate { get; set; }
}
