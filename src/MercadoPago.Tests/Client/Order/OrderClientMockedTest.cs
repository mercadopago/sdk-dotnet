using System.Collections.Generic;
using System.Net.Http;
using HttpMethodNet = System.Net.Http.HttpMethod;
using MercadoPago.Client.Order;
using MercadoPago.Config;
using MercadoPago.Http;
using MercadoPago.Resource.Order;
using MercadoPago.Serialization;
using MercadoPago.Tests.Http;
using Newtonsoft.Json.Linq;
using Xunit;

namespace MercadoPago.Tests.Client.Order
{
    public class OrderClientMockedTest
    {
        [Fact]
        public void Serialize_CheckoutProOrderRequest_Success()
        {
            var serializer = new DefaultSerializer();
            var request = new OrderCreateRequest
            {
                Type = "online",
                TotalAmount = "500.00",
                ExternalReference = "ext_ref_manual_full_test",
                ProcessingMode = "manual",
                CaptureMode = "automatic",
                MarketplaceFee = "5.00",
                Description = "Travel package SAO-RIO with insurance",
                ExpirationTime = "P1D",
                Payer = new OrderPayerRequest
                {
                    Email = "buyer@mercadopago.com",
                    FirstName = "John",
                    LastName = "Smith",
                    Phone = new OrderPhoneRequest
                    {
                        AreaCode = "11",
                        Number = "999998888"
                    },
                    Identification = new OrderIdentificationRequest
                    {
                        Type = "CPF",
                        Number = "12345678909"
                    },
                    Address = new OrderAddressRequest
                    {
                        ZipCode = "01310-100",
                        StreetName = "Av. Paulista",
                        StreetNumber = "1000",
                        Neighborhood = "Bela Vista",
                        City = "São Paulo"
                    }
                },
                Shipment = new OrderShipmentRequest
                {
                    Mode = "custom",
                    LocalPickup = false,
                    Cost = "15.00",
                    FreeShipping = false,
                    FreeMethods = new List<OrderFreeMethodRequest>
                    {
                        new OrderFreeMethodRequest { Id = 73328 }
                    },
                    Address = new OrderAddressRequest
                    {
                        ZipCode = "01310-100",
                        StreetName = "Av. Paulista",
                        StreetNumber = "1000",
                        Floor = "3",
                        Apartment = "B",
                        Neighborhood = "Bela Vista",
                        City = "São Paulo"
                    }
                },
                Config = new OrderConfigRequest
                {
                    StatementDescriptor = "MYSTORE",
                    DefaultPaymentDueDate = "P1D",
                    Online = new OrderOnlineConfigRequest
                    {
                        AvailableFrom = "2026-01-01T00:00:00Z",
                        AllowedUserType = "account_only",
                        SuccessUrl = "https://example.com/success",
                        FailureUrl = "https://example.com/failure",
                        PendingUrl = "https://example.com/pending",
                        AutoReturn = "approved",
                        Tracks = new List<OrderTrackRequest>
                        {
                            new OrderTrackRequest
                            {
                                Type = "google_ad",
                                Values = new Dictionary<string, string>
                                {
                                    ["conversion_id"] = "21312312312123",
                                    ["conversion_label"] = "TEST"
                                }
                            }
                        }
                    },
                    PaymentMethod = new OrderPaymentMethodConfigRequest
                    {
                        MaxInstallments = 12,
                        NotAllowedIds = new List<string> { "amex" },
                        NotAllowedTypes = new List<string> { "ticket" },
                        Installments = new OrderInstallmentsRequest
                        {
                            InterestFree = new OrderInstallmentsInterestFreeRequest
                            {
                                Type = "range",
                                Values = new List<int> { 2, 6 }
                            }
                        }
                    }
                },
                Items = new List<OrderItemsRequest>
                {
                    new OrderItemsRequest
                    {
                        ExternalCode = "ITEM-001",
                        Title = "Flight SAO-RIO",
                        Description = "Round trip, economy class",
                        CategoryId = "travels",
                        PictureUrl = "https://example.com/img.jpg",
                        Quantity = 1,
                        UnitPrice = "450.00",
                        Type = "travel",
                        EventDate = "2027-01-15T00:00:00.000-03:00"
                    }
                },
                AdditionalInfo = new Dictionary<string, object>
                {
                    ["payer.registration_date"] = "2020-01-15T00:00:00.000-03:00",
                    ["payer.is_prime_user"] = true
                }
            };

            JObject json = JObject.Parse(serializer.SerializeToJson(request));

            Assert.Equal("online", (string)json["type"]);
            Assert.Equal("manual", (string)json["processing_mode"]);
            Assert.Equal("automatic", (string)json["capture_mode"]);
            Assert.Equal("MYSTORE", (string)json["config"]["statement_descriptor"]);
            Assert.Equal("account_only", (string)json["config"]["online"]["allowed_user_type"]);
            Assert.Equal("approved", (string)json["config"]["online"]["auto_return"]);
            Assert.Equal("21312312312123", (string)json["config"]["online"]["tracks"][0]["values"]["conversion_id"]);
            Assert.Equal(12, (int)json["config"]["payment_method"]["max_installments"]);
            Assert.Equal("range", (string)json["config"]["payment_method"]["installments"]["interest_free"]["type"]);
            Assert.Equal("custom", (string)json["shipment"]["mode"]);
            Assert.Equal(73328, (int)json["shipment"]["free_methods"][0]["id"]);
            Assert.Equal("B", (string)json["shipment"]["address"]["apartment"]);
            Assert.True((bool)json["additional_info"]["payer.is_prime_user"]);
            var eventDateString = (string)json["items"][0]["event_date"];
            var eventDate = System.DateTime.Parse(eventDateString);
            Assert.Equal(new System.DateTime(2027, 1, 15, 0, 0, 0), eventDate.Date);
        }

