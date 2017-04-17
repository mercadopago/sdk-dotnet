using MercadoPago;
using MercadoPago.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture()]
    public class PreferenceTest
    {
        [Test()]
        public void Preference_LoadShouldbeOk()
        {
            MPConf.CleanConfiguration();
            MPConf.SetBaseUrl("https://api.mercadopago.com");

            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            MPConf.SetConfiguration(config);

            Preference preferenceInternal = new Preference();
            try
            {
                var result = preferenceInternal.Load("1234");
            }
            catch (MPException mpException)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test()]
        public void Preference_UpdateShouldBeOk()
        {
            MPConf.CleanConfiguration();
            MPConf.SetBaseUrl("https://api.mercadopago.com");

            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            MPConf.SetConfiguration(config);

            Preference preferenceInternal = new Preference() { ID = "1" };

            try
            {
                var result = preferenceInternal.Update();
            }
            catch (MPException mpException)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test()]
        public void Preference_UpdateShouldRaiseException()
        {
            Preference preferenceInternal = new Preference() { ID = "1" };

            preferenceInternal.ID = "2";

            try
            {
                var result = preferenceInternal.Update();
            }
            catch (MPException mpException)
            {
                Assert.AreEqual("\"client_id\" and \"client_secret\" can not be \"null\" when getting the \"access_token\"", mpException.Message);
            }

            Assert.Pass();
        }

        [Test()]
        public void Preference_CreateShouldBeOk()
        {
            MPConf.CleanConfiguration();
            MPConf.SetBaseUrl("https://api.mercadopago.com");

            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            MPConf.SetConfiguration(config);

            Preference PreferenceInternal = new Preference();

            try
            {
                var result = PreferenceInternal.Create();
            }
            catch (MPException mpException)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }
    }
}
