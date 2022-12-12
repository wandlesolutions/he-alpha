using HomesEngland.AHP.Data;

namespace HomesEngland.AHP.DynamicsClient.Models;

public static class DynamicsConverters
{
	public static Programme ToModel(this FundingProgrammeEntity fundingProgramme)
	{
		return new Programme()
		{
			ProgrammeName = fundingProgramme.Name,
			ProgrammeId = fundingProgramme.FundingProgrammeId,
			Start = fundingProgramme.Start,
			Finish = fundingProgramme.Finish,
		};
	}

	public static Provider ToModel(this ProviderEntity provider)
	{
		return new Provider
		{
			ProviderId = provider.AccountId,
			ProviderName = provider.Name
		};
	}

	// Convert from SchemeEntity to Scheme extension method
	public static Scheme ToModel(this SchemeEntity scheme)
	{
		decimal total = 0;
		if (scheme.TotalExpenses.HasValue)
		{
			total = scheme.TotalExpenses.Value;
		}

		if (scheme.TotalGrant.HasValue)
		{
			total += scheme.TotalGrant.Value;
		}

		return new Scheme()
		{
			ProgrammeId = scheme.ProgrammeId,
			ProviderId = scheme.ProviderId,
			SchemeId = scheme.SchemeId,
			SchemeName = scheme.SchemeName,
			TotalExpensesAmount = scheme.TotalExpenses,
			TotalGrant = scheme.TotalGrant,
			TotalAmount = total,
			Programme = scheme.FundingProgramme?.ToModel(),
		};
	}

	public static Scheme ToModel(this SchemeEntity scheme, IDictionary<Guid, Programme>? programmes)
	{
		Scheme result = scheme.ToModel();

		if (programmes != null && programmes.TryGetValue(scheme.ProgrammeId, out Programme? programme))
		{
			if (programme != null)
			{
				result.Programme = programme;
			}
		}

		return result;
	}

	// Convert LocalAuthorityEntity to LocalAuthority
	public static LocalAuthority ToModel(this LocalAuthorityEntity localAuthority)
	{
		return new LocalAuthority()
		{
			LocalAuthorityId = localAuthority.LocalAuthorityId,
			LocalAuthorityName = localAuthority.LocalAuthorityName,
		};
	}
}
