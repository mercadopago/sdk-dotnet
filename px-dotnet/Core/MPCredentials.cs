using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    public class MPCredentials
    {
        /// <summary>
        /// Gets access token for current ClientId and ClientSecret
        /// </summary>
        /// <returns>Access token.</returns>
        public static string GetAccessToken()
        {
            if (string.IsNullOrEmpty(MPConf.ClientId) || string.IsNullOrEmpty(MPConf.ClientSecret))
            {
                throw new MPException("\"client_id\" and \"client_secret\" can not be \"null\" when getting the \"access_token\"");
            }

            JObject jsonPayload = new JObject();
            jsonPayload.Add("grant_type", "client_credentials");
            jsonPayload.Add("client_id", MPConf.ClientId);
            jsonPayload.Add("client_secret", MPConf.ClientSecret);

            string access_token, refresh_token = null;
            MPAPIResponse response = new MPRESTClient().ExecuteRequest(
                    HttpMethod.POST,
                    MPConf.BaseUrl + "/oauth/token",
                    PayloadType.X_WWW_FORM_URLENCODED,
                    jsonPayload,
                    null);

            JObject jsonResponse = JObject.Parse(response.StringResponse.ToString());

            if (response.StatusCode == 200)
            {
                List<JToken> accessTokenElem = MPCoreUtils.FindTokens(jsonResponse, "access_token");
                List<JToken> refreshTokenElem = MPCoreUtils.FindTokens(jsonResponse, "refresh_token");

                if (accessTokenElem != null && accessTokenElem.Count == 1)                
                    access_token = accessTokenElem.First().ToString();                
                else                
                    throw new MPException("Can not retrieve the \"access_token\"");

                
                if (refreshTokenElem != null && refreshTokenElem.Count == 1)                
                    refresh_token = refreshTokenElem.First().ToString();                
                else                
                    throw new MPException("Can not retrieve the \"refresh_token\"");
                
            }
            else
            {
                throw new MPException("Can not retrieve the \"access_token\"");
            }

            MPConf.RefreshToken = refresh_token;
            return access_token;
        }

        /// <summary>
        ///  Refreshes access token for current refresh token
        /// </summary>
        /// <returns>Refreshed access token</returns>
        public static string RefreshAccessToken()
        {
            if (string.IsNullOrEmpty(MPConf.RefreshToken))
            {
                throw new MPException("\"RefreshToken\" can not be \"null\". Refresh access token could not be completed.");
            }

            JObject jsonPayload = new JObject();
            jsonPayload.Add("client_secret", MPConf.ClientSecret);
            jsonPayload.Add("grant_type", "refresh_token");
            jsonPayload.Add("refresh_token", MPConf.RefreshToken);

            string new_access_token = null;
            MPAPIResponse response = new MPRESTClient().ExecuteRequest(
                    HttpMethod.POST,
                    MPConf.BaseUrl + "/oauth/token",
                    PayloadType.X_WWW_FORM_URLENCODED,
                    jsonPayload,
                    null);

            JObject jsonResponse = JObject.Parse(response.StringResponse.ToString());

            if (response.StatusCode == 200)
            {
                List<JToken> accessTokenElem = MPCoreUtils.FindTokens(jsonResponse, "access_token");

                if (accessTokenElem != null && accessTokenElem.Count == 1)
                    new_access_token = accessTokenElem.First().ToString();
                else
                    throw new MPException("Can not retrieve the new \"access_token\"");
            }
            else
            {
                throw new MPException("Can not retrieve the new \"access_token\"");
            }

            return new_access_token;
        }
    }
}
