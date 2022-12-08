namespace BearerClient
{
    public interface IBearerTokenProvider
    {
        Task<string> GetToken();
    }
}
