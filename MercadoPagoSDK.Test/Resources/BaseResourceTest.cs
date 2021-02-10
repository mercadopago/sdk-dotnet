using System;
using System.Net;
using MercadoPago;
using NUnit.Framework;

namespace MercadoPagoSDK.Test.Resources
{
    public class BaseResourceTest
    {
        protected String AccessToken { get; set; }

        protected String PublicKey { get; set; }

        [SetUp]
        public void SetUp()
        {
            // Avoid SSL Cert error
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            // Credentials
            AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");
            PublicKey = Environment.GetEnvironmentVariable("PUBLIC_KEY");
            // Make a Clean Test
            SDK.CleanConfiguration();
            SDK.AccessToken = AccessToken;
        }

        protected MPRequestOptions NewRequestOptions()
        {
            return new MPRequestOptions
            {
                AccessToken = AccessToken,
            };
        }
    }
}
