using System.IO;
using System.Text.Json;
using MercadoPago.Client.Customer;
using MercadoPago.Client.Payment;
using MercadoPago.Serialization;
using Xunit;

namespace MercadoPago.Tests.Client.Payment
{

    public class PaymentSerializationTest
    {
        private readonly ISerializer serializer;

        public PaymentSerializationTest()
        {
            serializer = new DefaultSerializer();
        }

        [Fact(Skip = "Not running in CI.")]
        public void Serialize_PaymentCreateRequestThreeDSecureModeFromJson_Success()
        {
            var json = File.ReadAllText("Client/Mock/CardPaymentWith3dsRequest.json");
            var paymentCreateRequest = serializer.DeserializeFromJson<PaymentCreateRequest>(json);

            Assert.Equal("optional", paymentCreateRequest.ThreeDSecureMode);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Deserialize_PaymentThreeDSInfoFromJson_Success()
        {
            var json = File.ReadAllText("Client/Mock/CardPaymentWith3dsResponse.json");
            var payment = serializer.DeserializeFromJson<MercadoPago.Resource.Payment.Payment>(json);

            Assert.Equal("https://acs-public.tp.mastercard.com/api/v1/browser_challenges", payment.ThreeDSInfo.ExternalResourceUrl);
            Assert.Equal("eyJ0aHJlZURTU2VydmVyVHJhbnNJRCI6ImE4NDQ1NTE2LThjNzktNGQ1NC04MjRmLTU5YzgzNDRiY2FjNCIsImFj", payment.ThreeDSInfo.Creq);
        }

        [Fact]
        public void Serialize_NetworkDataInsideTransactionData_Success()
        {
            var request = new PaymentCreateRequest
            {
                PointOfInteraction = new PaymentPointOfInteractionRequest
                {
                    TransactionData = new PaymentTransactionDataRequest
                    {
                        NetworkTransactionId = "network-transaction-id",
                        NetworkData = new PaymentNetworkDataRequest
                        {
                            TransactionId = "VISA-TID-ABC123",
                            TransactionLinkId = "550e8400-e29b-41d4-a716-446655440000",
                        },
                    },
                },
            };

            using var document = JsonDocument.Parse(serializer.SerializeToJson(request));
            var transactionData = document.RootElement
                .GetProperty("point_of_interaction")
                .GetProperty("transaction_data");
            var networkData = transactionData.GetProperty("network_data");

            Assert.Equal("network-transaction-id", transactionData.GetProperty("network_transaction_id").GetString());
            Assert.Equal("VISA-TID-ABC123", networkData.GetProperty("transaction_id").GetString());
            Assert.Equal("550e8400-e29b-41d4-a716-446655440000", networkData.GetProperty("transaction_link_id").GetString());
            Assert.False(document.RootElement.GetProperty("point_of_interaction").TryGetProperty("network_data", out _));
        }

        [Fact]
        public void Deserialize_NetworkDataInsideTransactionData_Success()
        {
            var payment = serializer.DeserializeFromJson<MercadoPago.Resource.Payment.Payment>(
                "{\"point_of_interaction\":{\"transaction_data\":{\"network_data\":{\"transaction_id\":\"VISA-TID-ABC123\",\"transaction_link_id\":\"550e8400-e29b-41d4-a716-446655440000\"}}}}");

            Assert.Equal("VISA-TID-ABC123", payment.PointOfInteraction.TransactionData.NetworkData.TransactionId);
            Assert.Equal("550e8400-e29b-41d4-a716-446655440000", payment.PointOfInteraction.TransactionData.NetworkData.TransactionLinkId);
        }

        [Fact]
        public void Deserialize_ExpandedGatewayReferenceNetworkData_Success()
        {
            var payment = serializer.DeserializeFromJson<MercadoPago.Resource.Payment.Payment>(
                "{\"expanded\":{\"gateway\":{\"reference\":{\"network_data\":{\"transaction_id\":\"ABC123\",\"transaction_link_id\":\"550e8400\"}}}}}");

            Assert.Equal("ABC123", payment.Expanded.Gateway.Reference.NetworkData.TransactionId);
            Assert.Equal("550e8400", payment.Expanded.Gateway.Reference.NetworkData.TransactionLinkId);
        }

        [Fact]
        public void Serialize_CustomerCardIssuerAndPaymentMethod_Success()
        {
            var json = serializer.SerializeToJson(new CustomerCardCreateRequest
            {
                Token = "token",
                IssuerId = "123",
                PaymentMethodId = "visa",
            });

            Assert.Contains("\"issuer_id\":\"123\"", json);
            Assert.Contains("\"payment_method_id\":\"visa\"", json);
        }

    }
}
