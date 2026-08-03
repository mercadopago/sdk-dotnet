using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MercadoPago.Client.CardToken;
using MercadoPago.Client.Common;
using MercadoPago.Http;
using CardTokenResource = MercadoPago.Resource.CardToken.CardToken;
using Moq;
using Xunit;

namespace MercadoPago.Tests.Client.CardToken
{
    public class CardTokenClientUnitTest
    {
        private readonly CardTokenClient client;
        private readonly Mock<IHttpClient> mock;

        public CardTokenClientUnitTest()
        {
            mock = new Mock<IHttpClient>();
            client = new CardTokenClient(mock.Object);
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task CreateAsync_RawCardFields_Success()
        {
            var json = File.ReadAllText("Client/Mock/CardTokenCreateResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            mock.Setup(httpClient => httpClient.SendAsync(
                It.IsAny<MercadoPagoRequest>(),
                It.IsAny<IRetryStrategy>(),
                It.IsAny<CancellationToken>()).Result).Returns(response);

            var request = new CardTokenRequest
            {
                CardNumber = "4111111111111111",
                ExpirationMonth = 12,
                ExpirationYear = 2025,
                SecurityCode = "123",
                Cardholder = new CustomerCardCardholderRequest
                {
                    Name = "Test Cardholder",
                    Identification = new IdentificationRequest
                    {
                        Type = "CPF",
                        Number = "00000000000",
                    },
                },
            };

            CardTokenResource result = await client.CreateAsync(request);

            Assert.NotNull(result);
            Assert.NotNull(result.Id);

            mock.Reset();
        }

        [Fact(Skip = "Not running in CI.")]
        public void Create_RawCardFields_Success()
        {
            var json = File.ReadAllText("Client/Mock/CardTokenCreateResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            mock.Setup(httpClient => httpClient.SendAsync(
                It.IsAny<MercadoPagoRequest>(),
                It.IsAny<IRetryStrategy>(),
                It.IsAny<CancellationToken>()).Result).Returns(response);

            var request = new CardTokenRequest
            {
                CardNumber = "4111111111111111",
                ExpirationMonth = 12,
                ExpirationYear = 2025,
                SecurityCode = "123",
                Cardholder = new CustomerCardCardholderRequest
                {
                    Name = "Test Cardholder",
                    Identification = new IdentificationRequest
                    {
                        Type = "CPF",
                        Number = "00000000000",
                    },
                },
            };

            CardTokenResource result = client.Create(request);

            Assert.NotNull(result);
            Assert.NotNull(result.Id);

            mock.Reset();
        }
    }
}
