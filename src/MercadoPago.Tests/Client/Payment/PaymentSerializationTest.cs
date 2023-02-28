using System.IO;
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

        [Fact]
        public void Serialize_PaymentCreateRequestThreeDSecureModeFromJson_Success()
        {
            var json = File.ReadAllText("Client/Mock/CardPaymentWith3dsRequest.json");
            var paymentCreateRequest = serializer.DeserializeFromJson<PaymentCreateRequest>(json);

            Assert.Equal("optional", paymentCreateRequest.ThreeDSecureMode);
        }

        [Fact]
        public void Deserialize_PaymentThreeDSInfoFromJson_Success()
        {
            var json = File.ReadAllText("Client/Mock/CardPaymentWith3dsResponse.json");
            var payment = serializer.DeserializeFromJson<MercadoPago.Resource.Payment.Payment>(json);

            Assert.Equal("https://acs-public.tp.mastercard.com/api/v1/browser_challenges", payment.ThreeDSInfo.ExternalResourceUrl);
            Assert.Equal("eyJ0aHJlZURTU2VydmVyVHJhbnNJRCI6ImE4NDQ1NTE2LThjNzktNGQ1NC04MjRmLTU5YzgzNDRiY2FjNCIsImFj", payment.ThreeDSInfo.Creq);
        }

    }
}

