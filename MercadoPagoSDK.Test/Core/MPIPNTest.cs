using MercadoPago;
using MercadoPago.Core;
using MercadoPago.Resources;
using MercadoPago.DataStructures.Payment;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK.Test.Core
{
    [TestFixture()]
    public class MPIPNTest
    {
        [Test()]
        public void MPIPN_MustThrowNullException_BothParametersEmpty()
        {
            try
            {
                MPIPN.Manage<Payment>(null, null);
            }
            catch (MPException ex)
            {
                Assert.AreEqual("Topic and Id can not be null in the IPN request.", ex.Message);
                return;
            }

            Assert.Fail();
        }

        [Test()]
        public void MPIPN_MustThrowException_IdParameterEmpty()
        {
            try
            {
                MPIPN.Manage<Payment>(MPIPN.Topic.payment, null);
            }
            catch (MPException ex)
            {
                Assert.AreEqual("Topic and Id can not be null in the IPN request.", ex.Message);
                return;
            }

            Assert.Fail();
        }

        [Test()]
        public void MPIPN_MustThrowException_TopicParameterEmpty()
        {
            try
            {
                MPIPN.Manage<Payment>(null, "id");
            }
            catch (MPException ex)
            {
                Assert.AreEqual("Topic and Id can not be null in the IPN request.", ex.Message);
                return;
            }

            Assert.Fail();
        }

        [Test()]
        public void MPIPN_MustThrowException_ClassNotExtendsFromMPBase()
        {
            try
            {
                MPIPN.Manage<Payment>("MercadoPago.DataStructures.Customer.City", "1234567");
            }
            catch (MPException ex)
            {
                Assert.AreEqual("City does not extend from MPBase", ex.Message);
                return;
            }

            Assert.Fail();
        }

        [Test()]
        public void MPIPN_ShouldBeOk()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            Payment payment = new Payment();
            Payer payer = new Payer();
            payer.email = "mlovera@kinexo.com";

            payment.transaction_amount = 100M;
            payment.token = GenerateSingleUseToken(); // 1 use card token
            payment.description = "Pago de seguro";
            payment.payment_method_id = "visa";
            payment.installments = 1;
            payment.payer = payer;

            Payment response = payment.Save();

            var resource = MPIPN.Manage<Payment>(MPIPN.Topic.payment, response.id.ToString());
            Assert.IsTrue(resource.GetType().IsSubclassOf(typeof(MPBase)));
            Assert.AreEqual(response.id, ((Payment)resource).id);   
            Assert.AreEqual(response.description, ((Payment)resource).description);
            Assert.AreEqual(response.payment_method_id, ((Payment)resource).payment_method_id);
        }

        [Test()]
        public void MPIPN_GetTypeShouldFindTheRightClassType()
        {
            Type type = MPIPN.GetType(MPIPN.Topic.payment);

            Assert.IsTrue(typeof(Payment) == type);
        }

        [Test()]
        public void MPIPN_GetTypeShouldReturnNull()
        {
            Type type = MPIPN.GetType("MercadoPago.Resources.PaymentMeans");

            Assert.IsNull(type);
        }

        [Test()]
        public void MPIPN_GetTypeShouldReturnNotNullValue()
        {
            Type type = MPIPN.GetType(MPIPN.Topic.payment);

            Assert.IsNotNull(type);
        }

        [Test()]
        public void MPIPN_GetTypeShouldReturnATypeObject()
        {
            Type type = MPIPN.GetType(MPIPN.Topic.payment);

            Type castType = type as Type;

            if (castType != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        public string GenerateSingleUseToken()
        {
            JObject payload = JObject.Parse("{ \"card_number\": \"4544610257481730\", \"security_code\": \"122\", \"expiration_month\": \"7\", \"expiration_year\": \"2030\", \"cardholder\": { \"name\": \"Test test\", \"identification\": { \"type\": \"DNI\", \"number\": \"12345678\" } } }");
            MPRESTClient client = new MPRESTClient();
            MPAPIResponse responseCardToken = client.ExecuteRequestCore(
                HttpMethod.POST,
                "https://api.mercadopago.com/v1/card_tokens?public_key=TEST-075f3392-6936-4201-8777-bd9dc45edef7",
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
