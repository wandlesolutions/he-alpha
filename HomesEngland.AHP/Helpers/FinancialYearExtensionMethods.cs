using HomesEngland.AHP.Data;

namespace HomesEngland.AHP.Helpers;

public static class FinancialYearExtensionMethods
{
	public static FinancialYear? FromDate(this IEnumerable<FinancialYear> financialYears, DateTimeOffset date)
	{
		return financialYears.FirstOrDefault(_ => _.StartDate <= date && _.EndDate >= date);
	}
}
