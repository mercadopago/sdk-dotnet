using MercadoPago;
using MercadoPago.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoPago.DataStructures.Preference;
using System.Net;
using Newtonsoft.Json.Linq;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture()]
    public class PreferenceTest
    {
        Preference LastPreference;

        [SetUp]
        public void Init()
        {
            // Avoid SSL Cert error
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            // Environment.GetEnvironmentVariable("ACCESS_TOKEN");  
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");
            SDK.ClientId = "6295877106812064"; // Environment.GetEnvironmentVariable("CLIENT_ID");
            SDK.ClientSecret = "N8h64ko1SbY2ucyZVmOMyBJN1B82ajZp"; //Environment.GetEnvironmentVariable("CLIENT_SECRET");
        }

        [Test]
        public void Preference_CreateShouldBeOk()
        {
            Preference preference = new Preference(); 
            preference.Items.Add(
                new Item()
                {
                    Title = "Dummy Item",
                    Description = "Multicolor Item",
                    Quantity = 1,
                    UnitPrice = (float)10.0
                }
            );
            preference.Save();

            LastPreference = preference;

            Assert.IsTrue(preference.Id.Length > 0 , "Failed: Payment could not be successfully created");
            Assert.IsTrue(preference.InitPoint.Length > 0, "Failed: Preference has not a valid init point");  
        }

        [Test]
        public void Preference_FindByIDShouldbeOk()
        {
            Preference foundedPreference = Preference.FindById(LastPreference.Id); 
            Assert.AreEqual(foundedPreference.Id, LastPreference.Id); 
        }

        [Test]
        public void Preference_UpdateShouldBeOk()
        {
            LastPreference.ExternalReference = "DummyPreference for Integration Test";
            LastPreference.Update();
            Assert.AreEqual(LastPreference.ExternalReference, "DummyPreference for Integration Test"); 
        }  
    }
}
