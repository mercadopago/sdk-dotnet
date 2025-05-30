namespace MercadoPago.Tests.Client.Chargeback
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Client;
    using MercadoPago.Client.Chargeback;
    using MercadoPago.Config;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.Chargeback;
    using MercadoPago.Serialization;
    using Moq;
    using Xunit;

    public class ChargebackClientTest : BaseClientTest
    {
        private readonly ChargebackClient client;
        private readonly Mock<IHttpClient> httpClientMock;
        private readonly Mock<ISerializer> serializerMock;

        public ChargebackClientTest(ClientFixture clientFixture)
            : base(clientFixture)
        {
            httpClientMock = new Mock<IHttpClient>();
            serializerMock = new Mock<ISerializer>();
            client = new ChargebackClient(httpClientMock.Object, serializerMock.Object);
        }

        [Fact]
        public void Constructor_HttpClientAndSerializer_Success()
        {
            var httpClient = new DefaultHttpClient();
            var serializer = new DefaultSerializer();
            var client = new ChargebackClient(httpClient, serializer);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_HttpClient_Success()
        {
            var httpClient = new DefaultHttpClient();
            var client = new ChargebackClient(httpClient);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_Serializer_Success()
        {
            var serializer = new DefaultSerializer();
            var client = new ChargebackClient(serializer);

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_NullParameters_Success()
        {
            var client = new ChargebackClient();

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public async Task GetAsync_Success()
        {
            // Arrange
            string chargebackId = "test_chargeback_id";
            var expectedChargeback = new Chargeback
            {
                Id = chargebackId,
                PaymentId = 12345,
                Amount = 100.50m,
                CurrencyId = "BRL",
                DateCreated = DateTime.Now.AddDays(-1),
                DateLastUpdated = DateTime.Now,
                Status = "pending",
                Reason = "fraud"
            };

            SetupHttpClientMockForGet(chargebackId, expectedChargeback);

            // Act
            var result = await client.GetAsync(chargebackId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(chargebackId, result.Id);
            Assert.Equal(expectedChargeback.PaymentId, result.PaymentId);
            Assert.Equal(expectedChargeback.Amount, result.Amount);
            Assert.Equal(expectedChargeback.CurrencyId, result.CurrencyId);
            Assert.Equal(expectedChargeback.Status, result.Status);
            Assert.Equal(expectedChargeback.Reason, result.Reason);
        }

        [Fact]
        public void Get_Success()
        {
            // Arrange
            string chargebackId = "test_chargeback_id";
            var expectedChargeback = new Chargeback
            {
                Id = chargebackId,
                PaymentId = 12345,
                Amount = 100.50m,
                CurrencyId = "BRL",
                DateCreated = DateTime.Now.AddDays(-1),
                DateLastUpdated = DateTime.Now,
                Status = "pending",
                Reason = "fraud"
            };

            SetupHttpClientMockForGet(chargebackId, expectedChargeback);

            // Act
            var result = client.Get(chargebackId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(chargebackId, result.Id);
            Assert.Equal(expectedChargeback.PaymentId, result.PaymentId);
            Assert.Equal(expectedChargeback.Amount, result.Amount);
            Assert.Equal(expectedChargeback.CurrencyId, result.CurrencyId);
            Assert.Equal(expectedChargeback.Status, result.Status);
            Assert.Equal(expectedChargeback.Reason, result.Reason);
        }

        [Fact]
        public async Task SearchAsync_Success()
        {
            // Arrange
            var searchRequest = new SearchRequest
            {
                Limit = 10,
                Offset = 0,
                Filters = new Dictionary<string, object>
                {
                    ["payment_id"] = "12345"
                }
            };

            var expectedResults = new ResultsResourcesPage<Chargeback>
            {
                Paging = new ResultsPaging
                {
                    Total = 1,
                    Limit = 10,
                    Offset = 0
                },
                Results = new List<Chargeback>
                {
                    new Chargeback
                    {
                        Id = "test_chargeback_id",
                        PaymentId = 12345,
                        Amount = 100.50m,
                        CurrencyId = "BRL",
                        DateCreated = DateTime.Now.AddDays(-1),
                        DateLastUpdated = DateTime.Now,
                        Status = "pending",
                        Reason = "fraud"
                    }
                }
            };

            SetupHttpClientMockForSearch(searchRequest, expectedResults);

            // Act
            var result = await client.SearchAsync(searchRequest);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Paging);
            Assert.Equal(1, result.Paging.Total);
            Assert.NotNull(result.Results);
            Assert.Single(result.Results);
            Assert.Equal("test_chargeback_id", result.Results[0].Id);
            Assert.Equal(12345, result.Results[0].PaymentId);
        }

        [Fact]
        public void Search_Success()
        {
            // Arrange
            var searchRequest = new SearchRequest
            {
                Limit = 10,
                Offset = 0,
                Filters = new Dictionary<string, object>
                {
                    ["payment_id"] = "12345"
                }
            };

            var expectedResults = new ResultsResourcesPage<Chargeback>
            {
                Paging = new ResultsPaging
                {
                    Total = 1,
                    Limit = 10,
                    Offset = 0
                },
                Results = new List<Chargeback>
                {
                    new Chargeback
                    {
                        Id = "test_chargeback_id",
                        PaymentId = 12345,
                        Amount = 100.50m,
                        CurrencyId = "BRL",
                        DateCreated = DateTime.Now.AddDays(-1),
                        DateLastUpdated = DateTime.Now,
                        Status = "pending",
                        Reason = "fraud"
                    }
                }
            };

            SetupHttpClientMockForSearch(searchRequest, expectedResults);

            // Act
            var result = client.Search(searchRequest);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Paging);
            Assert.Equal(1, result.Paging.Total);
            Assert.NotNull(result.Results);
            Assert.Single(result.Results);
            Assert.Equal("test_chargeback_id", result.Results[0].Id);
            Assert.Equal(12345, result.Results[0].PaymentId);
        }

        private void SetupHttpClientMockForGet(string chargebackId, Chargeback expectedChargeback)
        {
            var response = new MercadoPagoResponse(200, new Dictionary<string, string>(), "");
            httpClientMock
                .Setup(client => client.SendAsync(
                    It.Is<MercadoPagoRequest>(req =>
                        req.Url.Contains($"/v1/chargebacks/{chargebackId}") &&
                        req.Method == HttpMethod.GET),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            serializerMock
                .Setup(serializer => serializer.DeserializeFromJson<Chargeback>(It.IsAny<string>()))
                .Returns(expectedChargeback);
        }

        private void SetupHttpClientMockForSearch(SearchRequest searchRequest, ResultsResourcesPage<Chargeback> expectedResults)
        {
            var response = new MercadoPagoResponse(200, new Dictionary<string, string>(), "");
            httpClientMock
                .Setup(client => client.SendAsync(
                    It.Is<MercadoPagoRequest>(req =>
                        req.Url.Contains("/v1/chargebacks/search") &&
                        req.Method == HttpMethod.GET),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            serializerMock
                .Setup(serializer => serializer.DeserializeFromJson<ResultsResourcesPage<Chargeback>>(It.IsAny<string>()))
                .Returns(expectedResults);
        }
    }
}
