namespace BearerClient
{
    public class InMemoryTokenCacheProvider : ICacheProvider
    {
        Dictionary<string, TokenCacheItem> _items = new Dictionary<string, TokenCacheItem>();

        public Task<string?> GetAsync(string clientId)
        {
            string? value = null;

            if (_items.TryGetValue(clientId, out TokenCacheItem? item))
            {
                if (item.Expires > DateTime.UtcNow)
                {
                    value = item.AccessToken;
                }
                else
                {
                    _items.Remove(clientId);
                }
            }

            return Task.FromResult(value);
        }

        public Task SetAsync(string clientId, string accessToken, TimeSpan timeSpan, bool forceUpdate)
        {
            _items[clientId] = new TokenCacheItem()
            {
                AccessToken = accessToken,
                Expires = DateTime.Now.Add(timeSpan),
            };


            return Task.CompletedTask;
        }
    }
}
