using System;
using System.Net;
using MercadoPago;
using NUnit.Framework;

namespace MercadoPagoSDK.Test.Resources
{
    public class BaseResourceTest
    {
        protected String AccessToken { get; set; }

        [SetUp]
        public void Init()
        {
            // Avoid SSL Cert error
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            // Credentials
            AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");
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
