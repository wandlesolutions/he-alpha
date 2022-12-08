namespace BearerClient
{
    public interface ICacheProvider
    {
        Task<string?> GetAsync(string clientId);
        Task SetAsync(string clientId, string accessToken, TimeSpan timeSpan, bool forceUpdate);
    }
}
