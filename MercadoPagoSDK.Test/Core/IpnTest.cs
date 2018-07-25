using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoPago;
using MercadoPago.DataStructures.Payment;
using MercadoPago.Resources;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Item = MercadoPago.DataStructures.MerchantOrder.Item;

namespace MercadoPagoSDK.Test.Core
{
    [TestFixture]
    public class IpnTest
    {
        [Test]
        public void MPIPN_MustThrowNullException_BothParametersEmpty()
        {
            try
            {
                Ipn.HandleNotification(null, null);
            }
            catch (MPException ex)
            {
                Assert.AreEqual("Topic and Id can not be null in the IPN request.", ex.Message);
                return;
            }

            Assert.Fail();
        }

        [Test]
        public void MPIPN_MustThrowException_IdParameterEmpty()
        {
            try
            {
                Ipn.HandleNotification(Ipn.Payment, null);
            }
            catch (MPException ex)
            {
                Assert.AreEqual("Topic and Id can not be null in the IPN request.", ex.Message);
                return;
            }

            Assert.Fail();
        }

        [Test]
        public void MPIPN_MustThrowException_TopicParameterEmpty()
        {
            try
            {
                Ipn.HandleNotification(null, "id");
            }
            catch (MPException ex)
            {
                Assert.AreEqual("Topic and Id can not be null in the IPN request.", ex.Message);
                return;
            }

            Assert.Fail();
        }

        [Test]
        public void MPIPN_MustThrowException_BothActionsNull()
        {
            try
            {
                Ipn.HandleNotification(Ipn.Payment, "id");
            }
            catch (ArgumentNullException)
            {
                Assert.Pass();
                return;
            }

            Assert.Fail();
        }

        [Test]
        public void MPIPN_MustThrowException_InvalidPaymentId()
        {
            var paymentId = "xxxx";
            try
            {
                Ipn.HandleNotification(Ipn.Payment, paymentId, x => {});
            }
            catch (MPException ex)
            {
                Assert.AreEqual(ex.Message, $"Invalid Payment Id: {paymentId}");
                return;
            }

            Assert.Fail();
        }

        [Test]
        public void MPIPN_MustNotGetPaymentById_OnNullPaymentHandler()
        {
            SDK.CleanConfiguration();
            var paymentId = "xxxx";
            Ipn.HandleNotification(Ipn.Payment, paymentId, onPaymentReceived: null, onMerchantOrderReceived: x => { });
            // No API Call is performed, therefore test passes
        }

        [Test]
        public void MPIPN_MustNotGetMerchantOrderById_OnNullMerchantOrderHandler()
        {
            SDK.CleanConfiguration();
            var merchantOrderId = "xxxx";
            Ipn.HandleNotification(Ipn.MerchantOrder, merchantOrderId, onPaymentReceived: x => { }, onMerchantOrderReceived: null);
            // No API Call is performed, therefore test passes
        }

        [Test]
        public void MPIPN_PaymentNotification_MustBeOk()
        {
            SDK.CleanConfiguration();
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            var payment =
                new Payment
                {
                    TransactionAmount = 100m,
                    Description = "IPN Test",
                    Token = GenerateSingleUseCardToken(),
                    PaymentMethodId = "visa",
                    ExternalReference = "1234",
                    Installments = 1,
                    Payer = new Payer
                    {
                        Email = "ipn@test.com"
                    }
                };

            payment.Save();

            Ipn.HandleNotification(Ipn.Payment, payment.Id.ToString(), onMerchantOrderReceived: null, onPaymentReceived: p =>
            {
                Assert.AreEqual(p.Id, payment.Id);
                Assert.AreEqual(p.Description, payment.Description);
                Assert.AreEqual(p.TransactionAmount, payment.TransactionAmount);
                Assert.AreEqual(p.ExternalReference, payment.ExternalReference);
                Assert.Pass();
            });

            Assert.Fail();
        }

        [Test]
        [Ignore("Merchant Order Endpoint does not allow Test tokens.")]
        public void MPIPN_MerchantOrderNotification_MustBeOk()
        {
            SDK.CleanConfiguration();
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            var merchantOrder =
                new MerchantOrder
                {
                    Payer = new MercadoPago.DataStructures.MerchantOrder.Payer
                    {
                        Email = "ipn@test.com"
                    },
                    Items = new List<Item>
                    {
                        new Item
                        {
                            Description = "Test Ipn",
                            Quantity = 1,
                            UnitPrice = 10m
                        }
                    }
                };

            merchantOrder.Save();

            Ipn.HandleNotification(Ipn.MerchantOrder, merchantOrder.Id, onPaymentReceived: null, onMerchantOrderReceived: m =>
            {
                Assert.AreEqual(m.Id, merchantOrder.Id);
                Assert.AreEqual(m.Items.Count, merchantOrder.Items.Count);
                Assert.AreEqual(m.Items[0].UnitPrice, merchantOrder.Items[0].UnitPrice);
                Assert.AreEqual(m.Items[0].Description, merchantOrder.Items[0].Description);
                Assert.Pass();
            });

            Assert.Fail();
        }

        public string GenerateSingleUseCardToken()
        {
            JObject payload = JObject.Parse("{ \"card_number\": \"4544610257481730\", \"security_code\": \"122\", \"expiration_month\": \"7\", \"expiration_year\": \"2030\", \"cardholder\": { \"name\": \"Test test\", \"identification\": { \"type\": \"DNI\", \"number\": \"12345678\" } } }");
            MPRESTClient client = new MPRESTClient();
            MPAPIResponse responseCardToken = client.ExecuteRequestCore(
                HttpMethod.POST,
                "https://api.mercadopago.com/v1/card_tokens?public_key=" + Environment.GetEnvironmentVariable("PUBLIC_KEY"),
                PayloadType.JSON,
                payload,
                null,
                0,
                1);

            JObject jsonResponse = JObject.Parse(responseCardToken.StringResponse.ToString());
            List<JToken> tokens = MPCoreUtils.FindTokens(jsonResponse, "id");
            return tokens.First().ToString();
        }



    }
}
