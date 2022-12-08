namespace BearerClient
{
    public class InMemoryTokenCacheProvider : ICacheProvider
    {
        Dictionary<string, string> _items = new Dictionary<string, string>();

        public Task<string?> GetAsync(string clientId)
        {
            string? value = null;

            if (_items.TryGetValue(clientId, out value))
            {
            }

            return Task.FromResult(value);
        }

        public Task SetAsync(string clientId, string accessToken, TimeSpan timeSpan, bool forceUpdate)
        {
            _items[clientId] = accessToken;

            return Task.CompletedTask;
        }
    }
}
