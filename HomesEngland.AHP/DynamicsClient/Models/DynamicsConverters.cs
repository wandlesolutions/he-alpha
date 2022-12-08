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
}
