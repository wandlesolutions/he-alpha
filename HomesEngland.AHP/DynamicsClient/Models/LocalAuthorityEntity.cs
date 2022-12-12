using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

public class LocalAuthorityEntity
{
	public const string QueryFields = "name,accountid";

	[JsonProperty("accountid")]
	public required Guid LocalAuthorityId { get; set; }

	[JsonProperty("name")]
	public required string LocalAuthorityName { get; set; }
}
