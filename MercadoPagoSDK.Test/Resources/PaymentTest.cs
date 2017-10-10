using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoPago.Resources;
using MercadoPago.Resources.DataStructures.Payment;
using MercadoPago;
using Newtonsoft.Json.Linq;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture()]
    public class PaymentTest
    {                                     
        [Test()]
        public void Payment_CreateAndLoadShouldBeOk()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");
            SDK.AccessToken = "TEST-4205497482754834-092513-34a1c5f06438b3a488bad9420cfe84e5__LB_LD__-261220529";           
            
            Payment payment = new Payment();
            Payer payer = new Payer();
            payer.email = "mlovera@kinexo.com";

            payment.transaction_amount = 100M;
            payment.token = GenerateSingleUseToken(); // 1 use card token
            payment.description = "Pago de seguro";
            payment.payment_method_id = "visa";
            payment.installments = 1;
            payment.payer = payer;
          
            try
            {
                Payment response = payment.Create();
                Assert.IsTrue(response.id.HasValue);
                Assert.IsTrue(response.id.Value > 0);

                string id = response.id.ToString();
                Payment getPayment = Payment.Load(id, false);

                Assert.AreEqual("Pago de seguro", getPayment.description);
                Assert.AreEqual("mlovera@kinexo.com", getPayment.payer.email);
            }
            catch (MPException)
            {
                Assert.Fail();
            }            
        }

        [Test()]
        public void Payment_LoadShouldBeOk()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");
            SDK.AccessToken = "TEST-4205497482754834-092513-34a1c5f06438b3a488bad9420cfe84e5__LB_LD__-261220529";
            Payment payment = Payment.Load("7100921", false);
            Assert.AreEqual("Pago de seguro", payment.description);
        }

        //[Test()]
        //public void Payment_UpdateShouldBeOk()
        //{
        //    MPConf.CleanConfiguration();
        //    MPConf.SetBaseUrl("https://api.mercadopago.com");
        //    MPConf.AccessToken = "TEST-4205497482754834-092513-34a1c5f06438b3a488bad9420cfe84e5__LB_LD__-261220529";

            

        //    Payment payment = new Payment();
        //    Payer payer = new Payer();
        //    payer.email = "mlovera@kinexo.com";

        //    payment.transaction_amount = 100M;
        //    payment.token = GenerateSingleUseToken(); // 1 use card token
        //    payment.description = "Pago de seguro";
        //    payment.payment_method_id = "visa";
        //    payment.installments = 1;
        //    payment.payer = payer;


        //    try
        //    {
        //        Payment response = payment.Create();                
                
        //        //update
        //        response.description = "New Description";
        //        var updatedPayment = response.Update();

        //        Assert.AreEqual("New Description", updatedPayment.description);
        //    }
        //    catch (MPException)
        //    {
        //        Assert.Fail();
        //    }   
        //}

        [Test()]
        public void GenerateSingleUseToken_ReturnsValidToken()
        {
            string token = GenerateSingleUseToken();
            Assert.IsFalse(string.IsNullOrEmpty(token));
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
