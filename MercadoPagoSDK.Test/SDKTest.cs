using System;
using NUnit.Framework;
using MercadoPago;
using System.Net;
using System.Reflection;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace MercadoPagoSDK.Test
{
    [TestFixture]
    public class SDKTest
    { 
        [SetUp]
        public void Init()
        {
            // Avoid SSL Cert error
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            // Make a Clean Test
            SDK.CleanConfiguration();
        }

        [Test]
        public void ClientSecretTest()
        {
            var clientSecret = "X";
            SDK.ClientSecret = clientSecret;
            Assert.AreEqual(clientSecret, SDK.ClientSecret);
        }

        [Test]
        public void ClientSecretErrorTest()
        {
            var clientSecret = "X";
            SDK.ClientSecret = clientSecret;

            Assert.Throws<MPConfException>(() =>
            {
                SDK.ClientSecret = "Y";
            });
        }

        [Test]
        public void ClientIdTest()
        {
            var clientId = "X";
            SDK.ClientId = clientId;
            Assert.AreEqual(clientId, SDK.ClientId);
        }

        [Test]
        public void ClientIdErrorTest()
        {
            var clientId = "X";
            SDK.ClientId = clientId;

            Assert.Throws<MPConfException>(() =>
            {
                SDK.ClientId = "Y";
            });
        }

        [Test]
        public void AccessTokenTest()
        {
            var accessToken = "X";
            SDK.AccessToken = accessToken;
            Assert.AreEqual(accessToken, SDK.AccessToken);
        }

        [Test]
        public void AccessTokenErrorTest()
        {
            var accessToken = "X";
            SDK.AccessToken = accessToken;

            Assert.Throws<MPConfException>(() =>
            {
                SDK.AccessToken = "Y";
            });
        }

        [Test]
        public void AppIdTest()
        {
            var appId = "X";
            SDK.AppId = appId;
            Assert.AreEqual(appId, SDK.AppId);
        }

        [Test]
        public void AppIdErrorTest()
        {
            var appId = "X";
            SDK.AppId = appId;

            Assert.Throws<MPConfException>(() =>
            {
                SDK.AppId = "Y";
            });
        }

        [Test]
        public void CorporationIdTest()
        {
            var corporationId = "X";
            SDK.CorporationId = corporationId;
            Assert.AreEqual(corporationId, SDK.CorporationId);
        }

        [Test]
        public void CorporationIdErrorTest()
        {
            var corporationId = "X";
            SDK.CorporationId = corporationId;

            Assert.Throws<MPConfException>(() =>
            {
                SDK.SetCorporationId("Y");
            });
        }

        [Test]
        public void IntegratorIdTest()
        {
            var integratorId = "X";
            SDK.IntegratorId = integratorId;
            Assert.AreEqual(integratorId, SDK.IntegratorId);
        }

        [Test]
        public void IntegratorIdErrorTest()
        {
            var integratorId = "X";
            SDK.IntegratorId = integratorId;

            Assert.Throws<MPConfException>(() =>
            {
                SDK.SetIntegratorId("Y");
            });
        }

        [Test]
        public void PlatformIdTest()
        {
            var platformId = "X";
            SDK.PlatformId = platformId;
            Assert.AreEqual(platformId, SDK.PlatformId);
        }

        [Test]
        public void PlatformIdErrorTest()
        {
            var platformId = "X";
            SDK.PlatformId = platformId;

            Assert.Throws<MPConfException>(() =>
            {
                SDK.SetPlatformId("Y");
            });
        }

        [Test]
        public void BaseUrlTest()
        {
            Assert.AreEqual("https://api.mercadopago.com", SDK.BaseUrl);
        }

        [Test]
        public void GetSetPropertiesTest()
        {
            SDK.RequestsTimeout = 10000;
            Assert.AreEqual(10000, SDK.RequestsTimeout);

            SDK.RequestsRetries = 3;
            Assert.AreEqual(3, SDK.RequestsRetries);

            var proxy = new WebProxy();
            SDK.Proxy = proxy;
            Assert.AreEqual(proxy, SDK.Proxy);

            SDK.RefreshToken = "X";
            Assert.AreEqual("X", SDK.RefreshToken);

            SDK.MetricsScope = "Y";
            Assert.AreEqual("Y", SDK.MetricsScope);

            var version = new AssemblyName(typeof(SDK).Assembly.FullName).Version.ToString(3);
            Assert.AreEqual(version, SDK.Version);

            var trackingId = String.Format("platform:{0}|{1},type:SDK{2},so;", Environment.Version.Major, Environment.Version, version);
            Assert.AreEqual(trackingId, SDK.TrackingId);

            Assert.AreEqual("BC32BHVTRPP001U8NHL0", SDK.ProductId);
            Assert.AreEqual("MercadoPago-SDK-DotNet", SDK.ClientName);
        }

        [Test]
        public void SetConfigurationDictionaryTest()
        {
            var config = new Dictionary<String, String>
            {
                { "clientSecret", "A" },
                { "clientId", "B" },
                { "accessToken", "C" },
                { "appId", "D" },
                { "requestsTimeout", "10" },
                { "requestsRetries", "5" },
                { "proxyHostName", "proxy" },
                { "proxyPort", "5050" },
                { "proxyUsername", "user" },
                { "proxyPassword", "password" }
            };

            SDK.SetConfiguration(config);

            Assert.AreEqual(config["clientSecret"], SDK.ClientSecret);
            Assert.AreEqual(config["clientId"], SDK.ClientId);
            Assert.AreEqual(config["accessToken"], SDK.AccessToken);
            Assert.AreEqual(config["appId"], SDK.AppId);
            Assert.AreEqual(Int32.Parse(config["requestsTimeout"]), SDK.RequestsTimeout);
            Assert.AreEqual(Int32.Parse(config["requestsRetries"]), SDK.RequestsRetries);
            Assert.NotNull(SDK.Proxy);
        }

        [Test]
        public void SetConfigurationDictionaryErrorTest()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                SDK.SetConfiguration((IDictionary<String, String>)null);
            });
        }

        [Test]
        public void SetConfigurationTest()
        {
            SDK.SetConfiguration(GetConfigurationByFileName("SDK.config"));

            Assert.AreEqual("CLIENT_SECRET", SDK.ClientSecret);
            Assert.AreEqual("CLIENT_ID", SDK.ClientId);
            Assert.AreEqual("ACCESS_TOKEN", SDK.AccessToken);
            Assert.AreEqual("APP_ID", SDK.AppId);
            Assert.AreEqual(20, SDK.RequestsTimeout);
            Assert.AreEqual(2, SDK.RequestsRetries);
            Assert.NotNull(SDK.Proxy);
        }

        [Test]
        public void SetConfigurationErrorTest()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                SDK.SetConfiguration((Configuration)null);
            });
        }

        private Configuration GetConfigurationByFileName(string fileName)
        {
            String current_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            String configFile = current_path + "/Data/" + fileName;
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = configFile
            };
            return ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
        }
    }
}
