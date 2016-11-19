using Microsoft.VisualStudio.TestTools.UnitTesting;
using px_dotnet.Exceptions;
using System;

namespace px_dotnet.Test
{
    [TestClass]
    public class MPConfTest
    {
        /// <summary>
        /// Test for attributes getters/setters
        /// </summary>
		[TestMethod]
        public void AttributesConfigurationTests()
        {
            // Test attribute value assignation
            MPConf.ClientSecret = "CLIENT_SECRET";
            MPConf.ClientId = "CLIENT_ID";
            MPConf.AccessToken = "ACCESS_TOKEN";
            MPConf.AppId = "APP_ID";

            Assert.AreEqual(MPConf.ClientSecret, "CLIENT_SECRET",
                "Client Secret must be \"CLIENT_SECRET\" at this point");
            Assert.AreEqual(MPConf.ClientId, "CLIENT_ID",
                "Client Id must be \"CLIENT_ID\" at this point");
            Assert.AreEqual(MPConf.AccessToken, "ACCESS_TOKEN",
                "Access Token must be \"ACCESS_TOKEN\" at this point");
            Assert.AreEqual(MPConf.AppId, "APP_ID",
                "App Id must be \"APP_ID\" at this point");
            Assert.AreEqual(MPConf.BaseUrl, "https://api.mercadopago.com",
                "MPBase url must be default \"https://api.mercadopago.com\" at this point");

            // Test for value locking
            Exception auxException = null;
            try
            {
                MPConf.ClientSecret = "CHANGED_CLIENT_SECRET";
            }
            catch (MPConfException mpConfException)
            {
                Assert.AreEqual(mpConfException.Message, "clientSecret setting can not be changed",
                    "Exception must have \"clientSecret setting can not be changed\" message");
                auxException = mpConfException;
            }
            Assert.IsInstanceOfType(auxException, typeof(MPConfException), "Exception type must be \"MPConfException\"");
            Assert.AreEqual(MPConf.ClientSecret, "CLIENT_SECRET", "Client Secret must be \"CLIENT_SECRET\" at this point");

            auxException = null;
            try
            {
                MPConf.ClientId = "CHANGED_CLIENT_ID";
            }
            catch (MPConfException mpConfException)
            {
                Assert.AreEqual(mpConfException.Message, "clientId setting can not be changed",
                    "Exception must have \"clientId setting can not be changed\" message");
                auxException = mpConfException;
            }
            Assert.IsInstanceOfType(auxException, typeof(MPConfException), "Exception type must be \"MPConfException\"");
            Assert.AreEqual(MPConf.ClientId, "CLIENT_ID", "Client Id must be \"CLIENT_ID\" at this point");

            auxException = null;
            try
            {
                MPConf.AccessToken = "CHANGED_ACCESS_TOKEN";
            }
            catch (MPConfException mpConfException)
            {
                Assert.AreEqual(mpConfException.Message, "accessToken setting can not be changed",
                    "Exception must have \"accessToken setting can not be changed\" message");
                auxException = mpConfException;
            }
            Assert.IsInstanceOfType(auxException, typeof(MPConfException), "Exception type must be \"MPConfException\"");
            Assert.AreEqual(MPConf.AccessToken, "ACCESS_TOKEN", "Access Token must be \"ACCESS_TOKEN\" at this point");

            auxException = null;
            try
            {
                MPConf.AppId = "CHANGED_APP_ID";
            }
            catch (MPConfException mpConfException)
            {
                Assert.AreEqual(mpConfException.Message, "appId setting can not be changed",
                    "Exception must have \"appId setting can not be changed\" message");
                auxException = mpConfException;
            }
            Assert.IsInstanceOfType(auxException, typeof(MPConfException), "Exception type must be \"MPConfException\"");
            Assert.AreEqual(MPConf.AppId, "APP_ID", "App Id must be \"APP_ID\" at this point");
        }
    }
}
