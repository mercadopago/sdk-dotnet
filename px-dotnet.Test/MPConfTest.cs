using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using px_dotnet;

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
            // Test attribute value asignation
            MPConf.ClientSecret = "CLIENT_SECRET";
            MPConf.ClientId = "CLIENT_ID";
            MPConf.AccessToken = "ACCESS_TOKEN";
            MPConf.AppId = "APP_ID";

        }
    }
}