        [Fact]
        public void Deserialize_CheckoutProOrderResponse_Success()
        {
            var serializer = new DefaultSerializer();
            const string response = @"{
                ""id"": ""ORDTST01KS5AJ6HTK2HRQ3XJ3C2JCKP9"",
                ""type"": ""online"",
                ""processing_mode"": ""manual"",
                ""external_reference"": ""parity-PREF-PM-01"",
                ""marketplace_fee"": ""10.00"",
                ""total_amount"": ""100.00"",
                ""checkout_url"": ""https://www.mercadopago.cl/checkout/v1/redirect?order_id=ORDTST01KS5AJ6HTK2HRQ3XJ3C2JCKP9"",
                ""expiration_time"": ""P1D"",
                ""country_code"": ""ARG"",
                ""user_id"": ""1858095454"",
                ""status"": ""created"",
                ""capture_mode"": ""automatic_async"",
                ""client_token"": ""eyJhbGciOiJSUzI1NiIs"",
                ""currency"": ""ARS"",
                ""created_date"": ""2026-05-21T13:10:56.845Z"",
                ""last_updated_date"": ""2026-05-21T13:10:56.845Z"",
                ""config"": {
                    ""online"": {
                        ""callback_url"": ""https://www.mercadopago.com.ar/"",
                        ""success_url"": ""https://www.mercadopago.com.ar/"",
                        ""pending_url"": ""https://www.mercadopago.com.ar/"",
                        ""failure_url"": ""https://www.mercadopago.com.ar/"",
                        ""available_from"": ""2026-05-16T18:32:00Z"",
                        ""auto_return"": ""approved"",
                        ""retries"": { ""allowed"": false }
                    },
                    ""payment_method"": {
                        ""max_installments"": 12,
                        ""not_allowed_ids"": [""amex""],
                        ""not_allowed_types"": [""ticket""],
                        ""installments"": {
                            ""interest_free"": { ""type"": ""range"", ""values"": [2, 6] }
                        }
                    }
                },
                ""shipment"": {
                    ""mode"": ""custom"",
                    ""local_pickup"": false,
                    ""cost"": ""15.00"",
                    ""free_shipping"": false,
                    ""free_methods"": [{ ""id"": 73328 }],
                    ""address"": { ""floor"": ""3"", ""apartment"": ""B"" }
                }
            }";

            MercadoPago.Resource.Order.Order order = serializer.DeserializeFromJson<MercadoPago.Resource.Order.Order>(response);

            Assert.Equal("ORDTST01KS5AJ6HTK2HRQ3XJ3C2JCKP9", order.Id);
            Assert.Equal("https://www.mercadopago.cl/checkout/v1/redirect?order_id=ORDTST01KS5AJ6HTK2HRQ3XJ3C2JCKP9", order.CheckoutUrl);
            Assert.Equal("eyJhbGciOiJSUzI1NiIs", order.ClientToken);
            Assert.Equal("approved", order.Config.Online.AutoReturn);
            Assert.False(order.Config.Online.Retries.Allowed.Value);
            Assert.Equal(12, order.Config.PaymentMethod.MaxInstallments.Value);
            Assert.Equal("amex", order.Config.PaymentMethod.NotAllowedIds[0]);
            Assert.Equal("range", order.Config.PaymentMethod.Installments.InterestFree.Type);
            Assert.Equal("custom", order.Shipment.Mode);
            Assert.Equal(73328, order.Shipment.FreeMethods[0].Id.Value);
            Assert.Equal("B", order.Shipment.Address.Apartment);
        }

        [Fact(Skip = "Not running in CI.")]
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
