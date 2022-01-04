namespace MercadoPago.Tests.Client.CardToken
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Client.CardToken;
    using MercadoPago.Client.Customer;
    using MercadoPago.Config;
    using MercadoPago.Http;
    using MercadoPago.Resource.CardToken;
    using MercadoPago.Resource.Customer;
    using MercadoPago.Serialization;
    using MercadoPago.Tests.Client.Helper;
    using Xunit;

    [Collection("Uses User Email")]
    public class CardTokenClientTest : BaseClientTest
    {
        private readonly CardTokenClient client;
        private readonly CardTokenTestClient cardTokenTestClient;

        public CardTokenClientTest(ClientFixture clientFixture)
            : base(clientFixture)
        {
            client = new CardTokenClient();
            cardTokenTestClient = new CardTokenTestClient();
        }

        [Fact]
        public void Constructor_HttpClientAndSerializer_Success()
        {
            var httpClient = new DefaultHttpClient();
            var serializer = new DefaultSerializer();
            var client = new CardTokenClient(httpClient, serializer);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_HttpClient_Success()
        {
            var httpClient = new DefaultHttpClient();
            var client = new CardTokenClient(httpClient);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_Serializer_Success()
        {
            var serializer = new DefaultSerializer();
            var client = new CardTokenClient(serializer);

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_NullParameters_Success()
        {
            var client = new CardTokenClient();

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task CreateAsync_Success()
        {
            CustomerRequest customerRequest = BuildCustomerCreateRequest();
            var customerClient = new CustomerClient();
            Customer customer = await customerClient.CreateAsync(customerRequest);

            await Task.Delay(1000);

            try
            {
                CustomerCardCreateRequest cardRequest = await BuildCardCreateRequestAsync();
                CustomerCard card = await customerClient.CreateCardAsync(customer.Id, cardRequest);

                var request = new CardTokenRequest
                {
                    CustomerId = customer.Id,
                    CardId = card.Id,
                    SecurityCode = "123",
                };
                CardToken cardToken = await client.CreateAsync(request);

                Assert.NotNull(cardToken);
                Assert.NotNull(cardToken.Id);
            }
            finally
            {
                customerClient.Delete(customer.Id);
            }
        }

        [Fact(Skip = "Not running in CI.")]
        public void Create_Success()
        {
            CustomerRequest customerRequest = BuildCustomerCreateRequest();
            var customerClient = new CustomerClient();
            Customer customer = customerClient.Create(customerRequest);

            Thread.Sleep(1000);

            try
            {
                CustomerCardCreateRequest cardRequest = BuildCardCreateRequest();
                CustomerCard card = customerClient.CreateCard(customer.Id, cardRequest);

                var request = new CardTokenRequest
                {
                    CustomerId = customer.Id,
                    CardId = card.Id,
                    SecurityCode = "123",
                };
                CardToken cardToken = client.Create(request);

                Assert.NotNull(cardToken);
                Assert.NotNull(cardToken.Id);
            }
            finally
            {
                customerClient.Delete(customer.Id);
            }
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task GetAsync_Success()
        {
            CustomerRequest customerRequest = BuildCustomerCreateRequest();
            var customerClient = new CustomerClient();
            Customer customer = await customerClient.CreateAsync(customerRequest);

            await Task.Delay(1000);

            try
            {
                CustomerCardCreateRequest cardRequest = await BuildCardCreateRequestAsync();
                CustomerCard card = await customerClient.CreateCardAsync(customer.Id, cardRequest);

                var request = new CardTokenRequest
                {
                    CustomerId = customer.Id,
                    CardId = card.Id,
                    SecurityCode = "123",
                };
                CardToken createdCartToken = await client.CreateAsync(request);

                await Task.Delay(1000);

                CardToken cardToken = await client.GetAsync(createdCartToken.Id);

                Assert.NotNull(cardToken);
                Assert.Equal(createdCartToken.Id, cardToken.Id);
            }
            finally
            {
                customerClient.Delete(customer.Id);
            }
        }

        [Fact(Skip = "Not running in CI.")]
        public void Get_Success()
        {
            CustomerRequest customerRequest = BuildCustomerCreateRequest();
            var customerClient = new CustomerClient();
            Customer customer = customerClient.Create(customerRequest);

            Thread.Sleep(1000);

            try
            {
                CustomerCardCreateRequest cardRequest = BuildCardCreateRequest();
                CustomerCard card = customerClient.CreateCard(customer.Id, cardRequest);

                var request = new CardTokenRequest
                {
                    CustomerId = customer.Id,
                    CardId = card.Id,
                    SecurityCode = "123",
                };
                CardToken createdCartToken = client.Create(request);

                Thread.Sleep(1000);

                CardToken cardToken = client.Get(createdCartToken.Id);

                Assert.NotNull(cardToken);
                Assert.Equal(createdCartToken.Id, cardToken.Id);
            }
            finally
            {
                customerClient.Delete(customer.Id);
            }
        }

        private CustomerRequest BuildCustomerCreateRequest()
        {
            return new CustomerRequest
            {
                FirstName = "Test",
                LastName = "Payer",
                Email = Environment.GetEnvironmentVariable("USER_EMAIL"),
                Identification = IdentificationHelper.GetIdentification(User),
            };
        }

        private async Task<CustomerCardCreateRequest> BuildCardCreateRequestAsync()
        {
            CardToken cardToken =
                await cardTokenTestClient.CreateTestCardToken(User, "approved");

            return new CustomerCardCreateRequest
            {
                Token = cardToken.Id,
            };
        }

        private CustomerCardCreateRequest BuildCardCreateRequest()
        {
            CardToken cardToken = cardTokenTestClient.CreateTestCardToken(User, "approved")
                .ConfigureAwait(false).GetAwaiter().GetResult();

            return new CustomerCardCreateRequest
            {
                Token = cardToken.Id,
            };
        }
    }
}
