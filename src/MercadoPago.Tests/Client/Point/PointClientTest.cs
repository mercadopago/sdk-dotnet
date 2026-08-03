namespace MercadoPago.Tests.Client.Point
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Client.Point;
    using MercadoPago.Http;
    using MercadoPago.Serialization;
    using MercadoPago.Tests.Client;
    using Moq;
    using Xunit;

    public class PointClientTest : BaseClientTest
    {
        private readonly PointClient client;

        public PointClientTest(ClientFixture clientFixture)
            : base(clientFixture)
        {
            client = new PointClient();
        }

        [Fact]
        public void Constructor_HttpClientAndSerializer_Success()
        {
            var httpClient = new DefaultHttpClient();
            var serializer = new DefaultSerializer();
            var c = new PointClient(httpClient, serializer);

            Assert.Equal(httpClient, c.HttpClient);
            Assert.Equal(serializer, c.Serializer);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Constructor_HttpClient_Success()
        {
            var httpClient = new DefaultHttpClient();
            var c = new PointClient(httpClient);
            Assert.Equal(httpClient, c.HttpClient);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Constructor_Serializer_Success()
        {
            var serializer = new DefaultSerializer();
            var c = new PointClient(serializer);
            Assert.Equal(serializer, c.Serializer);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Constructor_NullParameters_Success()
        {
            var c = new PointClient();
            Assert.NotNull(c);
        }

        [Fact(Skip = "Not running in CI.")]
        public async void CreateAsync_Success()
        {
            var request = new PointCreatePaymentIntentRequest
            {
                Amount = 100m,
                Description = "Test purchase",
                Payment = new PointPaymentRequest { Installments = 1, Type = "credit_card" }
            };
            var intent = await client.CreateAsync("DEVICE_ID", request);
            Assert.NotNull(intent);
            Assert.NotNull(intent.Id);
        }

        [Fact]
        public async Task GetDevicesAsync_Success()
        {
            var json = File.ReadAllText("Client/Mock/PointDevicesResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var pointClient = new PointClient(mock.Object);
            var result = await pointClient.GetDevicesAsync();

            Assert.NotNull(result);
            Assert.NotNull(result.Devices);
            Assert.NotEmpty(result.Devices);
            Assert.Equal("PAX_A910__SMARTPOS123456", result.Devices[0].Id);
            Assert.Equal("PDV", result.Devices[0].OperatingMode);
        }

        [Fact]
        public void GetDevices_Success()
        {
            var json = File.ReadAllText("Client/Mock/PointDevicesResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var pointClient = new PointClient(mock.Object);
            var result = pointClient.GetDevices();

            Assert.NotNull(result);
            Assert.NotNull(result.Devices);
            Assert.NotEmpty(result.Devices);
            Assert.Equal("PAX_A910__SMARTPOS123456", result.Devices[0].Id);
        }

        [Fact]
        public async Task ChangeDeviceOperatingModeAsync_Success()
        {
            var json = File.ReadAllText("Client/Mock/PointDeviceOperatingModeResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var pointClient = new PointClient(mock.Object);
            var request = new PointDeviceOperatingModeRequest { OperatingMode = "STANDALONE" };
            var result = await pointClient.ChangeDeviceOperatingModeAsync("PAX_A910__SMARTPOS123456", request);

            Assert.NotNull(result);
            Assert.Equal("STANDALONE", result.OperatingMode);
        }

        [Fact]
        public void ChangeDeviceOperatingMode_Success()
        {
            var json = File.ReadAllText("Client/Mock/PointDeviceOperatingModeResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var pointClient = new PointClient(mock.Object);
            var request = new PointDeviceOperatingModeRequest { OperatingMode = "STANDALONE" };
            var result = pointClient.ChangeDeviceOperatingMode("PAX_A910__SMARTPOS123456", request);

            Assert.NotNull(result);
            Assert.Equal("STANDALONE", result.OperatingMode);
        }

        [Fact]
        public async Task GetPaymentIntentListAsync_Success()
        {
            var json = File.ReadAllText("Client/Mock/PointPaymentIntentListResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var pointClient = new PointClient(mock.Object);
            var request = new PointPaymentIntentListRequest
            {
                StartDate = "2023-01-01T00:00:00Z",
                EndDate = "2023-01-31T23:59:59Z"
            };
            var result = await pointClient.GetPaymentIntentListAsync(request);

            Assert.NotNull(result);
            Assert.NotNull(result.Events);
            Assert.NotEmpty(result.Events);
            Assert.Equal("7f25f9aa-eaea-4b1a-b5e7-a8a1a7988d73", result.Events[0].PaymentIntentId);
            Assert.Equal("FINISHED", result.Events[0].Status);
        }

        [Fact]
        public void GetPaymentIntentList_Success()
        {
            var json = File.ReadAllText("Client/Mock/PointPaymentIntentListResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var pointClient = new PointClient(mock.Object);
            var request = new PointPaymentIntentListRequest
            {
                StartDate = "2023-01-01T00:00:00Z",
                EndDate = "2023-01-31T23:59:59Z"
            };
            var result = pointClient.GetPaymentIntentList(request);

            Assert.NotNull(result);
            Assert.NotNull(result.Events);
            Assert.NotEmpty(result.Events);
        }

        [Fact]
        public async Task GetPaymentIntentStatusAsync_Success()
        {
            var json = File.ReadAllText("Client/Mock/PointPaymentIntentStatusResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var pointClient = new PointClient(mock.Object);
            var result = await pointClient.GetPaymentIntentStatusAsync("7f25f9aa-eaea-4b1a-b5e7-a8a1a7988d73");

            Assert.NotNull(result);
            Assert.Equal("7f25f9aa-eaea-4b1a-b5e7-a8a1a7988d73", result.Id);
            Assert.NotNull(result.Events);
            Assert.Equal(2, result.Events.Count);
        }

        [Fact]
        public void GetPaymentIntentStatus_Success()
        {
            var json = File.ReadAllText("Client/Mock/PointPaymentIntentStatusResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var pointClient = new PointClient(mock.Object);
            var result = pointClient.GetPaymentIntentStatus("7f25f9aa-eaea-4b1a-b5e7-a8a1a7988d73");

            Assert.NotNull(result);
            Assert.Equal("7f25f9aa-eaea-4b1a-b5e7-a8a1a7988d73", result.Id);
            Assert.NotNull(result.Events);
            Assert.Equal(2, result.Events.Count);
        }
    }
}
