namespace MercadoPago.Tests.Client.DisbursementRefund
{
    using MercadoPago.Client.DisbursementRefund;
    using MercadoPago.Http;
    using MercadoPago.Serialization;
    using MercadoPago.Tests.Client;
    using Xunit;

    public class DisbursementRefundClientTest : BaseClientTest
    {
        private readonly DisbursementRefundClient client;

        public DisbursementRefundClientTest(ClientFixture clientFixture)
            : base(clientFixture)
        {
            client = new DisbursementRefundClient();
        }

        [Fact]
        public void Constructor_HttpClientAndSerializer_Success()
        {
            var httpClient = new DefaultHttpClient();
            var serializer = new DefaultSerializer();
            var c = new DisbursementRefundClient(httpClient, serializer);

            Assert.Equal(httpClient, c.HttpClient);
            Assert.Equal(serializer, c.Serializer);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Constructor_HttpClient_Success()
        {
            var httpClient = new DefaultHttpClient();
            var c = new DisbursementRefundClient(httpClient);
            Assert.Equal(httpClient, c.HttpClient);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Constructor_Serializer_Success()
        {
            var serializer = new DefaultSerializer();
            var c = new DisbursementRefundClient(serializer);
            Assert.Equal(serializer, c.Serializer);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Constructor_NullParameters_Success()
        {
            var c = new DisbursementRefundClient();
            Assert.NotNull(c);
        }

        [Fact(Skip = "Not running in CI.")]
        public async void ListAllAsync_Success()
        {
            var refunds = await client.ListAllAsync(123456789L);
            Assert.NotNull(refunds);
        }
    }
}
