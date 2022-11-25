using HomesEngland.AHP.Data;
using HomesEngland.AHP.Shared;

namespace HomesEngland.AHP.Pages;

public static class BreadcrumbItemExtensionMethods
{
	public static List<BreadcrumbItem> AddAdminFeatures(this List<BreadcrumbItem> breadcrumbItems)
	{
		breadcrumbItems.Add(new BreadcrumbItem($"/admin/features", "Features"));
		return breadcrumbItems;
	}

	public static List<BreadcrumbItem> AddAdminProgramme(this List<BreadcrumbItem> breadcrumbItems, Programme programme)
	{
		breadcrumbItems.Add(new BreadcrumbItem($"/admin/programmes/byid/{programme.ProgrammeId}", programme.ProgrammeName));
		return breadcrumbItems;
	}

	public static List<BreadcrumbItem> AddAdminProgrammes(this List<BreadcrumbItem> breadcrumbItems)
	{
		breadcrumbItems.Add(new BreadcrumbItem("/admin/programmes", "Programmes"));
		return breadcrumbItems;
	}
	public static List<BreadcrumbItem> AddProvider(this List<BreadcrumbItem> breadcrumbItems, Provider provider)
	{
		breadcrumbItems.Add(new BreadcrumbItem($"/providers/byid/{provider.ProviderId}", provider.ProviderName));
		return breadcrumbItems;
	}

	public static List<BreadcrumbItem> AddSchemes(this List<BreadcrumbItem> breadcrumbItems, Provider provider)
	{
		breadcrumbItems.Add(new BreadcrumbItem($"/providers/byid/{provider.ProviderId}/schemes", "Schemes"));
		return breadcrumbItems;
	}

}
