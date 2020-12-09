namespace MercadoPago.Tests.Client.Preapproval
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Client;
    using MercadoPago.Client.Preapproval;
    using MercadoPago.Config;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.PreApproval;
    using MercadoPago.Serialization;
    using MercadoPago.Tests.Client.Helper;
    using Xunit;

    [Collection("Uses User Email")]
    public class PreapprovalClientTest : BaseClientTest
    {
        private readonly PreapprovalClient client;

        public PreapprovalClientTest(ClientFixture clientFixture)
            : base(clientFixture)
        {
            client = new PreapprovalClient();
        }

        [Fact]
        public void Constructor_HttpClientAndSerializer_Success()
        {
            var httpClient = new DefaultHttpClient();
            var serializer = new DefaultSerializer();
            var client = new PreapprovalClient(httpClient, serializer);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_HttpClient_Success()
        {
            var httpClient = new DefaultHttpClient();
            var client = new PreapprovalClient(httpClient);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_Serializer_Success()
        {
            var serializer = new DefaultSerializer();
            var client = new PreapprovalClient(serializer);

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_NullParameters_Success()
        {
            var client = new PreapprovalClient();

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public async Task CreateAsync_Success()
        {
            PreapprovalCreateRequest request = BuildCreateRequest();

            Preapproval preapproval = await client.CreateAsync(request);

            Assert.NotNull(preapproval);
            Assert.NotNull(preapproval.Id);
        }

        [Fact]
        public void Create_Success()
        {
            PreapprovalCreateRequest request = BuildCreateRequest();

            Preapproval preapproval = client.Create(request);

            Assert.NotNull(preapproval);
            Assert.NotNull(preapproval.Id);
        }

        [Fact]
        public async Task UpdateAsync_Success()
        {
            PreapprovalCreateRequest request = BuildCreateRequest();
            Preapproval createdPreapproval = await client.CreateAsync(request);

            await Task.Delay(1000);

            PreapprovalUpdateRequest updateRequest = BuildUpdateRequest();
            Preapproval preapproval =
                await client.UpdateAsync(createdPreapproval.Id, updateRequest);

            Assert.NotNull(preapproval);
            Assert.Equal(updateRequest.ExternalReference, preapproval.ExternalReference);
        }

        [Fact]
        public void Update_Success()
        {
            PreapprovalCreateRequest request = BuildCreateRequest();
            Preapproval createdPreapproval = client.Create(request);

            Thread.Sleep(1000);

            PreapprovalUpdateRequest updateRequest = BuildUpdateRequest();
            Preapproval preapproval =
                client.Update(createdPreapproval.Id, updateRequest);

            Assert.NotNull(preapproval);
            Assert.Equal(updateRequest.ExternalReference, preapproval.ExternalReference);
        }

        [Fact]
        public async Task GetAsync_Success()
        {
            PreapprovalCreateRequest request = BuildCreateRequest();
            Preapproval createdPreapproval = await client.CreateAsync(request);

            await Task.Delay(1000);

            Preapproval preapproval =
                await client.GetAsync(createdPreapproval.Id);

            Assert.NotNull(preapproval);
            Assert.Equal(createdPreapproval.Id, preapproval.Id);
        }

        [Fact]
        public void Get_Success()
        {
            PreapprovalCreateRequest request = BuildCreateRequest();
            Preapproval createdPreapproval = client.Create(request);

            Thread.Sleep(1000);

            Preapproval preapproval = client.Get(createdPreapproval.Id);

            Assert.NotNull(preapproval);
            Assert.Equal(createdPreapproval.Id, preapproval.Id);
        }

        [Fact]
        public async Task SearchAsync_Success()
        {
            PreapprovalCreateRequest request = BuildCreateRequest();
            Preapproval createdPreapproval = await client.CreateAsync(request);

            await Task.Delay(3000);

            var searchRequest = new SearchRequest
            {
                Limit = 1,
                Offset = 0,
                Filters = new Dictionary<string, object>
                {
                    ["id"] = createdPreapproval.Id,
                },
            };
            ResultsResourcesPage<Preapproval> results =
                await client.SearchAsync(searchRequest);

            Assert.NotNull(results);
            Assert.NotNull(results.Paging);
            Assert.Equal(1, results.Paging.Total);
            Assert.NotNull(results.Results);
            Assert.Equal(createdPreapproval.Id, results.Results.First().Id);
        }

        [Fact]
        public void Search_Success()
        {
            PreapprovalCreateRequest request = BuildCreateRequest();
            Preapproval createdPreapproval = client.Create(request);

            Thread.Sleep(3000);

            var searchRequest = new SearchRequest
            {
                Limit = 1,
                Offset = 0,
                Filters = new Dictionary<string, object>
                {
                    ["id"] = createdPreapproval.Id,
                },
            };
            ResultsResourcesPage<Preapproval> results =
                client.Search(searchRequest);

            Assert.NotNull(results);
            Assert.NotNull(results.Paging);
            Assert.Equal(1, results.Paging.Total);
            Assert.NotNull(results.Results);
            Assert.Equal(createdPreapproval.Id, results.Results.First().Id);
        }

        private PreapprovalCreateRequest BuildCreateRequest()
        {
            return new PreapprovalCreateRequest
            {
                CollectorId = User.Id,
                BackUrl = "https://backurl.com",
                ExternalReference = Guid.NewGuid().ToString(),
                PayerEmail = Environment.GetEnvironmentVariable("USER_EMAIL"),
                Reason = "New recurring",
                AutoRecurring = new PreApprovalAutoRecurringCreateRequest
                {
                    CurrencyId = CurrencyHelper.GetCurrencyId(User),
                    TransactionAmount = 100,
                    Frequency = 1,
                    FrequencyType = "months",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(3),
                },
            };
        }

        private PreapprovalUpdateRequest BuildUpdateRequest()
        {
            return new PreapprovalUpdateRequest
            {
                BackUrl = "https://new.backurl.com",
                ExternalReference = Guid.NewGuid().ToString(),
                Reason = "Updated recurring",
                AutoRecurring = new PreApprovalAutoRecurringUpdateRequest
                {
                    TransactionAmount = 50,
                    StartDate = DateTime.Now.AddMonths(6),
                    EndDate = DateTime.Now.AddYears(5),
                },
            };
        }
    }
}
