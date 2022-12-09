using BearerClient;
using FluentAssertions;
using HomesEngland.AHP.DynamicsClient;
using Moq;

namespace HomesEngland.AHP.UnitTests
{
    [TestClass]
    public class DynamicsRepositoryTests
    {
        private Mock<IHttpClientFactory> _httpClientFactory;
        private Mock<IBearerTokenProvider> _httpBearerTokenProvider;
        private DynamicsRepository _repo;

        [TestInitialize]
        public void Setup()
        {
            _httpClientFactory = new Mock<IHttpClientFactory>();
            _httpBearerTokenProvider = new Mock<IBearerTokenProvider>();
            _repo = new DynamicsRepository(_httpClientFactory.Object, "Dynamics", _httpBearerTokenProvider.Object, null);
        }

        [TestMethod]
        public void ExtractEntityKey_WhenValidUrl_ThenExtractEntityIdIsCorrect()
        {
            TestHttpHeaders headers = new TestHttpHeaders();
            headers.Add("OData-EntityId", "https://org1f7c5080.api.crm11.dynamics.com/api/data/v9.2/accounts(34f2615a-a477-ed11-81ac-00224841beb0)");

            var result = DynamicsRepository.ExtractEntityKey(headers);

            result.Should().Be("34f2615a-a477-ed11-81ac-00224841beb0");
        }


        [TestMethod]
        public void ExtractEntityKey_WhenValidUrlWithMultipleBrackets_ThenExtractEntityIdIsCorrect()
        {
            TestHttpHeaders headers = new TestHttpHeaders();
            headers.Add("OData-EntityId", "https://org1f7c5080.api.crm11.dynamics.com/api/data/v9.2/accounts(firstGuid)/accounts(34f2615a-a477-ed11-81ac-00224841beb0)");

            var result = DynamicsRepository.ExtractEntityKey(headers);

            result.Should().Be("34f2615a-a477-ed11-81ac-00224841beb0");
        }

        [TestMethod]
        public void ExtractEntityKey_WhenInvalidUrl_ThenReturnIsNull()
        {
            TestHttpHeaders headers = new TestHttpHeaders();
            headers.Add("OData-EntityId", "https://org1f7c5080.api.crm11.dynamics.com/api/data/v9.2/accounts(34f2615a-a477-ed11-81ac-00224841beb0");

            var result = DynamicsRepository.ExtractEntityKey(headers);

            result.Should().BeNull();
        }
    }
}