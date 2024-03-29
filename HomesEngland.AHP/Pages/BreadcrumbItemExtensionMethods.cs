﻿using HomesEngland.AHP.Data;
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

	public static List<BreadcrumbItem> AddAdminGrantMilestoneTemplates(this List<BreadcrumbItem> breadcrumbItems, Programme programme)
	{
		breadcrumbItems.Add(new BreadcrumbItem($"/admin/programmes/byid/{programme.ProgrammeId}/milestoneTemplates", "Milestone templates"));
		return breadcrumbItems;
	}

	public static List<BreadcrumbItem> AddAdminProgrammes(this List<BreadcrumbItem> breadcrumbItems)
	{
		breadcrumbItems.Add(new BreadcrumbItem("/admin/programmes", "Programmes"));
		return breadcrumbItems;
	}
	public static List<BreadcrumbItem> AddProvider(this List<BreadcrumbItem> breadcrumbItems, Provider provider)
	{
		if (provider == null)
		{
			return breadcrumbItems;
		}

		breadcrumbItems.Add(new BreadcrumbItem($"/providers/byid/{provider.ProviderId}", provider.ProviderName));
		return breadcrumbItems;
	}

	public static List<BreadcrumbItem> AddSchemes(this List<BreadcrumbItem> breadcrumbItems, Provider provider)
	{
		breadcrumbItems.Add(new BreadcrumbItem($"/providers/byid/{provider.ProviderId}/schemes", "Schemes"));
		return breadcrumbItems;
	}

	public static List<BreadcrumbItem> AddScheme(this List<BreadcrumbItem> breadcrumbItems, Provider provider, Scheme scheme)
	{
		if (scheme == null)
		{
			return breadcrumbItems;
		}

		if (provider == null)
		{
			return breadcrumbItems;
		}

		breadcrumbItems.Add(new BreadcrumbItem($"/providers/byid/{provider.ProviderId}/schemes/byid/{scheme.SchemeId}", scheme.SchemeName));
		return breadcrumbItems;
	}

	public static List<BreadcrumbItem> AddProperties(this List<BreadcrumbItem> breadcrumbItems, Provider provider)
	{
		if (provider == null)
		{

			return breadcrumbItems;
		}

		breadcrumbItems.Add(new BreadcrumbItem($"/providers/byid/{provider.ProviderId}/properties", "Properties"));
		return breadcrumbItems;
	}

	public static List<BreadcrumbItem> AddProperty(this List<BreadcrumbItem> breadcrumbItems, Provider provider, Property property)
	{
		breadcrumbItems.Add(new BreadcrumbItem($"/providers/byid/{provider.ProviderId}/properties/byid/{property.PropertyId}", property.PropertyName));
		return breadcrumbItems;
	}

	public static List<BreadcrumbItem> AddGrantMilestones(this List<BreadcrumbItem> breadcrumbItems, Provider provider, Property property)
	{
		breadcrumbItems.Add(new BreadcrumbItem($"/providers/byid/{provider.ProviderId}/properties/byid/{property.PropertyId}/grantMilestones", property.PropertyName));
		return breadcrumbItems;
	}

}
