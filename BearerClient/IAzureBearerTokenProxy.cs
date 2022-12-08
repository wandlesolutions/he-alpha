namespace BearerClient
{
    public interface IAzureBearerTokenProxy
    {
        Task<AzureBearerToken> FetchToken(AzureBearerTokenOptions azureBearerTokenOptions);
    }
}
