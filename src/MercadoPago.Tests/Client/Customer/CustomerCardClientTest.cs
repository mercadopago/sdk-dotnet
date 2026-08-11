using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MercadoPago.Client.Customer;
using MercadoPago.Http;
using MercadoPago.Resource.Customer;
using Moq;
using Xunit;

namespace MercadoPago.Tests.Client.Customer
{
    public class CustomerCardClientTest
    {
        private readonly CustomerCardClient client;
        private readonly Mock<IHttpClient> mock;

        public CustomerCardClientTest()
        {
            mock = new Mock<IHttpClient>();
            client = new CustomerCardClient(mock.Object);
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task UpdateAsync_Success()
        {
            var json = File.ReadAllText("Client/Mock/CustomerCardUpdateResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            mock.Setup(httpClient => httpClient.SendAsync(
                It.IsAny<MercadoPagoRequest>(),
                It.IsAny<IRetryStrategy>(),
                It.IsAny<CancellationToken>()).Result).Returns(response);

            var request = new CustomerCardCreateRequest { Token = "token123" };
            CustomerCard result = await client.UpdateAsync("customer456", "card123", request);

            Assert.NotNull(result);
            Assert.Equal("card123", result.Id);
            Assert.Equal("customer456", result.CustomerId);

            mock.Reset();
        }

        [Fact(Skip = "Not running in CI.")]
        public void Update_Success()
        {
            var json = File.ReadAllText("Client/Mock/CustomerCardUpdateResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            mock.Setup(httpClient => httpClient.SendAsync(
                It.IsAny<MercadoPagoRequest>(),
                It.IsAny<IRetryStrategy>(),
                It.IsAny<CancellationToken>()).Result).Returns(response);

            var request = new CustomerCardCreateRequest { Token = "token123" };
            CustomerCard result = client.Update("customer456", "card123", request);

            Assert.NotNull(result);
            Assert.Equal("card123", result.Id);
            Assert.Equal("customer456", result.CustomerId);

            mock.Reset();
        }

        [Fact]
        public async Task GetAsync_Success()
        {
            var json = File.ReadAllText("Client/Mock/CustomerCardGetResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            mock.Setup(httpClient => httpClient.SendAsync(
                It.IsAny<MercadoPagoRequest>(),
                It.IsAny<IRetryStrategy>(),
                It.IsAny<CancellationToken>()).Result).Returns(response);

            CustomerCard result = await client.GetAsync("customer456", "card123");

            Assert.NotNull(result);
            Assert.Equal("card123", result.Id);
            Assert.Equal("customer456", result.CustomerId);

            mock.Reset();
        }

        [Fact]
        public void Get_Success()
        {
            var json = File.ReadAllText("Client/Mock/CustomerCardGetResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            mock.Setup(httpClient => httpClient.SendAsync(
                It.IsAny<MercadoPagoRequest>(),
                It.IsAny<IRetryStrategy>(),
                It.IsAny<CancellationToken>()).Result).Returns(response);

            CustomerCard result = client.Get("customer456", "card123");

            Assert.NotNull(result);
            Assert.Equal("card123", result.Id);

            mock.Reset();
        }

        [Fact]
        public async Task CreateAsync_Success()
        {
            var json = File.ReadAllText("Client/Mock/CustomerCardCreateResponse.json");
            var response = new MercadoPagoResponse(201, null, json);
            mock.Setup(httpClient => httpClient.SendAsync(
                It.IsAny<MercadoPagoRequest>(),
                It.IsAny<IRetryStrategy>(),
                It.IsAny<CancellationToken>()).Result).Returns(response);

            var request = new CustomerCardCreateRequest { Token = "token_new_card" };
            CustomerCard result = await client.CreateAsync("customer456", request);

            Assert.NotNull(result);
            Assert.Equal("card999", result.Id);
            Assert.Equal("customer456", result.CustomerId);

            mock.Reset();
        }

        [Fact]
        public void Create_Success()
        {
            var json = File.ReadAllText("Client/Mock/CustomerCardCreateResponse.json");
            var response = new MercadoPagoResponse(201, null, json);
            mock.Setup(httpClient => httpClient.SendAsync(
                It.IsAny<MercadoPagoRequest>(),
                It.IsAny<IRetryStrategy>(),
                It.IsAny<CancellationToken>()).Result).Returns(response);

            var request = new CustomerCardCreateRequest { Token = "token_new_card" };
            CustomerCard result = client.Create("customer456", request);

            Assert.NotNull(result);
            Assert.Equal("card999", result.Id);

            mock.Reset();
        }

        [Fact]
        public async Task DeleteAsync_Success()
        {
            var json = File.ReadAllText("Client/Mock/CustomerCardDeleteResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            mock.Setup(httpClient => httpClient.SendAsync(
                It.IsAny<MercadoPagoRequest>(),
                It.IsAny<IRetryStrategy>(),
                It.IsAny<CancellationToken>()).Result).Returns(response);

            CustomerCard result = await client.DeleteAsync("customer456", "card123");

            Assert.NotNull(result);
            Assert.Equal("card123", result.Id);

            mock.Reset();
        }

        [Fact]
        public void Delete_Success()
        {
            var json = File.ReadAllText("Client/Mock/CustomerCardDeleteResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            mock.Setup(httpClient => httpClient.SendAsync(
                It.IsAny<MercadoPagoRequest>(),
                It.IsAny<IRetryStrategy>(),
                It.IsAny<CancellationToken>()).Result).Returns(response);

            CustomerCard result = client.Delete("customer456", "card123");

            Assert.NotNull(result);
            Assert.Equal("card123", result.Id);

            mock.Reset();
        }

        [Fact]
        public async Task ListAsync_Success()
        {
            var json = File.ReadAllText("Client/Mock/CustomerCardListResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            mock.Setup(httpClient => httpClient.SendAsync(
                It.IsAny<MercadoPagoRequest>(),
                It.IsAny<IRetryStrategy>(),
                It.IsAny<CancellationToken>()).Result).Returns(response);

            var result = await client.ListAsync("customer456");

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("card123", result[0].Id);

            mock.Reset();
        }

        [Fact]
        public void List_Success()
        {
            var json = File.ReadAllText("Client/Mock/CustomerCardListResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            mock.Setup(httpClient => httpClient.SendAsync(
                It.IsAny<MercadoPagoRequest>(),
                It.IsAny<IRetryStrategy>(),
                It.IsAny<CancellationToken>()).Result).Returns(response);

            var result = client.List("customer456");

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);

            mock.Reset();
        }
    }
}
