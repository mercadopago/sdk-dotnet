using px_dotnet.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace px_dotnet
{
    public class MPConf
    {
        private const string DEFAULT_BASE_URL = "https://api.mercadopago.com";

        /// <summary>  
        ///  Getter/Setter for ClientSecret 
        /// </summary>
        public static string ClientSecret
        {
            get
            {
                return clientSecret;
            }
            set
            {
                if (!string.IsNullOrEmpty(clientSecret))
                    throw new MPConfException("clientSecret setting can not be changed");
                clientSecret = value;
            }
        } static string clientSecret = null;

        /// <summary>
        /// Getter/Setter for ClientId
        /// </summary>
        public static string ClientId
        {
            get
            {
                return clientId;
            }
            set
            {
                if (!string.IsNullOrEmpty(clientId))
                    throw new MPConfException("clientId setting can not be changed");
                clientId = value;
            }
        } static string clientId = null;

        /// <summary>
        /// Getter/Setter for AccessToken
        /// </summary>
        public static string AccessToken
        {
            get
            {
                return accessToken;
            }
            set
            {
                if (!string.IsNullOrEmpty(accessToken))
                    throw new MPConfException("accessToken setting can not be changed");
                accessToken = value;
            }
        } static string accessToken = null;

        /// <summary>
        /// Getter/Setter for AppId
        /// </summary>
        public static string AppId
        {
            get
            {
                return appId;
            }
            set
            {
                if (!string.IsNullOrEmpty(appId))
                    throw new MPConfException("accessToken setting can not be changed");
                appId = value;
            }
        } static String appId = null;

    }

}
