namespace MercadoPago.Tests.Client.Chargeback
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Client.Chargeback;
    using MercadoPago.Http;
    using MercadoPago.Resource.Chargeback;
    using MercadoPago.Serialization;
    using MercadoPago.Tests.Client;
    using Moq;
    using Xunit;

    public class ChargebackClientTest : BaseClientTest
    {
        private readonly ChargebackClient client;

        public ChargebackClientTest(ClientFixture clientFixture)
            : base(clientFixture)
        {
            client = new ChargebackClient();
        }

        [Fact]
        public void Constructor_HttpClientAndSerializer_Success()
        {
            var httpClient = new DefaultHttpClient();
            var serializer = new DefaultSerializer();
            var c = new ChargebackClient(httpClient, serializer);

            Assert.Equal(httpClient, c.HttpClient);
            Assert.Equal(serializer, c.Serializer);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Constructor_HttpClient_Success()
        {
            var httpClient = new DefaultHttpClient();
            var c = new ChargebackClient(httpClient);
            Assert.Equal(httpClient, c.HttpClient);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Constructor_Serializer_Success()
        {
            var serializer = new DefaultSerializer();
            var c = new ChargebackClient(serializer);
            Assert.Equal(serializer, c.Serializer);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Constructor_NullParameters_Success()
        {
            var c = new ChargebackClient();
            Assert.NotNull(c);
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task GetAsync_Success()
        {
            var chargeback = await client.GetAsync(123456789L);
            Assert.NotNull(chargeback);
        }

        [Fact]
        public async Task SearchAsync_Success()
        {
            var json = File.ReadAllText("Client/Mock/ChargebackSearchResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var chargebackClient = new ChargebackClient(mock.Object);
            var searchRequest = new MercadoPago.Client.SearchRequest
            {
                Limit = 10,
                Offset = 0,
            };
            var result = await chargebackClient.SearchAsync(searchRequest);

            Assert.NotNull(result);
            Assert.NotNull(result.Paging);
            Assert.Equal(1, result.Paging.Total);
            Assert.NotNull(result.Results);
            Assert.Equal("chargeback-123", result.Results[0].Id);
        }

        [Fact]
        public void Search_Success()
        {
            var json = File.ReadAllText("Client/Mock/ChargebackSearchResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var chargebackClient = new ChargebackClient(mock.Object);
            var searchRequest = new MercadoPago.Client.SearchRequest
            {
                Limit = 10,
                Offset = 0,
            };
            var result = chargebackClient.Search(searchRequest);

            Assert.NotNull(result);
            Assert.NotNull(result.Paging);
            Assert.Equal(1, result.Paging.Total);
        }
    }
}
