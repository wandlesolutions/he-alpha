namespace HomesEngland.AHP.Data;

public record LocalAuthority
{
	public required Guid LocalAuthorityId { get; set; }

	public required string LocalAuthorityName { get; set; }
}
