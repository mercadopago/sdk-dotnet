namespace MercadoPago.Tests.Client.MerchantOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Client;
    using MercadoPago.Client.MerchantOrder;
    using MercadoPago.Client.Preference;
    using MercadoPago.Config;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.MerchantOrder;
    using MercadoPago.Resource.Preference;
    using MercadoPago.Serialization;
    using Xunit;

    public class MerchantOrderClientTest : BaseClientTest
    {
        private readonly MerchantOrderClient client;

        public MerchantOrderClientTest(ClientFixture clientFixture)
            : base(clientFixture)
        {
            client = new MerchantOrderClient();
        }

        [Fact]
        public void Constructor_HttpClientAndSerializer_Success()
        {
            var httpClient = new DefaultHttpClient();
            var serializer = new DefaultSerializer();
            var client = new MerchantOrderClient(httpClient, serializer);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_HttpClient_Success()
        {
            var httpClient = new DefaultHttpClient();
            var client = new MerchantOrderClient(httpClient);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_Serializer_Success()
        {
            var serializer = new DefaultSerializer();
            var client = new MerchantOrderClient(serializer);

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_NullParameters_Success()
        {
            var client = new MerchantOrderClient();

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public async Task CreateAsync_Success()
        {
            MerchantOrderCreateRequest request = await BuildCreateRequestAsync();

            MerchantOrder merchantOrder = await client.CreateAsync(request);

            Assert.NotNull(merchantOrder);
            Assert.NotNull(merchantOrder.Id);
            Assert.Equal(request.ExternalReference, merchantOrder.ExternalReference);
        }

        [Fact]
        public void Create_Success()
        {
            MerchantOrderCreateRequest request = BuildCreateRequest();

            MerchantOrder merchantOrder = client.Create(request);

            Assert.NotNull(merchantOrder);
            Assert.NotNull(merchantOrder.Id);
            Assert.Equal(request.ExternalReference, merchantOrder.ExternalReference);
        }

        [Fact]
        public async Task UpdateAsync_Success()
        {
            MerchantOrderCreateRequest createRequest = await BuildCreateRequestAsync();
            MerchantOrder createdOrder = await client.CreateAsync(createRequest);

            await Task.Delay(1000);

            var updateRequest = new MerchantOrderUpdateRequest
            {
                AdditionalInfo = "New Additional Info",
            };
            MerchantOrder order = await client.UpdateAsync(
                createdOrder.Id.GetValueOrDefault(), updateRequest);

            Assert.NotNull(order);
            Assert.NotNull(order.Items);
            Assert.Equal(updateRequest.AdditionalInfo, order.AdditionalInfo);
        }

        [Fact]
        public void Update_Success()
        {
            MerchantOrderCreateRequest createRequest = BuildCreateRequest();
            MerchantOrder createdOrder = client.Create(createRequest);

            Thread.Sleep(1000);

            var updateRequest = new MerchantOrderUpdateRequest
            {
                AdditionalInfo = "New Additional Info",
            };
            MerchantOrder order = client.Update(
                createdOrder.Id.GetValueOrDefault(), updateRequest);

            Assert.NotNull(order);
            Assert.NotNull(order.Items);
            Assert.Equal(updateRequest.AdditionalInfo, order.AdditionalInfo);
        }

        [Fact]
        public async Task GetAsync_Success()
        {
            MerchantOrderCreateRequest createRequest = await BuildCreateRequestAsync();
            MerchantOrder createdOrder = await client.CreateAsync(createRequest);

            await Task.Delay(1000);

            MerchantOrder merchantOrder = await client.GetAsync(
                createdOrder.Id.GetValueOrDefault());

            Assert.NotNull(merchantOrder);
            Assert.Equal(createdOrder.Id, merchantOrder.Id);
        }

        [Fact]
        public void Get_Success()
        {
            MerchantOrderCreateRequest createRequest = BuildCreateRequest();
            MerchantOrder createdOrder = client.Create(createRequest);

            Thread.Sleep(1000);

            MerchantOrder merchantOrder = client.Get(createdOrder.Id.GetValueOrDefault());

            Assert.NotNull(merchantOrder);
            Assert.Equal(createdOrder.Id, merchantOrder.Id);
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task SearchAsync_Success()
        {
            MerchantOrderCreateRequest createRequest = await BuildCreateRequestAsync();
            MerchantOrder createdOrder = await client.CreateAsync(createRequest);

            await Task.Delay(3000);

            var searchRequest = new SearchRequest
            {
                Limit = 1,
                Offset = 0,
                Filters = new Dictionary<string, object>
                {
                    ["external_reference"] = createRequest.ExternalReference,
                },
            };
            ElementsResourcesPage<MerchantOrder> results = await client.SearchAsync(searchRequest);

            Assert.NotNull(results);
            Assert.Equal(1, results.Total);
            Assert.NotNull(results.Elements);
            Assert.Equal(createdOrder.Id, results.Elements.First().Id);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Search_Success()
        {
            MerchantOrderCreateRequest createRequest = BuildCreateRequest();
            MerchantOrder createdOrder = client.Create(createRequest);

            Thread.Sleep(3000);

            var searchRequest = new SearchRequest
            {
                Limit = 1,
                Offset = 0,
                Filters = new Dictionary<string, object>
                {
                    ["external_reference"] = createRequest.ExternalReference,
                },
            };
            ElementsResourcesPage<MerchantOrder> results = client.Search(searchRequest);

            Assert.NotNull(results);
            Assert.Equal(1, results.Total);
            Assert.NotNull(results.Elements);
            Assert.Equal(createdOrder.Id, results.Elements.First().Id);
        }

        private async Task<MerchantOrderCreateRequest> BuildCreateRequestAsync()
        {
            Preference preference = await CreatePreferenceAsync();

            var merchantOrder = new MerchantOrderCreateRequest
            {
                PreferenceId = preference.Id,
                Items = new List<MerchantOrderItemRequest>(),
                ApplicationId = "59441713004005",
                AdditionalInfo = "Aditional info",
                ExternalReference = Guid.NewGuid().ToString(),
                Marketplace = "NONE",
                NotificationUrl = "https://seller/notification",
                SiteId = "MLB",
            };

            foreach (var item in preference.Items)
            {
                merchantOrder.Items.Add(new MerchantOrderItemRequest
                {

                    Id = item.Id,
                    CategoryId = item.CategoryId,
                    CurrencyId = item.CurrencyId.ToString(),
                    Description = item.Description,
                    PictureUrl = item.PictureUrl,
                    Quantity = item.Quantity.GetValueOrDefault(),
                    Title = item.Title,
                    UnitPrice = item.UnitPrice,
                });
            }

            return merchantOrder;
        }

        private MerchantOrderCreateRequest BuildCreateRequest()
        {
            return BuildCreateRequestAsync()
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private Task<Preference> CreatePreferenceAsync()
        {
            var request = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                {
                    new PreferenceItemRequest
                    {
                        Description = "Description",
                        Id = "123",
                        PictureUrl = "http://product.image.png",
                        Quantity = 1,
                        Title = "Title",
                        UnitPrice = 100,
                    },
                },
            };

            var client = new PreferenceClient();
            return client.CreateAsync(request);
        }
    }
}
