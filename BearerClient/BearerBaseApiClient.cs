using System.Net.Http.Headers;
using WandleSolutions.Common;
using WandleSolutions.Common.ApiClient;

namespace BearerClient
{
    public class BearerBaseApiClient : BaseApiClient
    {
        private readonly IBearerTokenProvider _bearerTokenProvider;

        public BearerBaseApiClient(
            IHttpClientFactory httpClientFactory,
            string configurationKeyForFactory,
            IBearerTokenProvider bearerTokenProvider,
            ICancellationTokenProvider cancellationTokenProvider = null) : base(httpClientFactory, configurationKeyForFactory, cancellationTokenProvider)
        {
            Guard.ArgumentNotNull(bearerTokenProvider, nameof(bearerTokenProvider));

            _bearerTokenProvider = bearerTokenProvider;
        }

        public override async Task<HttpClient> GetHttpClient()
        {
            HttpClient httpClient = base.CreateHttpClient();

            string token = await _bearerTokenProvider.GetToken();
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new MissingBearerTokenException("Null or empty token from bearer token provider");
            }

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return httpClient;
        }
    }
}
