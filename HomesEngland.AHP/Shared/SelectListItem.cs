namespace HomesEngland.AHP.Shared;

public class SelectListItem
{
	public SelectListItem()
	{

	}

	public SelectListItem(string text, string value)
	{
		Text = text;
		Value = value;
	}

	public string Text { get; set; }
	public string Value { get; set; }
}