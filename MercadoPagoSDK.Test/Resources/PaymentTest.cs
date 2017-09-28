using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoPago.Resources;
using MercadoPago.Resources.DataStructures.Payment;
using MercadoPago;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture()]
    public class PaymentTest
    {               
        [Test()]
        public void Payment_LoadShouldbeOk()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");

            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            SDK.SetConfiguration(config);

            Payment paymentInternal = new Payment();
            try
            {
                var result = paymentInternal.Load("1234");
            }
            catch (MPException mpException)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }        

        [Test()]
        public void Payment_UpdateShouldBeOk()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");

            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            SDK.SetConfiguration(config);

            Payment PaymentInternal = new Payment() { ID = "1" };

            try
            {
                var result = PaymentInternal.Update();
            }
            catch (MPException mpException)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test()]
        public void Payment_UpdateShouldRaiseException()
        {
            Payment PaymentInternal = new Payment() { ID = "1" };

            PaymentInternal.ID = "2";

            try
            {
                var result = PaymentInternal.Update();
            }
            catch (MPException mpException)
            {
                Assert.AreEqual("\"client_id\" and \"client_secret\" can not be \"null\" when getting the \"access_token\"", mpException.Message);
            }

            Assert.Pass();
        }

        [Test()]
        public void Payment_CreateShouldBeOk()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");

            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            SDK.SetConfiguration(config);

            Payment PaymentInternal = new Payment();

            try
            {
                var result = PaymentInternal.Save();
            }
            catch (MPException mpException)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }
    }
}
