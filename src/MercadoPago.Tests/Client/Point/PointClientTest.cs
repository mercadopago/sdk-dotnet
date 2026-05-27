namespace MercadoPago.Tests.Client.Point
{
    using MercadoPago.Client.Point;
    using MercadoPago.Http;
    using MercadoPago.Serialization;
    using MercadoPago.Tests.Client;
    using Xunit;

    public class PointClientTest : BaseClientTest
    {
        private readonly PointClient client;

        public PointClientTest(ClientFixture clientFixture)
            : base(clientFixture)
        {
            client = new PointClient();
        }

        [Fact]
        public void Constructor_HttpClientAndSerializer_Success()
        {
            var httpClient = new DefaultHttpClient();
            var serializer = new DefaultSerializer();
            var c = new PointClient(httpClient, serializer);

            Assert.Equal(httpClient, c.HttpClient);
            Assert.Equal(serializer, c.Serializer);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Constructor_HttpClient_Success()
        {
            var httpClient = new DefaultHttpClient();
            var c = new PointClient(httpClient);
            Assert.Equal(httpClient, c.HttpClient);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Constructor_Serializer_Success()
        {
            var serializer = new DefaultSerializer();
            var c = new PointClient(serializer);
            Assert.Equal(serializer, c.Serializer);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Constructor_NullParameters_Success()
        {
            var c = new PointClient();
            Assert.NotNull(c);
        }

        [Fact(Skip = "Not running in CI.")]
        public async void CreateAsync_Success()
        {
            var request = new PointCreatePaymentIntentRequest
            {
                Amount = 100m,
                Description = "Test purchase",
                Payment = new PointPaymentRequest { Installments = 1, Type = "credit_card" }
            };
            var intent = await client.CreateAsync("DEVICE_ID", request);
            Assert.NotNull(intent);
            Assert.NotNull(intent.Id);
        }
    }
}
