using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    public class MPCredentials
    {
        public static string GetAccessToken()
        {           
            if (string.IsNullOrEmpty(MPConf.ClientId) || string.IsNullOrEmpty(MPConf.ClientSecret))
            {
                throw new MPException("Client_ID and Client_Secret can not be null when getting the access_token");
            }

            JObject jsonPayload = new JObject();
            jsonPayload.Add("grant_type", "client_credentials");
            jsonPayload.Add("client_id", MPConf.ClientId);
            jsonPayload.Add("client_secret", MPConf.ClientSecret);

            string accessToken = null;

            MPAPIResponse response = new MPRESTClient().ExecuteRequest(HttpMethod.POST, MPConf.BaseUrl + "/oauth/token", 
                                                                        PayloadType.X_WWW_FORM_URLENCODED, jsonPayload, null);

            if (response.StatusCode == 200)
            {                    
                JProperty prop = response.JsonObjectResponse.Properties().FirstOrDefault(p => p.Name.Contains("access_token"));
                if (string.IsNullOrEmpty(prop.Value.ToString()))
                {
                    accessToken = prop.Value.ToString();
                }
                else
                {
                    throw new MPException("Acces_token has returned empty.");
                }                                
            }
            else
            {
                throw new MPException("Cannot retrieve the access_token.");
            }
            
            return accessToken;
        }
    }
}
