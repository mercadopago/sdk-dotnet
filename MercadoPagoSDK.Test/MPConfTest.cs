using NUnit.Framework;
using System;
using MercadoPago;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MercadoPagoSDK.Test
{
	[TestFixture()]
	public class MPConfTest
	{
		[Test()]
		public void AttributesConfigurationTests()
		{
			SDK.CleanConfiguration();

			// Test attribute value assignation
			SDK.ClientSecret = "CLIENT_SECRET";
			SDK.ClientId = "CLIENT_ID";
			SDK.AccessToken = "ACCESS_TOKEN";
			SDK.AppId = "APP_ID";

			Assert.AreEqual("CLIENT_SECRET", SDK.ClientSecret,
				"Client Secret must be \"CLIENT_SECRET\" at this point");
			Assert.AreEqual("CLIENT_ID", SDK.ClientId,
				"Client Id must be \"CLIENT_ID\" at this point");
			Assert.AreEqual("ACCESS_TOKEN", SDK.AccessToken,
				"Access Token must be \"ACCESS_TOKEN\" at this point");
			Assert.AreEqual("APP_ID", SDK.AppId,
				"App Id must be \"APP_ID\" at this point");
			Assert.AreEqual("https://api.mercadopago.com", SDK.BaseUrl,
				"MPBase url must be default \"https://api.mercadopago.com\" at this point");


			// Test for value locking
			MPConfException auxException = null;
			try
			{
				SDK.ClientSecret = "CHANGED_CLIENT_SECRET";
			}
			catch (MPConfException mpConfException)
			{
				Assert.AreEqual("clientSecret setting can not be changed", mpConfException.Message,
					"Exception must have \"clientSecret setting can not be changed\" message");
				auxException = mpConfException;
			}
			Assert.IsInstanceOf<MPConfException>(auxException, "Exception type must be \"MPConfException\"");
			Assert.AreEqual("CLIENT_SECRET", SDK.ClientSecret, "Client Secret must be \"CLIENT_SECRET\" at this point");

			auxException = null;
			try
			{
				SDK.ClientId = "CHANGED_CLIENT_ID";
			}
			catch (MPConfException mpConfException)
			{
				Assert.AreEqual("clientId setting can not be changed", mpConfException.Message,
					"Exception must have \"clientId setting can not be changed\" message");
				auxException = mpConfException;
			}
			Assert.IsInstanceOf<MPConfException>(auxException, "Exception type must be \"MPConfException\"");
			Assert.AreEqual("CLIENT_ID", SDK.ClientId, "Client Id must be \"CLIENT_ID\" at this point");

			auxException = null;
			try
			{
				SDK.AccessToken = "CHANGED_ACCESS_TOKEN";
			}
			catch (MPConfException mpConfException)
			{
				Assert.AreEqual("accessToken setting can not be changed", mpConfException.Message,
					"Exception must have \"accessToken setting can not be changed\" message");
				auxException = mpConfException;
			}
			Assert.IsInstanceOf<MPConfException>(auxException, "Exception type must be \"MPConfException\"");
			Assert.AreEqual("ACCESS_TOKEN", SDK.AccessToken, "Access Token must be \"ACCESS_TOKEN\" at this point");

			auxException = null;
			try
			{
				SDK.AppId = "CHANGED_APP_ID";
			}
			catch (MPConfException mpConfException)
			{
				Assert.AreEqual("appId setting can not be changed", mpConfException.Message,
					"Exception must have \"appId setting can not be changed\" message");
				auxException = mpConfException;
			}
			Assert.IsInstanceOf<MPConfException>(auxException, "Exception type must be \"MPConfException\"");
			Assert.AreEqual("APP_ID", SDK.AppId, "App Id must be \"APP_ID\" at this point");
		}


		[Test()]
		public void InvalidHashMapConfigurationTests()
		{
			SDK.CleanConfiguration();

			Dictionary<string, string> hashConfigurations = null;
			Exception auxException = null;
			try
			{
				SDK.SetConfiguration(hashConfigurations);
			}
			catch (ArgumentException exception)
			{
				Assert.AreEqual("Invalid configurationParams parameter", exception.Message,
					"Exception must have \"Invalid configurationParams parameter\" message");
				auxException = exception;
			}
			Assert.IsInstanceOf<ArgumentException>(auxException, "Exception type must be \"ArgumentException\"");

			hashConfigurations = new Dictionary<string, string>();
			hashConfigurations.Add("clientSecret", null);
			auxException = null;
			try
			{
				SDK.SetConfiguration(hashConfigurations);
			}
			catch (Exception exception)
			{
				auxException = exception;
			}
			Assert.IsNull(auxException, "Exception must be \"null\"");

			hashConfigurations["clientSecret"] = "CLIENT_SECRET";
			hashConfigurations["clientId"] = "";
			auxException = null;
			try
			{
				SDK.SetConfiguration(hashConfigurations);
			}
			catch (Exception exception)
			{
				auxException = exception;
			}
			Assert.IsNull(auxException, "Exception must be \"null\"");
			Assert.AreEqual("CLIENT_SECRET", SDK.ClientSecret, "Client Secret must be \"CLIENT_SECRET\" at this point");
		}


		[Test()]
		public void AppConfigInvalidConfigurationTests()
		{
			SDK.CleanConfiguration();

			Exception auxException = null;
			try
			{
				Configuration config = null;
				SDK.SetConfiguration(config);
			}
			catch (ArgumentException exception)
			{
				Assert.AreEqual("config parameter cannot be null", exception.Message, "Exception must have \"config parameter cannot be null\" message");
				auxException = exception;
			}
			Assert.IsInstanceOf<ArgumentException>(auxException, "Exception type must be \"ArgumentException\"");

			auxException = null;
			try
			{
				SDK.SetConfiguration(GetConfigurationByFileName("MPConf_invalid_App"));
			}
			catch (Exception exception)
			{
				auxException = exception;
			}
			Assert.IsNull(auxException, "Exception must be \"null\"");
			Assert.IsNull(SDK.ClientSecret, "Client Secret must be \"null\" at this point");
			Assert.IsNull(SDK.ClientId, "Client Id must be \"null\" at this point");
			Assert.IsNull(SDK.AccessToken, "Access Token must be \"null\" at this point");
			Assert.IsNull(SDK.AppId, "App Id must be \"null\" at this point");
		}

		[Test()]
		public void AppConfigValidConfigurationTests()
		{
			SDK.CleanConfiguration();

			SDK.SetConfiguration(GetConfigurationByFileName("MPConf_valid_App.config"));
			Assert.AreEqual("CLIENT_SECRET", SDK.ClientSecret, "Client Secret must be \"CLIENT_SECRET\" at this point");
			Assert.AreEqual("CLIENT_ID", SDK.ClientId, "Client Id must be \"CLIENT_ID\" at this point");
			Assert.AreEqual("ACCESS_TOKEN", SDK.AccessToken, "Access Token must be \"ACCESS_TOKEN\" at this point");
			Assert.AreEqual("APP_ID", SDK.AppId, "App Id must be \"APP_ID\" at this point");
		}


		public Configuration GetConfigurationByFileName(string fileName)
		{    
			string current_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string configFile = current_path + "/Data/" + fileName; 
			ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
			configFileMap.ExeConfigFilename = configFile;
			Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
 
			return config;
		}

	}
}
