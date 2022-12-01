namespace HomesEngland.AHP.Shared;

public class BreadcrumbItem : IEquatable<BreadcrumbItem>
{
	public BreadcrumbItem()
	{

	}

	public BreadcrumbItem(string href, string title)
	{
		Href = href;
		Title = title;
	}

	public string Href { get; set; }

	public string Title { get; set; }

	public static List<BreadcrumbItem> AdminBase() => new()
	{
		new BreadcrumbItem("/", Constants.SystemName),
		new BreadcrumbItem("/admin", "Admin"),
	};

	public static List<BreadcrumbItem> ProviderBase() => new()
	{
		new BreadcrumbItem("/", Constants.SystemName),
		new BreadcrumbItem("/providers", "Login as provider"),
	};

	public static List<BreadcrumbItem> Home() => new()
	{
		new BreadcrumbItem("/", Constants.SystemName),
	};

	public bool Equals(BreadcrumbItem? other)
	{
		if (this == null && other == null)
		{
			return true;
		}

		if (this == null || other == null)
		{
			return false;
		}

		return this.Title == other.Title
			&& this.Href == other.Href;
	}


	public override bool Equals(object obj) => Equals(obj as BreadcrumbItem);
	public override int GetHashCode() => (Href, Title).GetHashCode();
}

