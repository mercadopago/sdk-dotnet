using System;
using System.Globalization;
using System.IO;
using MercadoPago.Serialization;
using MercadoPago.Tests.Serialization;
using Xunit;
using MercadoPago.Resource.Payment;

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
        public void Deserialize_PaymentThreeDSInfoFromJson_Success()
        {
            string json = File.ReadAllText("Client/Mock/CardPaymentWith3dsResponse.json");
            var payment = serializer.DeserializeFromJson<MercadoPago.Resource.Payment.Payment>(json);

            Assert.Equal("https://acs-public.tp.mastercard.com/api/v1/browser_challenges", payment.ThreeDsinfo.ExternalResourceUrl);
            Assert.Equal("eyJ0aHJlZURTU2VydmVyVHJhbnNJRCI6ImE4NDQ1NTE2LThjNzktNGQ1NC04MjRmLTU5YzgzNDRiY2FjNCIsImFj", payment.ThreeDsinfo.Creq);
        }

    }
}

