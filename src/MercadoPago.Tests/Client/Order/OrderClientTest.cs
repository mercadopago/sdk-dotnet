namespace MercadoPago.Tests.Client.Order
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MercadoPago.Client.Order;
    using MercadoPago.Config;
    using MercadoPago.Http;
    using MercadoPago.Resource.Order;
    using MercadoPago.Serialization;
    using MercadoPago.Resource.CardToken;
    using MercadoPago.Tests.Client.CardToken;
    using Xunit;

    public class OrderClientTest : BaseClientTest
    {
        private readonly OrderClient orderClient;

        private readonly CardTokenTestClient cardTokenClient;

        public OrderClientTest(ClientFixture clientFixture)
            : base(clientFixture)
        {
            cardTokenClient = new CardTokenTestClient();
            orderClient = new OrderClient();
        }

        [Fact]
        public void Constructor_HttpClientAndSerializer_Success()
        {
            var httpClient = new DefaultHttpClient();
            var serializer = new DefaultSerializer();
            var client = new OrderClient(httpClient, serializer);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_HttpClient_Success()
        {
            var httpClient = new DefaultHttpClient();
            var client = new OrderClient(httpClient);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_Serializer_Success()
        {
            var serializer = new DefaultSerializer();
            var client = new OrderClient(serializer);

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_NullParameters_Success()
        {
            var client = new OrderClient();

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public async Task Create_Success()
        {
            OrderCreateRequest request = await BuildRequest();
            await Task.Delay(3000);

            Order order = await orderClient.CreateAsync(request);

            Assert.NotNull(order);
            Assert.NotNull(order.Id);
            Assert.Equal("processed", order.Status);
        }

        private async Task<OrderCreateRequest> BuildRequest()
        {

            CardToken cardToken = await cardTokenClient.CreateTestCardToken(User, "approved");
            OrderCreateRequest order = new OrderCreateRequest
            {
                Type = "online",
                TotalAmount = "1000.00",
                ExternalReference = "ext_ref_1234",
                Transactions = new OrderTransactionRequest{
                    Payments = new List<OrderPaymentRequest>
                    {
                        new OrderPaymentRequest
                        {
                            Amount = "1000.00",
                            PaymentMethod = new OrderPaymentMethodRequest
                            {
                                Id = "master",
                                Type = "credit_card",
                                Token = cardToken.Id,
                                Installments = 1,
                            }
                        }    
                    }
                },
                Payer = new OrderPayerRequest
                {
                    Email = Environment.GetEnvironmentVariable("USER_EMAIL"),
                },
            };
            return order;
        }
    }
}
