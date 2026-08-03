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
    }
}
