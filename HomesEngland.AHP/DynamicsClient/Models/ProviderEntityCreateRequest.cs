using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

public class ProviderEntityCreateRequest
{
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("customertypecode")]
	public int CustomerTypeCode { get; set; }
}
