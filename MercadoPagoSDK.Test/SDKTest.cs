using System;
using NUnit.Framework;
using MercadoPago;
using System.Net;
using Newtonsoft.Json.Linq;

namespace MercadoPagoSDK.Test
{ 
    [TestFixture]
    public class SDKTest
    { 
        string AccessToken;

        [SetUp]
        public void Init()
        {
            // Avoid SSL Cert error
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            // HardCoding Credentials
            AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");
            // Make a Clean Test
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");
            SDK.AccessToken = AccessToken;
        }

        [Test]
        public void GenericGetMethod()
        {
            JToken results = SDK.Get("/v1/sites");
            Assert.IsTrue(results != null);
        }

        [Test]
        public void GenericPostMethod()
        {

            JObject preference = new JObject(
                new JProperty("items", new JArray(
                    new JObject(
                        new JProperty("title", "Dummy Item"),
                        new JProperty("description", "Multicolor Item"),
                        new JProperty("quantity", 3),
                        new JProperty("unit_price", 10.0)))),
                
                new JProperty("payer", new JArray(
                    new JObject(
                        new JProperty("email", "demo@gmail.com")
                    )
                )) 
            );
            
            JToken results = SDK.Post("/checkout/preferences", preference);

            Assert.IsTrue(results != null);

        }

        [Test]
        public void GenericPutMethod()
        {

        }


    }

}
