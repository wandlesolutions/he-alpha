using HomesEngland.AHP.Data;
using HomesEngland.AHP.DynamicsClient.Models;

namespace HomesEngland.AHP.DynamicsClient;

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
			TotalRevenueFundingAmount = scheme.TotalExpenses,
			TotalGrantAmount = scheme.TotalGrant,
			TotalAmount = total,
			Programme = scheme.FundingProgramme?.ToModel(),
			LocalAuthority = scheme.LocalAuthority?.ToModel(),
			StatusCode = scheme.StatusCode,
			StatusName = scheme.StatusName,
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

	// Convert PropertyEntity to Property
	public static Property ToModel(this PropertyEntity propertyEntity)
	{
		return new Property()
		{
			Address1 = propertyEntity.Address1,
			Address2 = propertyEntity.Address2,
			ExpensesAmount = propertyEntity.ExpensesAmount,
			GrantAmount = propertyEntity.GrantAmount,
			Postcode = propertyEntity.Postcode,
			PropertyId = propertyEntity.PropertyId,
			PropertyName = propertyEntity.PropertyName,
			SchemeId = propertyEntity.SchemeId,
			TotalAmount = propertyEntity.TotalAmount,
			Scheme = propertyEntity?.Scheme?.ToModel(),
		};
	}

	// Convert GrantMilestoneEntity to GrantMilestone
	public static GrantMilestone ToModel(this GrantMilestoneEntity grantMilestoneEntity)
	{
		return new GrantMilestone()
		{
			Completed = grantMilestoneEntity.Completed,
			CompletionDate = grantMilestoneEntity.CompletionDate,
			MilestoneGrantAmount = grantMilestoneEntity.GrantAmount,
			GrantMilestoneId = grantMilestoneEntity.GrantMilestoneId,
			MilestoneType = new MilestoneType()
			{
				MilestoneTypeName = grantMilestoneEntity.MilestoneTypeName,
			},
			SchemeId = grantMilestoneEntity.SchemeId,
			Scheme = grantMilestoneEntity.Scheme?.ToModel(),
			TargetDate = grantMilestoneEntity.TargetDate,
		};
	}
}
