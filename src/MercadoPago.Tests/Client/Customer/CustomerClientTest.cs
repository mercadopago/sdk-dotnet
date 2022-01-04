namespace MercadoPago.Tests.Client.Customer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Client;
    using MercadoPago.Client.Common;
    using MercadoPago.Client.Customer;
    using MercadoPago.Config;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.CardToken;
    using MercadoPago.Resource.Customer;
    using MercadoPago.Serialization;
    using MercadoPago.Tests.Client.CardToken;
    using MercadoPago.Tests.Client.Helper;
    using Xunit;

    [Collection("Uses User Email")]
    public class CustomerClientTest : BaseClientTest
    {
        private readonly CustomerClient client;
        private readonly CardTokenTestClient cardTokenClient;

        public CustomerClientTest(ClientFixture clientFixture)
            : base(clientFixture)
        {
            client = new CustomerClient();
            cardTokenClient = new CardTokenTestClient();
        }

        [Fact]
        public void Constructor_HttpClientAndSerializer_Success()
        {
            var httpClient = new DefaultHttpClient();
            var serializer = new DefaultSerializer();
            var client = new CustomerClient(httpClient, serializer);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_HttpClient_Success()
        {
            var httpClient = new DefaultHttpClient();
            var client = new CustomerClient(httpClient);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_Serializer_Success()
        {
            var serializer = new DefaultSerializer();
            var client = new CustomerClient(serializer);

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_NullParameters_Success()
        {
            var client = new CustomerClient();

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task CreateAsync_Success()
        {
            CustomerRequest request = BuildCreateRequest();

            Customer customer = await client.CreateAsync(request);

            Assert.NotNull(customer);
            Assert.NotNull(customer.Id);

            await client.DeleteAsync(customer.Id);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Create_Success()
        {
            CustomerRequest request = BuildCreateRequest();

            Customer customer = client.Create(request);

            Assert.NotNull(customer);
            Assert.NotNull(customer.Id);

            client.Delete(customer.Id);
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task UpdateAsync_Success()
        {
            CustomerRequest request = BuildCreateRequest();
            Customer createdCustomer = await client.CreateAsync(request);

            await Task.Delay(1000);

            try
            {
                var updateRequest = new CustomerRequest
                {
                    FirstName = "New name",
                };
                Customer customer =
                    await client.UpdateAsync(createdCustomer.Id, updateRequest);

                Assert.NotNull(customer);
                Assert.Equal(updateRequest.FirstName, customer.FirstName);
            }
            finally
            {
                await client.DeleteAsync(createdCustomer.Id);
            }
        }

        [Fact(Skip = "Not running in CI.")]
        public void Update_Success()
        {
            CustomerRequest request = BuildCreateRequest();
            Customer createdCustomer = client.Create(request);

            Thread.Sleep(1000);

            try
            {
                var updateRequest = new CustomerRequest
                {
                    FirstName = "New name",
                };
                Customer customer =
                    client.Update(createdCustomer.Id, updateRequest);

                Assert.NotNull(customer);
                Assert.Equal(updateRequest.FirstName, customer.FirstName);
            }
            finally
            {
                client.Delete(createdCustomer.Id);
            }
        }

        [Fact]
        public async Task GetAsync_Success()
        {
            CustomerRequest request = BuildCreateRequest();
            Customer createdCustomer = await client.CreateAsync(request);

            await Task.Delay(1000);

            try
            {
                Customer customer =
                await client.GetAsync(createdCustomer.Id);

                Assert.NotNull(customer);
                Assert.Equal(createdCustomer.Id, customer.Id);
            }
            finally
            {
                await client.DeleteAsync(createdCustomer.Id);
            }
        }

        [Fact(Skip = "Not running in CI.")]
        public void Get_Success()
        {
            CustomerRequest request = BuildCreateRequest();
            Customer createdCustomer = client.Create(request);

            Thread.Sleep(1000);

            try
            {
                Customer customer = client.Get(createdCustomer.Id);

                Assert.NotNull(customer);
                Assert.Equal(createdCustomer.Id, customer.Id);
            }
            finally
            {
                client.Delete(createdCustomer.Id);
            }
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task SearchAsync_Success()
        {
            CustomerRequest request = BuildCreateRequest();
            Customer createdCustomer = await client.CreateAsync(request);

            await Task.Delay(3000);

            try
            {
                var searchRequest = new SearchRequest
                {
                    Limit = 1,
                    Offset = 0,
                    Filters = new Dictionary<string, object>
                    {
                        ["email"] = request.Email,
                    },
                };
                ResultsResourcesPage<Customer> results =
                    await client.SearchAsync(searchRequest);

                Assert.NotNull(results);
                Assert.NotNull(results.Paging);
                Assert.Equal(1, results.Paging.Total);
                Assert.NotNull(results.Results);
                Assert.Equal(createdCustomer.Id, results.Results.First().Id);
            }
            finally
            {
                await client.DeleteAsync(createdCustomer.Id);
            }
        }

        [Fact(Skip = "Not running in CI.")]
        public void Search_Success()
        {
            CustomerRequest request = BuildCreateRequest();
            Customer createdCustomer = client.Create(request);

            Thread.Sleep(3000);

            try
            {
                var searchRequest = new SearchRequest
                {
                    Limit = 1,
                    Offset = 0,
                    Filters = new Dictionary<string, object>
                    {
                        ["email"] = request.Email,
                    },
                };
                ResultsResourcesPage<Customer> results = client.Search(searchRequest);

                Assert.NotNull(results);
                Assert.NotNull(results.Paging);
                Assert.Equal(1, results.Paging.Total);
                Assert.NotNull(results.Results);
                Assert.Equal(createdCustomer.Id, results.Results.First().Id);
            }
            finally
            {
                client.Delete(createdCustomer.Id);
            }
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task CreateCardAsync_Success()
        {
            CustomerRequest request = BuildCreateRequest();
            Customer customer = await client.CreateAsync(request);

            await Task.Delay(1000);

            try
            {
                CustomerCardCreateRequest cardRequest = await BuildCardCreateRequestAsync();
                CustomerCard card = await client.CreateCardAsync(customer.Id, cardRequest);

                Assert.NotNull(card);
                Assert.NotNull(card.Id);
            }
            finally
            {
                await client.DeleteAsync(customer.Id);
            }
        }

        [Fact(Skip = "Not running in CI.")]
        public void CreateCard_Success()
        {
            CustomerRequest request = BuildCreateRequest();
            Customer customer = client.Create(request);

            Thread.Sleep(1000);

            try
            {
                CustomerCardCreateRequest cardRequest = BuildCardCreateRequest();
                CustomerCard card = client.CreateCard(customer.Id, cardRequest);

                Assert.NotNull(card);
                Assert.NotNull(card.Id);
            }
            finally
            {
                client.Delete(customer.Id);
            }
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task GetCardAsync_Success()
        {
            CustomerRequest request = BuildCreateRequest();
            Customer customer = await client.CreateAsync(request);

            await Task.Delay(1000);

            try
            {
                CustomerCardCreateRequest cardRequest = await BuildCardCreateRequestAsync();
                CustomerCard createdCard = await client.CreateCardAsync(customer.Id, cardRequest);

                CustomerCard card = await client.GetCardAsync(customer.Id, createdCard.Id);

                Assert.NotNull(card);
                Assert.Equal(createdCard.Id, card.Id);
            }
            finally
            {
                await client.DeleteAsync(customer.Id);
            }
        }

        [Fact(Skip = "Not running in CI.")]
        public void GetCard_Success()
        {
            CustomerRequest request = BuildCreateRequest();
            Customer customer = client.Create(request);

            Thread.Sleep(1000);

            try
            {
                CustomerCardCreateRequest cardRequest = BuildCardCreateRequest();
                CustomerCard createdCard = client.CreateCard(customer.Id, cardRequest);

                CustomerCard card = client.GetCard(customer.Id, createdCard.Id);

                Assert.NotNull(card);
                Assert.Equal(createdCard.Id, card.Id);
            }
            finally
            {
                client.Delete(customer.Id);
            }
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task DeleteCardAsync_Success()
        {
            CustomerRequest request = BuildCreateRequest();
            Customer customer = await client.CreateAsync(request);

            await Task.Delay(1000);

            try
            {
                CustomerCardCreateRequest cardRequest = await BuildCardCreateRequestAsync();
                CustomerCard createdCard = await client.CreateCardAsync(customer.Id, cardRequest);

                CustomerCard card = await client.DeleteCardAsync(customer.Id, createdCard.Id);

                Assert.NotNull(card);
                Assert.Equal(createdCard.Id, card.Id);
            }
            finally
            {
                await client.DeleteAsync(customer.Id);
            }
        }

        [Fact(Skip = "Not running in CI.")]
        public void DeleteCard_Success()
        {
            CustomerRequest request = BuildCreateRequest();
            Customer customer = client.Create(request);

            Thread.Sleep(1000);

            try
            {
                CustomerCardCreateRequest cardRequest = BuildCardCreateRequest();
                CustomerCard createdCard = client.CreateCard(customer.Id, cardRequest);

                CustomerCard card = client.DeleteCard(customer.Id, createdCard.Id);

                Assert.NotNull(card);
                Assert.Equal(createdCard.Id, card.Id);
            }
            finally
            {
                client.Delete(customer.Id);
            }
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task ListCardsAsync_Success()
        {
            CustomerRequest request = BuildCreateRequest();
            Customer customer = await client.CreateAsync(request);

            await Task.Delay(1000);

            try
            {
                CustomerCardCreateRequest cardRequest = await BuildCardCreateRequestAsync();
                CustomerCard createdCard = await client.CreateCardAsync(customer.Id, cardRequest);

                ResourcesList<CustomerCard> results = await client.ListCardsAsync(customer.Id);

                Assert.NotNull(results);
                Assert.Equal(createdCard.Id, results.First().Id);
            }
            finally
            {
                await client.DeleteAsync(customer.Id);
            }
        }

        [Fact(Skip = "Not running in CI.")]
        public void ListCards_Success()
        {
            CustomerRequest request = BuildCreateRequest();
            Customer customer = client.Create(request);

            Thread.Sleep(1000);

            try
            {
                CustomerCardCreateRequest cardRequest = BuildCardCreateRequest();
                CustomerCard createdCard = client.CreateCard(customer.Id, cardRequest);

                ResourcesList<CustomerCard> results = client.ListCards(customer.Id);

                Assert.NotNull(results);
                Assert.Equal(createdCard.Id, results.First().Id);
            }
            finally
            {
                client.Delete(customer.Id);
            }
        }

        private CustomerRequest BuildCreateRequest()
        {
            return new CustomerRequest
            {
                FirstName = "Test",
                LastName = "Payer",
                Email = Environment.GetEnvironmentVariable("USER_EMAIL"),
                Phone = new PhoneRequest
                {
                    AreaCode = "03492",
                    Number = "123456",
                },
                Address = new CustomerDefaultAddressRequest
                {
                    Id = "123",
                    StreetName = "Street",
                    StreetNumber = 123,
                },
                Description = "customer description",
                Identification = IdentificationHelper.GetIdentification(User),
                Metadata = new Dictionary<string, object>
                {
                    ["key1"] = "value1",
                },
                DateRegistred = DateTime.Now.AddMonths(-6),
            };
        }

        private async Task<CustomerCardCreateRequest> BuildCardCreateRequestAsync()
        {
            CardToken cardToken =
                await cardTokenClient.CreateTestCardToken(User, "approved");

            return new CustomerCardCreateRequest
            {
                Token = cardToken.Id,
            };
        }

        private CustomerCardCreateRequest BuildCardCreateRequest()
        {
            CardToken cardToken = cardTokenClient.CreateTestCardToken(User, "approved")
                .ConfigureAwait(false).GetAwaiter().GetResult();

            return new CustomerCardCreateRequest
            {
                Token = cardToken.Id,
            };
        }
    }
}
