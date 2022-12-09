namespace BearerClient
{
    internal record TokenCacheItem
    {
        public string? AccessToken { get; internal set; }
        public DateTime Expires { get; internal set; }
    }
}
