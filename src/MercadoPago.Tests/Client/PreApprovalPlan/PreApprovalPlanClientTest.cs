namespace MercadoPago.Tests.Client.PreApprovalPlan
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Client.PreApprovalPlan;
    using MercadoPago.Http;
    using MercadoPago.Resource.PreApprovalPlan;
    using MercadoPago.Serialization;
    using MercadoPago.Tests.Client;
    using Moq;
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
        public async Task CreateAsync_Success()
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

        [Fact]
        public async Task GetAsync_Success()
        {
            var json = File.ReadAllText("Client/Mock/PreApprovalPlanGetResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var planClient = new PreApprovalPlanClient(mock.Object);
            var result = await planClient.GetAsync("plan-abc-123");

            Assert.NotNull(result);
            Assert.Equal("plan-abc-123", result.Id);
            Assert.Equal("Monthly yoga subscription", result.Reason);
            Assert.Equal("active", result.Status);
        }

        [Fact]
        public void Get_Success()
        {
            var json = File.ReadAllText("Client/Mock/PreApprovalPlanGetResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var planClient = new PreApprovalPlanClient(mock.Object);
            var result = planClient.Get("plan-abc-123");

            Assert.NotNull(result);
            Assert.Equal("plan-abc-123", result.Id);
        }

        [Fact]
        public async Task UpdateAsync_Success()
        {
            var json = File.ReadAllText("Client/Mock/PreApprovalPlanUpdateResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var planClient = new PreApprovalPlanClient(mock.Object);
            var updateRequest = new PreApprovalPlanUpdateRequest { Reason = "Updated yoga subscription" };
            var result = await planClient.UpdateAsync("plan-abc-123", updateRequest);

            Assert.NotNull(result);
            Assert.Equal("plan-abc-123", result.Id);
            Assert.Equal("Updated yoga subscription", result.Reason);
        }

        [Fact]
        public void Update_Success()
        {
            var json = File.ReadAllText("Client/Mock/PreApprovalPlanUpdateResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var planClient = new PreApprovalPlanClient(mock.Object);
            var updateRequest = new PreApprovalPlanUpdateRequest { Reason = "Updated yoga subscription" };
            var result = planClient.Update("plan-abc-123", updateRequest);

            Assert.NotNull(result);
            Assert.Equal("plan-abc-123", result.Id);
        }

        [Fact]
        public async Task SearchAsync_Success()
        {
            var json = File.ReadAllText("Client/Mock/PreApprovalPlanSearchResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var planClient = new PreApprovalPlanClient(mock.Object);
            var searchRequest = new MercadoPago.Client.SearchRequest { Limit = 10, Offset = 0 };
            var result = await planClient.SearchAsync(searchRequest);

            Assert.NotNull(result);
            Assert.NotNull(result.Paging);
            Assert.Equal(1, result.Paging.Total);
            Assert.NotNull(result.Results);
            Assert.Equal("plan-abc-123", result.Results[0].Id);
        }

        [Fact]
        public void Search_Success()
        {
            var json = File.ReadAllText("Client/Mock/PreApprovalPlanSearchResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var planClient = new PreApprovalPlanClient(mock.Object);
            var searchRequest = new MercadoPago.Client.SearchRequest { Limit = 10, Offset = 0 };
            var result = planClient.Search(searchRequest);

            Assert.NotNull(result);
            Assert.NotNull(result.Paging);
            Assert.Equal(1, result.Paging.Total);
        }
    }
}
