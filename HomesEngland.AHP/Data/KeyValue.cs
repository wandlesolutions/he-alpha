namespace HomesEngland.AHP.Data;

public record KeyValue
{
	public required Guid Key { get; set; }

	public required string Value { get; set; }
}
