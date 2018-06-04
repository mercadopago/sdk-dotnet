using System;
using System.Collections.Generic;
using System.Net;
using MercadoPago;
using MercadoPago.Resources;
using NUnit.Framework;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture] 
    public class PaymentMethodTest
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
        public void PaymentMethod_All_ShouldReturnValues()
        {
            List<PaymentMethod> paymentMethods = PaymentMethod.All(); 

            Assert.IsTrue(paymentMethods.Count > 1,  "Failed: Can't get payment methods");

        }

    }
}
