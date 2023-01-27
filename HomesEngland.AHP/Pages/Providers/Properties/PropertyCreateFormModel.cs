namespace HomesEngland.AHP.Pages.Providers.Properties;

public class PropertyCreateFormModel
{
	public string? PropertyName { get; set; }
	public string? Address1 { get; set; }
	public string? Address2 { get; set; }
	public string? Postcode { get; set; }
	public decimal? GrantAmount { get; set; }

	public string? ProgrammeId { get; set; }
	public string? SchemeId { get; set; }
}
