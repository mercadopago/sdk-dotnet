using px_dotnet.Exceptions;
using System;

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
                return _clientSecret;
            }
            set
            {
                if (!string.IsNullOrEmpty(_clientSecret))
                    throw new MPConfException("clientSecret setting can not be changed");
                _clientSecret = value;
            }
        } static string _clientSecret = null;

        /// <summary>
        /// Getter/Setter for ClientId
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
                    throw new MPConfException("clientId setting can not be changed");
                _clientId = value;
            }
        } static string _clientId = null;

        /// <summary>
        /// Getter/Setter for AccessToken
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
                    throw new MPConfException("accessToken setting can not be changed");
                _accessToken = value;
            }
        } static string _accessToken = null;

        /// <summary>
        /// Getter/Setter for AppId
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
                    throw new MPConfException("appId setting can not be changed");
                _appId = value;
            }
        } static String _appId = null;

        public static string BaseUrl
        {
            get
            {
                return _baseUrl;
            }
        } static string _baseUrl = DEFAULT_BASE_URL;
    }

}
