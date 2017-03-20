using MercadoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MercadoPagoSDK.Test
{
    public class MPCredentialsTest
    {
        [Test()]
        public void GetAccessToken_Retrieves_Acces_token()
        {
            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", "9WE8Kjum3aXeBzjCnyE1pbNZdENyc4UI");
            config.Add("clientId", "8355802880924986");
            MPConf.SetConfiguration(config);

            string accessToken = MPConf.GetAccessToken();
            Assert.NotNull(accessToken);          
        }

        //[Test()]
        //public void RefreshAccessToken_Refreshes_Acces_token() // revisando alcance/definiciones
        //{
        //    try
        //    {
        //        string token = MPConf.GetAccessToken();
        //    }
        //    catch (MPException ex)
        //    {
        //        Assert.AreEqual("\"client_id\" and \"client_secret\" can not be \"null\" when getting the \"access_token\"", ex.Message);
        //    }

        //    MPConf.ClientId = "8355802880924986";
        //    MPConf.ClientSecret = "9WE8Kjum3aXeBzjCnyE1pbNZdENyc4UI";
        //    string useLess = MPConf.GetAccessToken(); // Just to get refresh_token

        //    string refreshedAccessToken = MPConf.RefreshAccessToken();
        //    Assert.NotNull(refreshedAccessToken);
        //}
    }
}
