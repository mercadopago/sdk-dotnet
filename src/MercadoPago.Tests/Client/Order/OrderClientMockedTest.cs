using System.Collections.Generic;
using System.Net.Http; using HttpMethodNet = System.Net.Http.HttpMethod;
using MercadoPago.Client.Order;
using MercadoPago.Config;
using MercadoPago.Http;
using MercadoPago.Resource.Order;
using MercadoPago.Serialization;
using MercadoPago.Tests.Http;
using Xunit;

namespace MercadoPago.Tests.Client.Order
{
    public class OrderClientMockedTest
    {
        [Fact]
        public void Create_WithBoletoAndAdditionalInfo_PureMock_Success()
        {
            // Arrange
            var httpMock = new HttpClientMock();
            var serializer = new DefaultSerializer();
            var httpClient = new DefaultHttpClient(httpMock.HttpClient);
            var client = new OrderClient(httpClient, serializer);

            var createUrl = $"{MercadoPagoConfig.BaseUrl}/v1/orders";
            var httpResponse = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent("{\"id\":\"ord_123\",\"status\":\"processed\"}")
            };
            httpMock.MockRequest(createUrl, HttpMethodNet.Post, httpResponse);

            var request = new OrderCreateRequest
            {
                Type = "online",
                TotalAmount = "1000.00",
                ExternalReference = "ext_ref_1234",
                CaptureMode = "automatic_async",
                Transactions = new OrderTransactionRequest
                {
                    Payments = new List<OrderPaymentRequest>
                    {
                        new OrderPaymentRequest
                        {
                            Amount = "1000.00",
                            PaymentMethod = new OrderPaymentMethodRequest { Id = "boleto", Type = "ticket" }
                        }
                    }
                },
                Payer = new OrderPayerRequest { Email = "test_user@example.com" },
                AdditionalInfo = new Dictionary<string, object>
                {
                    ["payer"] = new Dictionary<string, object> { ["authentication_type"] = "senha" },
                    ["shipment"] = new Dictionary<string, object> { ["express"] = true }
                }
            };

            // Act
            MercadoPago.Resource.Order.Order order = client.Create(request);

            // Assert
            Assert.NotNull(order);
            Assert.Equal("ord_123", order.Id);
            httpMock.VerifySended(HttpMethodNet.Post, new System.Uri(createUrl), Moq.Times.Once());
        }
    }
} 