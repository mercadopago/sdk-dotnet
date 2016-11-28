using px_dotnet.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace px_dotnet
{
    public class MPConf
    {
        private const string DEFAULT_BASE_URL = "https://api.mercadopago.com";

        /// <summary>  
        ///  Propiedad que representa el ClientSecret
        /// </summary>
        public static string ClientSecret
        {
            get
            {
                return _clientSecret;
            }
            set
            {
                if (!string.IsNullOrEmpty(_clientSecret))
                {
                    throw new MPConfException("clientSecret setting can not be changed");
                }
                _clientSecret = value;
            }
        }
        static string _clientSecret = null;

        /// <summary>
        /// Propiedad que representa el ClientId
        /// </summary>
        public static string ClientId
        {
            get
            {
                return _clientId;
            }
            set
            {
                if (!string.IsNullOrEmpty(_clientId))
                {
                    throw new MPConfException("clientId setting can not be changed");
                }
                _clientId = value;
            }
        }
        static string _clientId = null;

        /// <summary>
        /// AccessToken de MercadoPago
        /// </summary>
        public static string AccessToken
        {
            get
            {
                return _accessToken;
            }
            set
            {
                if (!string.IsNullOrEmpty(_accessToken))
                {
                    throw new MPConfException("accessToken setting can not be changed");
                }
                _accessToken = value;
            }
        }
        static string _accessToken = null;

        /// <summary>
        /// Id de aplicación en MercadoPAgo
        /// </summary>
        public static string AppId
        {
            get
            {
                return _appId;
            }
            set
            {
                if (!string.IsNullOrEmpty(_appId))
                {
                    throw new MPConfException("appId setting can not be changed");
                }
                _appId = value;
            }
        }
        static String _appId = null;

        /// <summary>
        /// URL Base del API de MercadoPago, actualmente https://api.mercadopago.com
        /// </summary>
        public static string BaseUrl
        {
            get
            {
                return _baseUrl;
            }
        }
        static string _baseUrl = DEFAULT_BASE_URL;

        /// <summary>
        /// Configuración en base a un diccionario. Claves válidas para la configuración:
        /// clientSecret, clientId, accessToken, appId
        /// </summary>
        /// <param name="configurationParams"></param>
        public static void SetConfiguration(IDictionary<String, String> configurationParams)
        {
            if (configurationParams == null) throw new ArgumentException("Invalid configurationParams parameter");

            configurationParams.TryGetValue("clientSecret", out _clientSecret);
            configurationParams.TryGetValue("clientId", out _clientId);
            configurationParams.TryGetValue("accessToken", out _accessToken);
            configurationParams.TryGetValue("appId", out _appId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public static void SetConfiguration(Configuration config)
        {
			if (config == null) throw new ArgumentException("config parameter cannot be null");

            _clientSecret = GetConfigValue(config, "ClientSecret");
            _clientId = GetConfigValue(config, "ClientId");
            _accessToken = GetConfigValue(config, "AccessToken");
            _appId = GetConfigValue(config, "AppId");
        }

        /// <summary>
        /// Clean all the configuration variables
        /// (FOR TESTING ONLY)
        /// </summary>
        public static void CleanConfiguration()
        {
            _clientSecret = null;
            _clientId = null;
            _accessToken = null;
            _appId = null;
            _baseUrl = DEFAULT_BASE_URL;
        }

        private static string GetConfigValue(Configuration config, string key)
        {
            string value = null;
            KeyValueConfigurationElement keyValue = config.AppSettings.Settings[key];
            if (keyValue != null)
            {
                value = keyValue.Value;
            }
            return value;
        }
    }
}
