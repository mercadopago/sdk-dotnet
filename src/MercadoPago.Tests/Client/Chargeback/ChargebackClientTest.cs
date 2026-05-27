namespace MercadoPago.Tests.Client.Chargeback
{
    using MercadoPago.Client.Chargeback;
    using MercadoPago.Http;
    using MercadoPago.Serialization;
    using MercadoPago.Tests.Client;
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
        public async void GetAsync_Success()
        {
            var chargeback = await client.GetAsync(123456789L);
            Assert.NotNull(chargeback);
        }
    }
}
