using MercadoPago;
using MercadoPago.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture(Ignore = "Skipping")]
    public class CardTest
    {
        //This test give a 401 error (unauthorized).
        /*[Test()]
        public void Card_LoadShouldbeOk()
        {
            MPConf.CleanConfiguration();
            MPConf.SetBaseUrl("https://api.mercadopago.com");

            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            MPConf.SetConfiguration(config);

            Card CardInternal = new Card();
            try
            {
                var result = Card.Load("1234", "1234");
            }
            catch (MPException mpException)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }
        
        [Test()]
        public void Card_UpdateShouldBeOk()
        {
            MPConf.CleanConfiguration();
            MPConf.SetBaseUrl("https://api.mercadopago.com");

            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            MPConf.SetConfiguration(config);

            Card CardInternal = new Card() { ID = "1", customer_id = "2" };

            try
            {
                var result = CardInternal.Update();
            }
            catch (MPException mpException)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }
         
        [Test()]
        public void Card_CreateShouldBeOk()
        {
            MPConf.CleanConfiguration();
            MPConf.SetBaseUrl("https://api.mercadopago.com");

            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            MPConf.SetConfiguration(config);

            Card CardInternal = new Card() { ID = "23", customer_id = "24" };

            try
            {
                var result = CardInternal.Create();
            }
            catch (MPException mpException)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }*/

        [Test()]
        public void Card_UpdateShouldRaiseException()
        {
            Card CardInternal = new Card() { Id = "1", CustomerId = "1"};            

            try
            {
                var result = CardInternal.Update();
            }
            catch (MPException mpException)
            {
                Assert.AreEqual("\"client_id\" and \"client_secret\" can not be \"null\" when getting the \"access_token\"", mpException.Message);
            }

            Assert.Pass();
        }        
    }
}
