namespace MercadoPago.Tests.Client.PreApprovalPlan
{
    using MercadoPago.Client.PreApprovalPlan;
    using MercadoPago.Http;
    using MercadoPago.Serialization;
    using MercadoPago.Tests.Client;
    using Xunit;

    public class PreApprovalPlanClientTest : BaseClientTest
    {
        private readonly PreApprovalPlanClient client;

        public PreApprovalPlanClientTest(ClientFixture clientFixture)
            : base(clientFixture)
        {
            client = new PreApprovalPlanClient();
        }

        [Fact]
        public void Constructor_HttpClientAndSerializer_Success()
        {
            var httpClient = new DefaultHttpClient();
            var serializer = new DefaultSerializer();
            var c = new PreApprovalPlanClient(httpClient, serializer);

            Assert.Equal(httpClient, c.HttpClient);
            Assert.Equal(serializer, c.Serializer);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Constructor_HttpClient_Success()
        {
            var httpClient = new DefaultHttpClient();
            var c = new PreApprovalPlanClient(httpClient);
            Assert.Equal(httpClient, c.HttpClient);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Constructor_Serializer_Success()
        {
            var serializer = new DefaultSerializer();
            var c = new PreApprovalPlanClient(serializer);
            Assert.Equal(serializer, c.Serializer);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Constructor_NullParameters_Success()
        {
            var c = new PreApprovalPlanClient();
            Assert.NotNull(c);
        }

        [Fact(Skip = "Not running in CI.")]
        public async void CreateAsync_Success()
        {
            var request = new PreApprovalPlanCreateRequest
            {
                Reason = "Monthly plan",
                BackUrl = "https://example.com/back",
                AutoRecurring = new PreApprovalPlanAutoRecurringRequest
                {
                    Frequency = 1,
                    FrequencyType = "months",
                    CurrencyId = "BRL",
                    TransactionAmount = 100m
                }
            };
            var plan = await client.CreateAsync(request);
            Assert.NotNull(plan);
            Assert.NotNull(plan.Id);
        }
    }
}
